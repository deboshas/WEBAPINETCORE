namespace NGS.DataContext
{
    public class NGSFTM_GetArchivedRecordDetails_sp_Result
    {
        public string Action { get; set; }

        public string IsSuccessful { get; set; }

        public string Error_Message { get; set; }

        public string Comment { get; set; }

        public int? EntityId { get; set; }

        public string Ref_EntityId { get; set; }

        public string Full_Business_Name { get; set; }

        public string Trade_Style { get; set; }

        public string Second_Trade_Style { get; set; }

        public string Physical_Street_Address { get; set; }

        public string Second_Address_Line { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string State_Abbreviation { get; set; }

        public string Postal_Code { get; set; }

        public string Country { get; set; }

        public string DUNS { get; set; }

        public string FYE_Month { get; set; }

        public string Phone_Number { get; set; }

        public string SIC_Codes { get; set; }

        public int? GUP_EntityId { get; set; }

        public string Ref_GUP_EntityId { get; set; }

        public string GUP_Full_Business_Name { get; set; }

        public string GUP_DUNS { get; set; }

        public string GUP_Country { get; set; }

        public int? Parent_EntityId { get; set; }

        public string Ref_Parent_EntityId { get; set; }

        public string Parent_Full_Business_Name { get; set; }

        public string Parent_DUNS { get; set; }

        public string Parent_Country { get; set; }

        public string Deletion_Reason { get; set; }

        public string Deletion_Comment { get; set; }

        public int? Duplicate_EntityId { get; set; }

        public int? ReplacementEntityId { get; set; }

        public int? New_Parent_EntityId { get; set; }

        public string Affiliate_Type { get; set; }

        public string AP_Title { get; set; }

        public string AP_Relation { get; set; }

        public string Audit_Client_KPMG { get; set; }

        public string PIE_Ind { get; set; }

        public string Listed_Ind { get; set; }

        public string EU_PIE_Ind { get; set; }

        public string Start_Current_AuditTenure { get; set; }

        public string Next_Expected_AuditTender { get; set; }

        public string Required_AuditRotation { get; set; }

        public string KPMGAudit_CoolingOff_Period { get; set; }

        public string Industry_Sector_Code { get; set; }

        public string Client_Status { get; set; }

        public string TreeMasterEmailId { get; set; }

        public string SlpEmailId { get; set; }

        public string KeyClientAttributes { get; set; }

        public string IsProtected { get; set; }

        public string BatchFileName { get; set; }
    }
}