namespace NGS.DataContext
{
    public partial class NGS_GetAffiliateGroupsByAffiliateType_Result
    {
        public int AffiliateTypeId { get; set; }

        public int AffiliateGroupId { get; set; }

        public string Description { get; set; }

        public int? RenderTreeProcess { get; set; }
    }
}