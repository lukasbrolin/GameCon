using System;

namespace DatingSite.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string SiteMessage { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
