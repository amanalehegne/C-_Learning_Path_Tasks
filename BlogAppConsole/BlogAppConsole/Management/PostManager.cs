using BlogAppConsole.DataControl;
using BlogAppConsole.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAppConsole.Management;
public class PostManager
{
    private BlogAppContext db;
    public PostManager()
    {
        db = new BlogAppContext();
    }

    // Add Post
    public void AddPost(Post post)
    {
        try
        {
            db.Posts.Add(post);
            db.SaveChanges();
            Console.WriteLine("Post Added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding post: " + ex.Message);
        }
    }

    // Return All Posts
    public void GetAllPosts()
    {
        Console.WriteLine("All Posts");
        var posts = db.Posts.OrderBy(p => p.Id).ToList();
        foreach (var post in posts)
        {
            Console.WriteLine($"Post Id: {post.Id} | Title: {post.Title} | Content: {post.Content}");
        }
    }

    // Update A Post
    public void UpdatePost(int postId)
    {
        Console.WriteLine("Updating the post and adding a new post");
        var post = db.Posts.Where(p => p.Id == postId).FirstOrDefault();

        Console.Write("New Title: ");
        string? newTitle = Console.ReadLine();

        Console.Write("New Content: ");
        string? newContent = Console.ReadLine();

        if (post != null)
        {
            post.Title = newTitle;
            post.Content = newContent;
            db.SaveChanges();
            Console.WriteLine("Post updated and new post added.");
        }
    }

    // Delete A Post
    public void DeletePost(int postId)
    {
        Console.WriteLine("Delete the post");
        var post = db.Posts.Where(p => p.Id == postId).FirstOrDefault();

        if (post != null)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
            Console.WriteLine("Post deleted successfully.");
        }
    }

    public void GetPost(int postId)
    {
        var post = db.Posts
            .Where(p => p.Id == postId)
            .Include(p => p.Comments)
            .FirstOrDefault();

        if (post != null)
        {
            Console.WriteLine($"Post Id: {post.Id} | Title: {post.Title} | Content: {post.Content}");
            Console.WriteLine("Comments:");
            foreach (var comment in post.Comments)
            {
                Console.WriteLine($"Comment Id: {comment.Id} | Text: {comment.Text}");
            }
        }
        else
        {
            Console.WriteLine("Post not found.");
        }
    }

}