using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        generateGlobelQueryFilterForIsDeleted();
    }


    public static void generateGlobelQueryFilterForIsDeleted()
    {
        string sourceFolder = @"E:\Project\Github\ZedClubCRM\Persistence\Entities\";
        string targetFile = @"E:\Project\Github\ZedClubCRM\Persistence\Entities\Partial\ZedClubCrmContext.cs";


        // read context file
        string contextContent = File.ReadAllText(targetFile);

        // Collect entity names that have IsDeleted property
        List<string> entityNames = new List<string>();

        foreach (var file in Directory.GetFiles(sourceFolder, "*.cs", searchOption: SearchOption.TopDirectoryOnly))
        {
            string content = File.ReadAllText(file);
            var classMatch = Regex.Match(content, @"partial\s+class\s+(\w+)");
            if (!classMatch.Success)
            {
                // not a partial class, skip
                //Console.WriteLine($"\nthere is a class mismatch here \n{file}\n");
                continue;
            }
            string className = classMatch.Groups[1].Value;


            var isDeletedMatch = Regex.Match(content, @"public\s+bool\s+IsDeleted\s*{\s*get;\s*set;\s*}");
            if (!isDeletedMatch.Success)
            {
                // no IsDeleted property, skip
                continue;
            }

            if (!entityNames.Contains(className))
            {
                entityNames.Add(className);
            }

        }

        // build lines to insert
        string filtersText = "";
        foreach (var entityName in entityNames)
        {
            filtersText += $"\t\t\tmodelBuilder.Entity<{entityName}>().HasQueryFilter(e => !e.IsDeleted);\n";
        }


        // find the region
        Regex regionRegex = new Regex(@"#region\s+Global\s+Query\s+Filters(.*?)#endregion", RegexOptions.Singleline);

        if (regionRegex.IsMatch(contextContent))
        {
            string newRegionContent = "#region Global Query Filters\n\n" + filtersText + "\n    #endregion";
            contextContent = regionRegex.Replace(contextContent, newRegionContent);
            File.WriteAllText(targetFile, contextContent);
        }
    }




    public static void generatePartialClasses()
    {
        // 
        string sourceFolder = @"E:\Project\Github\ZedClubCRM\Persistence\Entities\";
        string targetFolder = Path.Combine(sourceFolder, "Partial");
        Directory.CreateDirectory(targetFolder);
        Console.WriteLine(Directory.GetFiles(sourceFolder, "*.cs", SearchOption.TopDirectoryOnly).Count());
        foreach (var file in Directory.GetFiles(sourceFolder, "*.cs", SearchOption.TopDirectoryOnly))
        {
            // reading the old file/class
            string content = File.ReadAllText(file);



            // this section is used to extract the namespace
            //var namespaceMatch = Regex.Match(content, @"namespace\s+([^\s{]+)");
            //if (!namespaceMatch.Success) { continue; }
            //string ns = namespaceMatch.Groups[1].Value;

            // this section is used to extract the class name
            var classMatch = Regex.Match(content, @"partial\s+class\s+(\w+)");
            if (!classMatch.Success)
            {
                Console.WriteLine($"\nthere is a class mismatch here \n{file}\n");
                continue;
            }
            string className = classMatch.Groups[1].Value;


            // 
            string constructor = "";

            // finding clubId
            var clubIdMatch = Regex.Match(content, @"public\s+int\s+ClubId\s*{\s*get;\s*set;\s*}");
            if (clubIdMatch.Success)
            {
                constructor = $@"
    public {className}()
    {{
        this.ClubId = ZedClubCRM.Domain.Common.Helper.ClubId;
    }}";
            }

            // new or modified file content
            string newContent = $@"
namespace ZedClubCRM.Persistence.Entities;

public partial class {className} //:BaseClass // ,IClub
{{{constructor}    
}}
";
            // generating file path
            string newFilePath = Path.Combine(targetFolder, $"{className}.cs");
            // saving the file
            File.WriteAllText(newFilePath, newContent);
            // logging what happen
            Console.WriteLine($"class {className} created or modified");
        }
    }

    public static string NormalizePath(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        string originalInput = input;
        bool isUNCWithIP = Regex.IsMatch(originalInput, @"^\\\\\d{1,3}(\.\d{1,3}){3}");
        string normalized = originalInput.Replace('\\', '/');

        string prefix = "";
        string rest = normalized;

        // Protocol (http, file, etc.)
        var protocolMatch = Regex.Match(normalized, @"^(?<proto>(https?|ftp|file):)//", RegexOptions.IgnoreCase);
        if (protocolMatch.Success)
        {
            prefix = protocolMatch.Groups["proto"].Value.ToLower().TrimEnd(':') + "://";
            rest = normalized.Substring(protocolMatch.Value.Length);
        }
        else if (isUNCWithIP)
        {
            var uncMatch = Regex.Match(normalized, @"^//(?<ip>\d{1,3}(\.\d{1,3}){3})(/(?<share>[^/]+))?");
            if (uncMatch.Success)
            {
                prefix = "\\\\" + uncMatch.Groups["ip"].Value;
                if (uncMatch.Groups["share"].Success)
                    prefix += "/" + uncMatch.Groups["share"].Value.ToLower();
                rest = normalized.Substring(uncMatch.Value.Length);
            }
        }
        else
        {
            var uncMatch = Regex.Match(normalized, @"^//(?<host>[^/]+)(/(?<share>[^/]+))?");
            if (uncMatch.Success)
            {
                prefix = "/" + uncMatch.Groups["host"].Value.ToLower();
                if (uncMatch.Groups["share"].Success)
                    prefix += "/" + uncMatch.Groups["share"].Value.ToLower();
                rest = normalized.Substring(uncMatch.Value.Length);
            }
        }

        // Collapse repeated slashes
        rest = Regex.Replace(rest, "/{2,}", "/");

        // Extract filename and folder
        int lastSlash = rest.LastIndexOf('/');
        string folderPart = lastSlash >= 0 ? rest.Substring(0, lastSlash + 1).ToLower() : rest.ToLower();
        string filename = lastSlash >= 0 ? rest.Substring(lastSlash + 1) : "";

        if (!string.IsNullOrEmpty(filename))
        {
            string name = Regex.Replace(filename, @"\.[^.]+$", m => m.Value.ToLower()); // lowercase extension only
            filename = name; // Keep filename case as-is
        }

        string finalPath = prefix + folderPart + filename;

        // For UNC server (non-IP), ensure single leading slash
        if (!isUNCWithIP && finalPath.StartsWith("//"))
        {
            finalPath = "/" + finalPath.TrimStart('/');
        }

        return finalPath;
    }


}
