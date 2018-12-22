namespace NGS.DataContext
{
    public partial class NGS_GetAffiliateTypeRule_Result
    {
        public int AffiliateTypeRuleId { get; set; }

        public int RuleMatrixId { get; set; }

        public int AffiliateTypeId { get; set; }

        public int RuleId { get; set; }

        public int StepId { get; set; }

        public int SubStepId { get; set; }

        public string RuleValue { get; set; }

        public int? RenderStartPosition { get; set; }

        public bool IsApplicable { get; set; }

        public int? ReferenceAffliateTypeRuleId { get; set; }

        public string RuleName { get; set; }
    }
}