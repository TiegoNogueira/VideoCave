using System.Collections.Generic;

namespace VC.Domain.Models
{
    public class VideoList
    {
        public string Tipo { get; set; }
        public string Etag { get; set; }
        public List<Video> Videos { get; set; }
    }
}