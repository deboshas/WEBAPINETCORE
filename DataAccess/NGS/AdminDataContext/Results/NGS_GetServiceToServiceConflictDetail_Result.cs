namespace NGS.DataContext
{
    public class NGS_GetServiceToServiceConflictDetail_Result
    {
        public int RuleMatrixId { get; set; }

        public short? RulesTypeCode { get; set; }

        public string RulesActionCode { get; set; }

        public short? RationaleCode { get; set; }

        public short? RequestEntityTypeCode { get; set; }

        public string RequestEntityTypeDesc { get; set; }

        public string RequestSubserviceCode { get; set; }

        public string RequestSubServiceShortDesc { get; set; }

        public string RequestSubServiceLongDesc { get; set; }

        public short? ConflictEntityTypeCode { get; set; }

        public string ConflictEntityTypeDesc { get; set; }

        public string ConflictSubserviceCode { get; set; }

        public short? AttributeType { get; set; }

        public short? Attribute { get; set; }

        public string ConflictSubServiceShortDesc { get; set; }

        public string ConflictSubServiceLongDesc { get; set; }
    }
}
