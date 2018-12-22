namespace NGS.DataContext
{
    public class NGS_GetSLPDelegates_Result
    {
        public int KeyClientId { get; set; }

        public string SKCName { get; set; }

        public int ApprovalId { get; set; }

        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool? IsActive { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? OfficeId { get; set; }

        public string City { get; set; }

        public string OfficeName { get; set; }

        public int? OfficeCountryId { get; set; }

        public string OfficeCountry { get; set; }

        public bool? IsEmailedAA { get; set; }
    }
}
