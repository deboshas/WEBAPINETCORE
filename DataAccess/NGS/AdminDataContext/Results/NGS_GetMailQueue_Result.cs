using System;

namespace NGS.DataContext
{
    public class NGS_GetMailQueue_Result
    {
        public int Id { get; set; }

        public string MailBody { get; set; }

        public string MailFrom { get; set; }

        public string MailTo { get; set; }

        public string Subject { get; set; }

        public string Duns { get; set; }

        public string DunsName { get; set; }

        public string ParentName { get; set; }

        public string Gup { get; set; }

        public string GupName { get; set; }

        public string CountryName { get; set; }

        public int? MailType2 { get; set; }

        public int? MailType3 { get; set; }

        public int? MailType4 { get; set; }

        public int? MailType5 { get; set; }

        public int? MailType6 { get; set; }

        public int? MailType7 { get; set; }

        public string Processed { get; set; }

        public string Mailccto { get; set; }

        public string Mailbccto { get; set; }

        public string FileAttachment { get; set; }
    }
}
