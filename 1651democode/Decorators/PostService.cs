using System.Collections.Generic;
using System.Linq;
using _1651democode.Models;

namespace _1651democode.Services
{
    public class PostService
    {
        private readonly List<Post> _posts = new();

        public void AddPost(Post post) => _posts.Add(post);

        public List<Post> GetAllPosts() => new List<Post>(_posts);

        public List<Post> GetPostsByAuthor(string author) =>
            _posts.Where(p => p.Author == author).ToList();

        public Post GetPostById(int id) => _posts.FirstOrDefault(p => p.Id == id);

        public void DeletePost(Post post) => _posts.Remove(post);
    }
}
