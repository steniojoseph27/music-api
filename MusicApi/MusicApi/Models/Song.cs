using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be null or empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Language cannot be null or empty")]
        public string Duration { get; set; }
        public DateTime UploadedDate { get; set; }
        public bool isFeatured { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile AudioFile { get; set; }
        public string AudioUrl { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
    }
}
