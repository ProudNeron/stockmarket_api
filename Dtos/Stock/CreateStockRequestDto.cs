using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static simple_api.Constants.StockConstants;

namespace simple_api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
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
    }
}