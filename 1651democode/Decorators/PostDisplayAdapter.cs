using _1651democode.Models;

namespace _1651democode.Display
{
    public class PostDisplayAdapter : IPostDisplay
    {
        private readonly Post _post;

        public PostDisplayAdapter(Post post)
        {
            _post = post;
        }

        public string GetContent() => _post.Content;

        public string GetSummary() => $"[{_post.Id}] {_post.Title} by {_post.Author}";

        public string GetPreview()
        {
            if (_post.Content.Length <= 30)
                return _post.Content;
            return _post.Content.Substring(0, 30) + "...";
        }
    }
}
