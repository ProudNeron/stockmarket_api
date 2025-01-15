using System.ComponentModel.DataAnnotations;
using static SimpleAPI.Constants.CommentConstants;

namespace SimpleAPI.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(MinLengthTitle, ErrorMessage = MinTitleErrorMesssage)]
        [MaxLength(MaxLengthTitle, ErrorMessage = MaxTitleErrorMesssage)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(MinLengthContent, ErrorMessage = MinContentErrorMesssage)]
        [MaxLength(MaxLengthContent, ErrorMessage = MaxContentErrorMesssage)]
        public string Content { get; set;} = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set;} = string.Empty;
        public int? StockId { get; set; }
        
    }
}