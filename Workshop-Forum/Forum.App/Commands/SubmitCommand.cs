namespace Forum.App.Commands
{
    using System;
    using Contracts;

    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            string replyText = args[0];
            if (string.IsNullOrWhiteSpace(replyText))
            {
                throw new ArgumentException("Text is empty");
            }

            int postId = int.Parse(args[1]);
            int userId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyText, userId);
            return this.session.Back();
        }
    }
}