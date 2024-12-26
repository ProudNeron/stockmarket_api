using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static simple_api.Constants.CommentConstant;

namespace simple_api.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(MinLengthTitle, ErrorMessage = MinTitleErrorMesssage)]
        [MaxLength(MaxLengthTitle, ErrorMessage = MaxTitleErrorMesssage)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(MinLengthContent, ErrorMessage = MinContentErrorMesssage)]
        [MaxLength(MaxLengthContent, ErrorMessage = MaxContentErrorMesssage)]
        public string Content { get; set;} = string.Empty;  
    }
}