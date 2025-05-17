using System;

namespace _1651democode.Models
{
    public class Post
    {
        private static int _globalId = 1;

        public int Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public Post(string title, string content, string author)
        {
            Id = _globalId++;
            Title = title;
            Content = content;
            Author = author;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string newTitle, string newContent)
        {
            Title = newTitle;
            Content = newContent;
            UpdatedAt = DateTime.Now;
        }
    }
}
