using System;
using _1651democode.Users;
using _1651democode.Services;

namespace _1651democode
{
    class Program
    {
        static void Main()
        {
            var postService = new PostService();

            Console.WriteLine("Welcome to the 1651 Post System!");

            while (true)
            {
                Console.WriteLine("\nSelect role:");
                Console.WriteLine("1. Member");
                Console.WriteLine("2. Manager");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                var input = Console.ReadLine();

                if (input == "0") break;

                if (input == "1")
                {
                    Console.Write("Enter Member ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid ID.");
                        continue;
                    }
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    var member = new Member(id, username);
                    MemberMenu(member, postService);
                }
                else if (input == "2")
                {
                    Console.Write("Enter Manager ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Invalid ID.");
                        continue;
                    }
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    var manager = new Manager(id, username, postService);
                    ManagerMenu(manager);
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again.");
                }
            }

            Console.WriteLine("Goodbye!");
        }

        static void MemberMenu(Member member, PostService postService)
        {
            while (true)
            {
                Console.WriteLine("\nMember Menu:");
                Console.WriteLine("1. View Your Posts");
                Console.WriteLine("2. Create New Post");
                Console.WriteLine("3. Edit Post");
                Console.WriteLine("4. Delete Post");
                Console.WriteLine("0. Logout");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        member.ViewPosts();
                        break;

                    case "2":
                        Console.Write("Title: ");
                        var title = Console.ReadLine();
                        Console.Write("Content: ");
                        var content = Console.ReadLine();
                        member.CreatePost(title, content, postService);
                        break;

                    case "3":
                        Console.Write("Enter Post number to edit: ");
                        if (!int.TryParse(Console.ReadLine(), out int editId))
                        {
                            Console.WriteLine("Invalid Post number.");
                            break;
                        }
                        var post = member.GetPostById(editId);
                        if (post == null)
                        {
                            Console.WriteLine("Post not found or you do not have permission to edit.");
                            break;
                        }
                        Console.Write("New Title: ");
                        var newTitle = Console.ReadLine();
                        Console.Write("New Content: ");
                        var newContent = Console.ReadLine();
                        member.EditPost(editId, newTitle, newContent);
                        break;

                    case "4":
                        Console.Write("Enter Post number to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int delId))
                        {
                            Console.WriteLine("Invalid Post ID.");
                            break;
                        }
                        member.DeletePost(delId, postService);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ManagerMenu(Manager manager)
        {
            while (true)
            {
                Console.WriteLine("\nManager Menu:");
                Console.WriteLine("1. View All Posts");
                Console.WriteLine("2. Moderate Post");
                Console.WriteLine("0. Logout");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        manager.ViewAllPosts();
                        break;

                    case "2":
                        Console.Write("Enter Post number to moderate: ");
                        if (!int.TryParse(Console.ReadLine(), out int modId))
                        {
                            Console.WriteLine("Invalid Post number.");
                            break;
                        }
                        manager.ModeratePost(modId);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
