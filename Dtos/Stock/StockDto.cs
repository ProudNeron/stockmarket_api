using System.ComponentModel.DataAnnotations;
using SimpleAPI.Dtos.Comment;
using static SimpleAPI.Constants.StockConstants;

namespace SimpleAPI.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(MinLengthSymbol, ErrorMessage = MinErrorMessageSymbol)]
        [MaxLength(MaxLengthSymbol, ErrorMessage = MaxErrorMessageSymbol)]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(MinLengthCompanyName, ErrorMessage = MinErrorMessageCompanyName)]
        [MaxLength(MaxLengthCompanyName, ErrorMessage = MaxErrorMessageCompanyName)]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(MinPurchase, MaxPurchase, ErrorMessage = ErrorMessagePurchase)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(MinLastDiv, MaxLastDiv, ErrorMessage = ErrorMessageLastDiv)]
        public decimal LastDiv { get; set; }
        [Required]
        [MinLength(MinLengthIndustry, ErrorMessage = MinErrorMessageIndustry)]
        [MaxLength(MaxLengthIndustry, ErrorMessage = MaxErrorMessageIndustry)]
        public string Industry { get; set; } = string.Empty;
        [Required]
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}