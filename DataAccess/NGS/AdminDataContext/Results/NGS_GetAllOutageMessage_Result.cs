using System;

namespace NGS.DataContext
{
    public class NGS_GetAllOutageMessage_Result
    {
        public string Id { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }

        public bool IsActive { get; set; }

        public DateTime? DateEffective { get; set; }

        public string ExclusionEmails { get; set; }
    }
}