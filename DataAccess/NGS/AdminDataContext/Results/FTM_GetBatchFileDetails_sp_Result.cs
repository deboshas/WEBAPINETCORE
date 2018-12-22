using System;

namespace NGS.DataContext
{
    public class FTM_GetBatchFileDetails_sp_Result
    {
        public int BatchId { get; set; }

        public Guid UploadId { get; set; }

        public string BatchFileName { get; set; }

        public decimal? FileSizeKB { get; set; }

        public DateTime UploadedOn { get; set; }

        public string UploadedBy { get; set; }

        public DateTime? ProcessStartedAt { get; set; }

        public DateTime? ProcessCompletedAt { get; set; }

        public int? RecordCount { get; set; }

        public string Status { get; set; }

        public int? Processed { get; set; }

        public int? Successful { get; set; }
    }
}