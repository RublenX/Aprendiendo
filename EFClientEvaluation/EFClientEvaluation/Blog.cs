using System;

namespace EFClientEvaluation
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int? Rating { get; set; }
        public DateTime? DeleteDateTime { get; set; }
    }
}
