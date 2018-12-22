using System;

namespace NGS.DataContext
{
    public partial class NGS_GetRule_Result
    {
        public int RuleId { get; set; }

        public string RuleName { get; set; }

        public string RuleDescription { get; set; }

        public bool IsActive { get; set; }

        public int RuleType { get; set; }

        public int RuleDataType { get; set; }

        public bool? IsMandatory { get; set; }
        
        public int? ModifiedById { get; set; }

        public string ModifiedByFirstName { get; set; }

        public string ModifiedByLastName { get; set; }

        public string ModifiedDisplayName { get; set; }

        public string ModifiedByEmail { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}