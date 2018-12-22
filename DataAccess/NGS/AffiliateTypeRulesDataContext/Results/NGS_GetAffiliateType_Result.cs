namespace NGS.DataContext
{
    public partial class NGS_GetAffiliateType_Result
    {
        public int AffiliateTypeId { get; set; }

        public string AffiliateTypeCode { get; set; }

        public string AffiliateTypeName { get; set; }

        public bool IsActive { get; set; }

        public bool InProduction { get; set; }

        public bool InWIP { get; set; }

        public int DisplayOrder { get; set; }

        public int Rank { get; set; }

        public int ModifiedById { get; set; }

        public string ModifiedByFirstName { get; set; }

        public string ModifiedByLastName { get; set; }

        public string ModifiedByDisplayName { get; set; }

        public string ModifiedByEmail { get; set; }

        public System.DateTime LastModifiedDate { get; set; }

        public bool? AffliateTypeConfigured { get; set; }

        public bool? TreeRulesConfigured { get; set; }

        public bool? RenderTreeRulesConfigured { get; set; }

        public int? ApprovalRulesConfigured { get; set; }

        public bool? ConflictRulesConfigured { get; set; }

        public bool CanGenerateConflicts { get; set; }

        public string AffiliateTypeAliasCode { get; set; }

        public int OrganizationType { get; set; }

        public string DisplayCode { get; set; }

        public string HexColorCode { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }
    }
}