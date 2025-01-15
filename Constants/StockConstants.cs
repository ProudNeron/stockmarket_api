namespace SimpleAPI.Constants
{
    public static class StockConstants
    {
        public const int MinLengthSymbol = 3;
        public const int MaxLengthSymbol = 280;
        public const string MinErrorMessageSymbol = "Symbol must be at least 5 characters";
        public const string MaxErrorMessageSymbol = "Symbol can't be more than 280 characters";
        public const int MinLengthCompanyName = 3;
        public const int MaxLengthCompanyName = 280;
        public const string MinErrorMessageCompanyName = "CompanyName must be at least 3 characters";
        public const string MaxErrorMessageCompanyName = "CompanyName can't be more than 280 characters";
        public const double MinPurchase = 1;
        public const double MaxPurchase = 100000;
        public const string ErrorMessagePurchase = "the value of Purchase out of the range";
        public const double MinLastDiv = 1;
        public const double MaxLastDiv = 100000;
        public const string ErrorMessageLastDiv = "the value of Purchase out of the range";
        public const int MinLengthIndustry = 3;
        public const int MaxLengthIndustry = 200;
        public const string MinErrorMessageIndustry = "Industry is at least 3 characters";
        public const string MaxErrorMessageIndustry = "Industry can't be more than 200 characters";
    }
}