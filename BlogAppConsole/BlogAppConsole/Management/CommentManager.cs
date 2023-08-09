using BlogAppConsole.DataControl;
using BlogAppConsole.Entities;

namespace BlogAppConsole.Management;
public class CommentManager
{
    private BlogAppContext db;
    public CommentManager()
    {
        db = new BlogAppContext();
    }

    public void AddComment(Comment comment)
    {
        try
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            Console.WriteLine("Comment added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding comment: " + ex.Message);
        }
    }

    public void GetAllComments()
    {
        Console.WriteLine("All Comments");
        var comments = db.Comments.OrderBy(c => c.Id).ToList();
        foreach (var comment in comments)
        {
            Console.WriteLine($"Comment Id: {comment.Id} | Text: {comment.Text}");
        }
    }

    public void UpdateComment(int commentId)
    {
        Console.WriteLine("Updating the comment");

        var comment = db.Comments
            .Where(c => c.Id == commentId)
            .FirstOrDefault();

        if (comment != null)
        {
            Console.Write("New Text: ");
            string newCommentText = Console.ReadLine();

            comment.Text = newCommentText;
            db.SaveChanges();
            Console.WriteLine("Comment updated successfully.");
        }
    }

    public void DeleteComment(int commentId)
    {
        Console.WriteLine("Delete the comment");
        var comment = db.Comments
            .Where(c => c.Id == commentId)
            .FirstOrDefault();

        if (comment != null)
        {
            db.Comments.Remove(comment);
            db.SaveChanges();
            Console.WriteLine("Comment deleted successfully.");
        }
    }

}