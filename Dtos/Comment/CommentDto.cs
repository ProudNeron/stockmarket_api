using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SimpleAPI.Constants.CommentConstant;

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
        public int? StockId { get; set; }
        
    }
}