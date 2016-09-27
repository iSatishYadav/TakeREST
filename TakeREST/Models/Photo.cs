using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeREST.Models
{
    public class Photo
    {
        public int AblumID { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}