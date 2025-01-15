namespace SimpleAPI.Constants
{
    public static class CommentConstants
    {
        public const int MinLengthTitle = 1;
        public const int MaxLengthTitle = 200;
        public const string MinTitleErrorMesssage = "Title is at least 1 characters";
        public const string MaxTitleErrorMesssage = "Title can't be more than 200 characters";
        public const int MinLengthContent = 2;
        public const int MaxLengthContent = 300;
        public const string MinContentErrorMesssage = "Content is at least 2 characters";
        public const string MaxContentErrorMesssage = "Content can't be more than 300 characters";
    }

}