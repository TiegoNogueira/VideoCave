using System;

namespace VC.Services.Models
{
    public class VideoViewModel
    {
        public string Id { get; set; }
        public string Etag { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string IdCanal { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ThumbnailmqUrl { get; set; }
        public string ThumbnailhqUrl { get; set; }
        public int IdCategoria { get; set; }
    }
}