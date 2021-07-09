using System.ComponentModel.DataAnnotations;

namespace FileValidationService.Models
{
    public class RequestModel
    {
        [Required]
        public string filePath { get; set; }

        [Required]
        public string configPath { get; set; }
    }
}