using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Transactions;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        replacePremission();
        //ReplacePermissionViews();
    }


    public static void replacePremission()
    {

        /*
                select '    public class PermissionNames'
                UNION ALL
                select '    {'
                UNION ALL
                select '    #region properties'
                UNION ALL
                select Char(10)
                UNION ALL
                SELECT '        public const string ' + replace([name],' ','') + ' = "' + [name]+'";' 
                + CHAR(10) -- new line
                        + '        public const string ' + replace([name],' ','') + 'Code = "' + [name] +'";'
                FROM Permissions
                UNION ALL
                select Char(10)
                UNION ALL
                select '    #endregion'
                UNION ALL
                select Char(10)
                UNION ALL
                SELECT '        public static readonly Dictionary<string, string> permissions = new Dictionary<string, string>' 
                + CHAR(10)+'{'
                UNION ALL
                SELECT '			{ ' + replace([name],' ','') + ', ' + replace([name],' ','') + 'Code },'
                FROM Permissions
                UNION ALL
                SELECT '        };'
                UNION ALL
                select Char(10)
                UNION ALL
                SELECT '        public static readonly Dictionary<string, string> permissionsInverse = new Dictionary<string, string>'
                + CHAR(10)+'{'
                UNION ALL
                SELECT '			{ ' + replace([name],' ','') + 'Code, ' + replace([name],' ','') + ' },'
                FROM Permissions
                UNION ALL
                SELECT '        };'
                UNION ALL
                select Char(10)
                UNION ALL
                select '    }'
                ;
                */

        string[] values =
        {
            "Edit Membership",  "DeleteMemberShip",  "ManagePlan",  "CreatePlan",  "ClonePlan",  "DeletePlan",  "ManageUsers",  "AssignUserPermission",  "AssignRolePermission",  "ManageInactiveUsers",  "OverDueChildSeparation",  "HandicappedChild",  "MemberHistory",  "MemeberDetails",  "OverDue",  "InActiveMemberShips",  "MembershipHistory",  "MainMemberShip",  "HonorMemberShip",  "SeasonalMemberShip",  "MemberShipDetails",  "SportMemberShip",  "ManageMember",  "CreateMember",  "EditMember",  "SuspendMember",  "UnSuspendMember",  "DeleteMember",  "GetAttachments",  "EditPlan",  "InvoiceManager",  "MemberDetails",  "AddSubMember",  "PaymentReport",  "LogReport",  "Penalty_manager",  "Penalty_Add",  "Cheque_add",  "Cheque_manager",  "TaxConfig_add",  "TaxConfig_manager",  "TaxConfig_delete",  "TaxConfig_edit",  "Cheque_delete",  "Card_manager",  "Card_details",  "Penalty_edit",  "Plan_delete",  "Plan_edit",  "Plan_clone",  "Plan_add",  "Plan_manager",  "DataMigration_manager",  "Contract_details",  "Contract_delete",  "Contract_edit",  "Contract_add",  "Contract_manager",  "PlanItem_delete",  "PlanItem_edit",  "PlanItem_add",  "PlanItem_manager",  "Membership_SeparateMember",  "Membership_RestoreVersion",  "Membership_ComparedVersion",  "Membership_MembershipVersions",  "Membership_EditFullMembership",  "Membership_CreateFullMembership",  "Membership_DesignReport",  "Membership_Hold",  "Membership_UnFreeze",  "Membership_Freeze",  "Membership_Delete",  "Membership_RejectMemberShip",  "Membership_ApprovalStatus",  "Membership_ActivateMembership",  "Membership_editGenerateReport",  "Membership_GenerateReport",  "Membership_Details",  "SportMembership_edit",  "SportMembership_add",  "HonoraryMembership_edit",  "HonoraryMembership_add",  "SeasonalMembership_add",  "SeasonalMembership_edit",  "Membership_edit",  "Membership_add",  "InActiveMemebrship_manager",  "Sport_manager",  "Seasonal_manager",  "Honary_manager",  "Membership_manager",  "Application_edit",  "Application_manager",  "Application_add",  "Application_ScheduleMeeting",  "Application_RejectScheduleMeeting",  "Application_AcceptingMeetingBeforeItsDate",  "Application_GenerateMembership",  "Member_GetComparedVersion",  "Member_MemberVersions",  "Member_CardPrintPreview",  "Member_CardRequest",  "Member_Hold",  "Member_UnFreeze",  "Member_Freeze",  "Member_DeleteAttachment",  "Member_PassawayMember",  "Member_TransaferMember",  "Member_EditSubmember",  "Member_CreateSubmember",  "Member_Details",  "Member_RestoreVersion",  "Member_MemberVersion",  "Member_EditMember",  "Member_addSubMember",  "Member_manager",  "UserManager_Manager",  "UserPermission_Manager",  "UserPermission_AssignUserPermission",  "Country_delete",  "Country_update",  "Country_add",  "Country_manager",  "Gender_delete",  "Gender_update",  "Gender_add",  "Gender_manager",  "City_delete",  "City_update",  "City_add",  "City_manager",  "InstallmentPlan_delete",  "InstallmentPlan_update",  "InstallmentPlan_add",  "InstallmentPlan_manager",  "AttachmentCategorires_delete",  "AttachmentCategorires_update",  "AttachmentCategorires_add",  "AttachmentCategorires_manager",  "MembershipStatus_delete",  "MembershipStatus_update",  "MembershipStatus_add",  "MembershipStatus_manager",  "SocialStatus_delete",  "SocialStatus_update",  "SocialStatus_add",  "SocialStatus_manager",  "Qualifications_delete",  "Qualifications_update",  "Qualifications_add",  "Qualifications_manager",  "InstallmentType_delete",  "InstallmentType_update",  "InstallmentType_add",  "InstallmentType_manager",  "MembershipType_delete",  "MembershipType_update",  "MembershipType_add",  "MembershipType_manager",  "PaymentPlanItem_delete",  "PaymentPlanItem_update",  "PaymentPlanItem_add",  "PaymentPlanItem_manager",  "ReservedMembershipId_delete",  "ReservedMembershipId_add",  "ReservedMembership_manager",  "InstallmentFrequency_Delete",  "InstallmentFrequency_update",  "InstallmentFrequency_add",  "InstallmentFrequency_manager",  "Title_delete",  "Title_update",  "Title_add",  "Title_manager",  "Cheque_update",  "Card_update",  "Reports_tab",  "Attachments_Manager",  "Member_deleteMember",  "SeasonalMembership_Freeze",  "SeasonalMembership_Delete",  "SeasonalMembership_Details",  "SportMembership_Freeze",  "SportMembership_Delete",  "SportMembership_Details",  "HonoraryMembership_Details",  "HonoraryMembership_UnFreeze",  "HonoraryMembership_Delete",  "InActiveMemebrship_Delete",  "InActiveMemebrship_edit",  "InActiveMemebrship_Freeze",  "InActiveMemebrship_Details",  "InActiveMemebrship_UnFreeze",  "BouncedChequeReason_delete",  "BouncedChequeReason_update",  "BouncedChequeReason_add",  "BouncedChequeReason_manager",  "HonoraryMembership_Freeze",  "SportMembership_UnFreeze",  "SeasonalMembership_UnFreeze",  "BankAccount_add",  "BankAccount_update",  "BankAccount_manager",  "Bank_add",  "Bank_update",  "Bank_manager",  "Bank_delete",  "Contract_BulkActions",  "Financial_Configuration",  "MembershipPlan_update",  "MembershipPlan_delete",  "ChequeRejectionReason_manager",  "ChequeRejectionReason_update",  "ChequeRejectionReason_add",  "GLAccount_Manager",  "GLAccount_Add",  "GLAccount_Update",  "MembershipPlan_Manager",  "MembershipPlan_Add",  "MembershipInstallment_Manager",  "Membership_ReviewInstallments",  "Membership_Cheques",  "MembershipInstallment_pay",  "Transaction_Manager",  "AddTransaction",  "PaymentCodes_Manager",  "PaymentCodes_Add",  "PaymentCodes_Update",  "PaymentCodes_Delete",  "ChequeDataMigration_manager",  "Receipt_Manager",  "Receipt_pay",  "MembershipPayment_Manager",  "Receipt_Details",  "Receipt_Index",  "GLAccount_Setting",  "GLTransaction_Manager",  "GLTransaction_Details",  "MembershipInstallment_CaclulateInstallmentIntrest",  "Cheque_chequeHistory",  "MembershipInstallment_InstallmentChequeGenerate",  "SafeBox_Manager",  "SafeBox_Add",  "SafeBox_Update",  "SafeBox_Delete",  "Application_Deposit",  "CollectionPercentage_Manager",  "CollectionPercentage_Add",  "CollectionPercentage_Update",  "CollectionPercentage_Delete",  "OwnershipType_Manager",  "OwnershipType_Add",  "OwnershipType_Update",  "OwnershipType_Delete",  "Contract_Soclearence",  "Contract_Arclearence",  "Contract_CollectionPercentageClearance",  "CancelingMembership_Manager",  "CancelingMembership_CancelingApproval",  "Document_downloadDocument",  "Document_Add",  "Document_Edit",  "Document_Delete",  "Document_Manager",  "DailyTasks_addAction",  "DailyTasks_delete",  "DailyTasks_addTask",  "DailyTasks_Manager",  "DailyTaskCategory_manager",  "DailyTaskCategory_add",  "DailyTaskCategory_update",  "DailyTaskCategory_delete",  "Application_Details",  "FreezeReason_manager",  "FreezeReason_update",  "FreezeReason_add",  "GLTransaction_Add",  "GLTransaction_edit",  "GLTransaction_delete",  "BankAccount_transfer",  "Nationality_manager",  "Nationality_update",  "Nationality_add",  "Nationality_delete",  "PaymentServices_Update",  "PaymentServices_manager",  "Admin_Separate",  "VirtualMembership_Manager",  "VirtualMembership_Details",  "VirtualMembership_Edit",  "AuditTrail_Index",  "AuditTrail_ViewDetails",  "FinancialReports_Manager",  "GLTransaction_Export",  "Application_Export",  "MemberShip_Export",  "InActiveMemebrshipManager_Export",  "Canceling_Export",  "HonoraryMemberships_Export",  "SportMemberships_Export",  "SeasonalMemberships_Export",  "VirtualMemberships_Export",  "Member_Export",  "Receipt_Export",  "Cheque_Export",  "MembershipPlan_Export",  "BankTransaction_Export",  "MembershipInstallment_Export",  "GLAccount_Export",  "MemberhshipPayment_Export",  "MembershipPlan_approve",  "Court_Manager",  "Court_Add",  "Court_Delete",  "Court_Edit",  "Amenity_Edit",  "Amenity_Delete",  "Amenity_Insert",  "Amenity_Manager",  "Court_Info",  "Coach_Info",  "Academy_Info",  "Gym_Info",  "ResourcePrice_manager",  "ResourcePrice_add",  "ResourcePrice_edit",  "ResourcePrice_delete",  "Academy_manager",  "Academy_add",  "Academy_edit",  "Academy_delete",  "Package_manager",  "Package_add",  "Package_edit",  "Package_delete",  "Package_details",  "PackageEntry_add",  "PackageEntry_edit",  "PackageEntry_delete",  "Reception_manager",  "Gym_reception",  "Academy_reception",  "Court_reception",  "Activity_reception",  "Club_Manager",  "Club_add",  "Club_edit",  "Club_delete",  "ClubAmenity_Manager",  "ClubAmenity_edit",  "ClubAmenity_delete",  "UserClub_manager",  "UserClub_add",  "UserClub_edit",  "UserClub_delete",  "Gym_manager",  "Gym_add",  "Gym_edit",  "Gym_delete",  "Coach_manager",  "Coach_add",  "Coach_edit",  "Coach_delete",  "Sport_add",  "Sport_edit",  "Sport_delete",  "BlackoutSchedule_Manager",  "BlackoutSchedule_Add",  "BlackoutSchedule_Edit",  "BlackoutSchedule_Delete",  "Team_manager",  "Team_add",  "Team_edit",  "Team_delete",  "Squad_manager",  "Squad_add",  "Squad_edit",  "Squad_delete",  "Player_manager",  "Player_add",  "Player_edit",  "Player_delete",  "Squad_details",  "Assessment_manager",  "Assessment_add",  "Assessment_edit",  "Assessment_delete",  "AssessmentApplication_manager",  "AssessmentApplication_add",  "AssessmentApplication_edit",  "Assessment_info",  "Tournament_add",  "Tournament_manager",  "Tournament_edit",  "Tournament_delete",  "InvitationType_manager",  "InvitationType_add",  "InvitationType_edit",  "InvitationType_delete",  "InvitationPackage_manager",  "InvitationPackage_add",  "InvitationPackage_edit",  "InvitationPackage_delete",  "InvitationBalance_manager",  "InvitationBalance_add",  "InvitationBalance_delete",  "Subscription_freeze",  "Subscription_edit",  "Tournament_Details",  "Stage_Add",  "Stage_Edit",  "Stage_Manager",  "Stage_Placement",  "TournamentParticipant_Add",  "TournamentParticipant_Edit",  "TournamentParticipant_Manager",  "Match_Add",  "Match_Edit",  "Match_Manager",  "Client_manager",  "Client_Add",  "Client_Edit",  "Client_Details",  "Client_Delete",
        };

        string sourceFolder = @"E:\Project\Github\ZedClubCRM\ZedClubCRM\Views\Shared\Partials";
        foreach (var file in Directory.GetFiles(sourceFolder, "*.cshtml", SearchOption.TopDirectoryOnly))
        {
            try
            {
                string content = File.ReadAllText(file);
                foreach (var val in values)
                {
                    try
                    {
                        string safeId = val.Replace(" ", "");
                        content.Replace($"\"{val}\"", $"PermissionNames.{safeId}Code");

                        // Replace: [PermissionAttribute("Academy_delete", 
                        // With:    [PermissionAttribute(PermissionNames.Academy_delete,
                        content = content.Replace(
                            $"PermissionAttribute(\"{val}\"",
                            $"PermissionAttribute(PermissionNames.{val}Code"
                        );
                        if (content.Contains("PermissionAttribute(PermissionNames."))
                        {
                            string pattern = @"var\s+listOfPermission\s*=\s*User\.Claims\.Where\(x\s*=>\s*x\.Value\.Contains\(""(?<keyword>[^""]+)""\)\)\.Select\(x\s*=>\s*x\.Value\)\.ToList\(\);";
                            var match = Regex.Match(content, pattern);
                            if (!match.Success)
                            {
                                content = "using ZedClubCRM.Domain.Enum;\n" + content;
                            }
                        }
                        File.WriteAllText(file, content);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                continue;
            }
        }
    }

    public static void replacePremissionInNavBar()
    {
        string[] values =
        {
                "Edit Membership",  "DeleteMemberShip",  "ManagePlan",  "CreatePlan",  "ClonePlan",  "DeletePlan",  "ManageUsers",  "AssignUserPermission",  "AssignRolePermission",  "ManageInactiveUsers",  "OverDueChildSeparation",  "HandicappedChild",  "MemberHistory",  "MemeberDetails",  "OverDue",  "InActiveMemberShips",  "MembershipHistory",  "MainMemberShip",  "HonorMemberShip",  "SeasonalMemberShip",  "MemberShipDetails",  "SportMemberShip",  "ManageMember",  "CreateMember",  "EditMember",  "SuspendMember",  "UnSuspendMember",  "DeleteMember",  "GetAttachments",  "EditPlan",  "InvoiceManager",  "MemberDetails",  "AddSubMember",  "PaymentReport",  "LogReport",  "Penalty_manager",  "Penalty_Add",  "Cheque_add",  "Cheque_manager",  "TaxConfig_add",  "TaxConfig_manager",  "TaxConfig_delete",  "TaxConfig_edit",  "Cheque_delete",  "Card_manager",  "Card_details",  "Penalty_edit",  "Plan_delete",  "Plan_edit",  "Plan_clone",  "Plan_add",  "Plan_manager",  "DataMigration_manager",  "Contract_details",  "Contract_delete",  "Contract_edit",  "Contract_add",  "Contract_manager",  "PlanItem_delete",  "PlanItem_edit",  "PlanItem_add",  "PlanItem_manager",  "Membership_SeparateMember",  "Membership_RestoreVersion",  "Membership_ComparedVersion",  "Membership_MembershipVersions",  "Membership_EditFullMembership",  "Membership_CreateFullMembership",  "Membership_DesignReport",  "Membership_Hold",  "Membership_UnFreeze",  "Membership_Freeze",  "Membership_Delete",  "Membership_RejectMemberShip",  "Membership_ApprovalStatus",  "Membership_ActivateMembership",  "Membership_editGenerateReport",  "Membership_GenerateReport",  "Membership_Details",  "SportMembership_edit",  "SportMembership_add",  "HonoraryMembership_edit",  "HonoraryMembership_add",  "SeasonalMembership_add",  "SeasonalMembership_edit",  "Membership_edit",  "Membership_add",  "InActiveMemebrship_manager",  "Sport_manager",  "Seasonal_manager",  "Honary_manager",  "Membership_manager",  "Application_edit",  "Application_manager",  "Application_add",  "Application_ScheduleMeeting",  "Application_RejectScheduleMeeting",  "Application_AcceptingMeetingBeforeItsDate",  "Application_GenerateMembership",  "Member_GetComparedVersion",  "Member_MemberVersions",  "Member_CardPrintPreview",  "Member_CardRequest",  "Member_Hold",  "Member_UnFreeze",  "Member_Freeze",  "Member_DeleteAttachment",  "Member_PassawayMember",  "Member_TransaferMember",  "Member_EditSubmember",  "Member_CreateSubmember",  "Member_Details",  "Member_RestoreVersion",  "Member_MemberVersion",  "Member_EditMember",  "Member_addSubMember",  "Member_manager",  "UserManager_Manager",  "UserPermission_Manager",  "UserPermission_AssignUserPermission",  "Country_delete",  "Country_update",  "Country_add",  "Country_manager",  "Gender_delete",  "Gender_update",  "Gender_add",  "Gender_manager",  "City_delete",  "City_update",  "City_add",  "City_manager",  "InstallmentPlan_delete",  "InstallmentPlan_update",  "InstallmentPlan_add",  "InstallmentPlan_manager",  "AttachmentCategorires_delete",  "AttachmentCategorires_update",  "AttachmentCategorires_add",  "AttachmentCategorires_manager",  "MembershipStatus_delete",  "MembershipStatus_update",  "MembershipStatus_add",  "MembershipStatus_manager",  "SocialStatus_delete",  "SocialStatus_update",  "SocialStatus_add",  "SocialStatus_manager",  "Qualifications_delete",  "Qualifications_update",  "Qualifications_add",  "Qualifications_manager",  "InstallmentType_delete",  "InstallmentType_update",  "InstallmentType_add",  "InstallmentType_manager",  "MembershipType_delete",  "MembershipType_update",  "MembershipType_add",  "MembershipType_manager",  "PaymentPlanItem_delete",  "PaymentPlanItem_update",  "PaymentPlanItem_add",  "PaymentPlanItem_manager",  "ReservedMembershipId_delete",  "ReservedMembershipId_add",  "ReservedMembership_manager",  "InstallmentFrequency_Delete",  "InstallmentFrequency_update",  "InstallmentFrequency_add",  "InstallmentFrequency_manager",  "Title_delete",  "Title_update",  "Title_add",  "Title_manager",  "Cheque_update",  "Card_update",  "Reports_tab",  "Attachments_Manager",  "Member_deleteMember",  "SeasonalMembership_Freeze",  "SeasonalMembership_Delete",  "SeasonalMembership_Details",  "SportMembership_Freeze",  "SportMembership_Delete",  "SportMembership_Details",  "HonoraryMembership_Details",  "HonoraryMembership_UnFreeze",  "HonoraryMembership_Delete",  "InActiveMemebrship_Delete",  "InActiveMemebrship_edit",  "InActiveMemebrship_Freeze",  "InActiveMemebrship_Details",  "InActiveMemebrship_UnFreeze",  "BouncedChequeReason_delete",  "BouncedChequeReason_update",  "BouncedChequeReason_add",  "BouncedChequeReason_manager",  "HonoraryMembership_Freeze",  "SportMembership_UnFreeze",  "SeasonalMembership_UnFreeze",  "BankAccount_add",  "BankAccount_update",  "BankAccount_manager",  "Bank_add",  "Bank_update",  "Bank_manager",  "Bank_delete",  "Contract_BulkActions",  "Financial_Configuration",  "MembershipPlan_update",  "MembershipPlan_delete",  "ChequeRejectionReason_manager",  "ChequeRejectionReason_update",  "ChequeRejectionReason_add",  "GLAccount_Manager",  "GLAccount_Add",  "GLAccount_Update",  "MembershipPlan_Manager",  "MembershipPlan_Add",  "MembershipInstallment_Manager",  "Membership_ReviewInstallments",  "Membership_Cheques",  "MembershipInstallment_pay",  "Transaction_Manager",  "AddTransaction",  "PaymentCodes_Manager",  "PaymentCodes_Add",  "PaymentCodes_Update",  "PaymentCodes_Delete",  "ChequeDataMigration_manager",  "Receipt_Manager",  "Receipt_pay",  "MembershipPayment_Manager",  "Receipt_Details",  "Receipt_Index",  "GLAccount_Setting",  "GLTransaction_Manager",  "GLTransaction_Details",  "MembershipInstallment_CaclulateInstallmentIntrest",  "Cheque_chequeHistory",  "MembershipInstallment_InstallmentChequeGenerate",  "SafeBox_Manager",  "SafeBox_Add",  "SafeBox_Update",  "SafeBox_Delete",  "Application_Deposit",  "CollectionPercentage_Manager",  "CollectionPercentage_Add",  "CollectionPercentage_Update",  "CollectionPercentage_Delete",  "OwnershipType_Manager",  "OwnershipType_Add",  "OwnershipType_Update",  "OwnershipType_Delete",  "Contract_Soclearence",  "Contract_Arclearence",  "Contract_CollectionPercentageClearance",  "CancelingMembership_Manager",  "CancelingMembership_CancelingApproval",  "Document_downloadDocument",  "Document_Add",  "Document_Edit",  "Document_Delete",  "Document_Manager",  "DailyTasks_addAction",  "DailyTasks_delete",  "DailyTasks_addTask",  "DailyTasks_Manager",  "DailyTaskCategory_manager",  "DailyTaskCategory_add",  "DailyTaskCategory_update",  "DailyTaskCategory_delete",  "Application_Details",  "FreezeReason_manager",  "FreezeReason_update",  "FreezeReason_add",  "GLTransaction_Add",  "GLTransaction_edit",  "GLTransaction_delete",  "BankAccount_transfer",  "Nationality_manager",  "Nationality_update",  "Nationality_add",  "Nationality_delete",  "PaymentServices_Update",  "PaymentServices_manager",  "Admin_Separate",  "VirtualMembership_Manager",  "VirtualMembership_Details",  "VirtualMembership_Edit",  "AuditTrail_Index",  "AuditTrail_ViewDetails",  "FinancialReports_Manager",  "GLTransaction_Export",  "Application_Export",  "MemberShip_Export",  "InActiveMemebrshipManager_Export",  "Canceling_Export",  "HonoraryMemberships_Export",  "SportMemberships_Export",  "SeasonalMemberships_Export",  "VirtualMemberships_Export",  "Member_Export",  "Receipt_Export",  "Cheque_Export",  "MembershipPlan_Export",  "BankTransaction_Export",  "MembershipInstallment_Export",  "GLAccount_Export",  "MemberhshipPayment_Export",  "MembershipPlan_approve",  "Court_Manager",  "Court_Add",  "Court_Delete",  "Court_Edit",  "Amenity_Edit",  "Amenity_Delete",  "Amenity_Insert",  "Amenity_Manager",  "Court_Info",  "Coach_Info",  "Academy_Info",  "Gym_Info",  "ResourcePrice_manager",  "ResourcePrice_add",  "ResourcePrice_edit",  "ResourcePrice_delete",  "Academy_manager",  "Academy_add",  "Academy_edit",  "Academy_delete",  "Package_manager",  "Package_add",  "Package_edit",  "Package_delete",  "Package_details",  "PackageEntry_add",  "PackageEntry_edit",  "PackageEntry_delete",  "Reception_manager",  "Gym_reception",  "Academy_reception",  "Court_reception",  "Activity_reception",  "Club_Manager",  "Club_add",  "Club_edit",  "Club_delete",  "ClubAmenity_Manager",  "ClubAmenity_edit",  "ClubAmenity_delete",  "UserClub_manager",  "UserClub_add",  "UserClub_edit",  "UserClub_delete",  "Gym_manager",  "Gym_add",  "Gym_edit",  "Gym_delete",  "Coach_manager",  "Coach_add",  "Coach_edit",  "Coach_delete",  "Sport_add",  "Sport_edit",  "Sport_delete",  "BlackoutSchedule_Manager",  "BlackoutSchedule_Add",  "BlackoutSchedule_Edit",  "BlackoutSchedule_Delete",  "Team_manager",  "Team_add",  "Team_edit",  "Team_delete",  "Squad_manager",  "Squad_add",  "Squad_edit",  "Squad_delete",  "Player_manager",  "Player_add",  "Player_edit",  "Player_delete",  "Squad_details",  "Assessment_manager",  "Assessment_add",  "Assessment_edit",  "Assessment_delete",  "AssessmentApplication_manager",  "AssessmentApplication_add",  "AssessmentApplication_edit",  "Assessment_info",  "Tournament_add",  "Tournament_manager",  "Tournament_edit",  "Tournament_delete",  "InvitationType_manager",  "InvitationType_add",  "InvitationType_edit",  "InvitationType_delete",  "InvitationPackage_manager",  "InvitationPackage_add",  "InvitationPackage_edit",  "InvitationPackage_delete",  "InvitationBalance_manager",  "InvitationBalance_add",  "InvitationBalance_delete",  "Subscription_freeze",  "Subscription_edit",  "Tournament_Details",  "Stage_Add",  "Stage_Edit",  "Stage_Manager",  "Stage_Placement",  "TournamentParticipant_Add",  "TournamentParticipant_Edit",  "TournamentParticipant_Manager",  "Match_Add",  "Match_Edit",  "Match_Manager",  "Client_manager",  "Client_Add",  "Client_Edit",  "Client_Details",  "Client_Delete",
        };

        string content = File.ReadAllText(@"E:\Project\Github\\ZedClubCRM\ZedClubCRM\Views\Shared\Partials\_menuNavNew.cshtml");

        foreach (var val in values)
        {
            string safeId = val.Replace(" ", "");

            // 1️⃣ Replace "Permission Name" → PermissionNames.PermissionNameCode
            //content = content.Replace($"\"{val.ToLower()}\"", $"PermissionNames.{safeId}Code.ToLower()");
            //content = content.Replace($"\"{val}\"", $"PermissionNames.{safeId}Code");

            // 2️⃣ Replace PermissionAttribute("X", → PermissionAttribute(PermissionNames.X,
            //content = content.Replace(
            //    $"PermissionAttribute(\"{val}\"",
            //    $"PermissionAttribute(PermissionNames.{safeId}"
            //);

            // 3️⃣ Replace claims checking: User.Claims.Any(s => s.Value == "X")
            //content = content.Replace(
            //    $"User.Claims.Any(s => s.Value == \"{val}\")",
            //    $"User.Claims.Any(s => s.Value == PermissionNames.{safeId})"
            //);
            //content = content.Replace(
            //    $"User.Claims.Any(s => s.Value.ToLower() == \"{val.ToLower()}\")",
            //    $"User.Claims.Any(s => s.Value.ToLower() == PermissionNames.{safeId.ToLower()})"
            //);

            //// 4️⃣ Replace inverse dictionary keys if any exist
            //content = content.Replace(
            //    $"{{ {safeId}, {safeId}Code }}",
            //    $"{{ \"{safeId}\", {safeId}Code }}"
            //);
        }

        File.WriteAllText(@"E:\Project\Github\\ZedClubCRM\ZedClubCRM\Views\Shared\Partials\_menuNavNew.cshtml", content);

    }

    public static void ReplacePermissionViews()
    {
        string sourceFolder = @"E:\Project\Github\ZedClubCRM\ZedClubCRM\Views\";

        foreach (var file in Directory.GetFiles(sourceFolder, "*.cshtml", SearchOption.AllDirectories)) try
            {
                {

                    string content = File.ReadAllText(file);

                    // Match the old listOfPermission pattern and capture the dynamic keyword inside Contains("...")
                    string pattern = @"var\s+listOfPermission\s*=\s*User\.Claims\.Where\(x\s*=>\s*x\.Value\.Contains\(""(?<keyword>[^""]+)""\)\)\.Select\(x\s*=>\s*x\.Value\)\.ToList\(\);";

                    var match = Regex.Match(content, pattern);
                    if (!match.Success)
                    {
                        continue;
                    }

                    string keyword = match.Groups["keyword"].Value;

                    // Build the replacement code
                    string replacement = $@"var listOfPermission = User.Claims
    .Select(c => PermissionNames.permissions.GetValueOrDefault(c.Value))
    .Where(p => !string.IsNullOrEmpty(p) && p.Contains(""{keyword}""))
    .Select(p => p.Replace(""{keyword}_"" , """"))
    .ToList();";

                    // Replace in the file content
                    content = Regex.Replace(content, pattern, replacement);

                    // Write the updated content back to the file
                    File.WriteAllText(file, content);

                    Console.WriteLine($"Updated file: {file}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {file}: {ex.Message}");
                continue;
            }

        Console.WriteLine("Done!");
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
