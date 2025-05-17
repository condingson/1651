using System;
using System.Collections.Generic;
using System.Linq;
using _1651democode.Models;
using _1651democode.Services;

namespace _1651democode.Users
{
    public class Member
    {
        public int Id { get; }
        public string Username { get; }
        protected readonly List<Post> _posts = new();

        public Member(int id, string username)
        {
            Id = id;
            Username = username;
        }

        public virtual void CreatePost(string title, string content, PostService postService)
        {
            var post = new Post(title, content, Username);
            _posts.Add(post);
            postService.AddPost(post);
            Console.WriteLine("Post created.");
        }

        public virtual void EditPost(int postId, string newTitle, string newContent)
        {
            var post = _posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                Console.WriteLine("Post not found or unauthorized.");
                return;
            }
            post.Update(newTitle, newContent);
            Console.WriteLine("Post updated.");
        }

        public virtual void DeletePost(int postId, PostService postService)
        {
            var post = _posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                Console.WriteLine("Post not found or unauthorized.");
                return;
            }
            _posts.Remove(post);
            postService.DeletePost(post);
            Console.WriteLine("Post deleted.");
        }

        public virtual void ViewPosts()
        {
            if (_posts.Count == 0)
            {
                Console.WriteLine("No posts to show.");
                return;
            }
            foreach (var post in _posts)
            {
                Console.WriteLine($"[{post.Id}] {post.Title} (Created: {post.CreatedAt})");
                Console.WriteLine($"Content: {post.Content}\n");
            }
        }

        public Post GetPostById(int id) => _posts.FirstOrDefault(p => p.Id == id);
    }
}
