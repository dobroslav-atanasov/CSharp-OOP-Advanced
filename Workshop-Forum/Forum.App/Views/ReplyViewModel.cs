namespace Forum.App.Views
{
    using Contracts;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string content) 
            : base(content)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}