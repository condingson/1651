using System;
using System.Collections.Generic;
using _1651democode.Models;
using _1651democode.Services;

namespace _1651democode.Users
{
    public class Manager : Member
    {
        private readonly PostService _postService;

        public Manager(int id, string username, PostService postService) : base(id, username)
        {
            _postService = postService;
        }

        public void ViewAllPosts()
        {
            var allPosts = _postService.GetAllPosts();
            if (allPosts.Count == 0)
            {
                Console.WriteLine("No posts in system.");
                return;
            }

            foreach (var post in allPosts)
            {
                Console.WriteLine($"[{post.Id}] {post.Title} by {post.Author} (Created: {post.CreatedAt})");
                Console.WriteLine($"Content: {post.Content}\n");
            }
        }

        public void ModeratePost(int postId)
        {
            var post = _postService.GetPostById(postId);
            if (post == null)
            {
                Console.WriteLine("Post not found.");
                return;
            }

            Console.WriteLine($"[MODERATE] Post #{post.Id}: {post.Title}");
            Console.WriteLine("1. Edit");
            Console.WriteLine("2. Delete");
            Console.WriteLine("0. Cancel");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("New Title: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("New Content: ");
                    string newContent = Console.ReadLine();
                    post.Update(newTitle, newContent);
                    Console.WriteLine("Post updated.");
                    break;

                case "2":
                    _postService.DeletePost(post);
                    Console.WriteLine("Post deleted.");
                    break;

                case "0":
                    Console.WriteLine("Moderation cancelled.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }


    }

}
