namespace NGS.DataContext
{
    public class NGS_GetApprovalDelegates_Result
    {
        public int? ApprovalId { get; set; }

        public int DelegateId { get; set; }

        public int? EntityId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public bool? SLPIsActive { get; set; }

        public string Email { get; set; }

        public string Office { get; set; }

        public bool IsActive { get; set; }

        public string CountryName { get; set; }

        public bool? IsEmailedAA { get; set; }

        public bool IsEmailed { get; set; }

        public bool? EditRequest { get; set; }

        public bool IsServiceReporting { get; set; }
    }
}
