namespace _1651democode.Display
{
    public abstract class PostDecorator : IPostDisplay
    {
        protected readonly IPostDisplay _postDisplay;

        protected PostDecorator(IPostDisplay postDisplay)
        {
            _postDisplay = postDisplay;
        }

        public virtual string GetContent() => _postDisplay.GetContent();

        public virtual string GetSummary() => _postDisplay.GetSummary();

        public virtual string GetPreview() => _postDisplay.GetPreview();
    }
}
