using BlogAppConsole.Entities;

namespace BlogAppConsole.Management;
public class UserInteraction
{
    private readonly PostManager postManager;
    private readonly CommentManager commentManager;

    public UserInteraction()
    {
        postManager = new PostManager();
        commentManager = new CommentManager();
    }

    public void UI()
    {
        while (true)
        {
            DisplayOptions();
            if (!PerformAction())
            {
                break;
            }
        }
    }

    private void DisplayOptions()
    {
        Console.WriteLine("Choose Action You Want To Perform:");
        Console.WriteLine("1. Create Post");
        Console.WriteLine("2. Display All Posts");
        Console.WriteLine("3. View A Post");
        Console.WriteLine("4. Edit A Post");
        Console.WriteLine("5. Delete A Post");
        Console.WriteLine("6. Comment On A Post");
        Console.WriteLine("7. Edit A Comment");
        Console.WriteLine("8. Delete A Comment");
    }

    private bool PerformAction()
    {
        int option = GetValidIntegerInput("Enter A Number Option: ");
        int id;

        switch (option)
        {
            case 1:
                CreatePost();
                break;
            case 2:
                postManager.GetAllPosts();
                break;
            case 3:
                id = GetValidIntegerInput("Enter The Post ID: ");
                postManager.GetPost(id);
                break;
            case 4:
                id = GetValidIntegerInput("Enter The Post ID: ");
                postManager.UpdatePost(id);
                break;
            case 5:
                id = GetValidIntegerInput("Enter The Post ID: ");
                postManager.DeletePost(id);
                break;
            case 6:
                id = GetValidIntegerInput("Enter The Post ID: ");
                CommentOnPost(id);
                break;
            case 7:
                id = GetValidIntegerInput("Enter The Comment ID: ");
                commentManager.UpdateComment(id);
                break;
            case 8:
                id = GetValidIntegerInput("Enter The Comment ID: ");
                commentManager.DeleteComment(id);
                break;
            default:
                Console.WriteLine("Exiting...");
                return false;
        }

        return true;
    }

    private void CreatePost()
    {
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Content: ");
        string content = Console.ReadLine();

        Post post = new Post { Title = title, Content = content };
        postManager.AddPost(post);
    }

    private void CommentOnPost(int postId)
    {
        Console.Write("Enter Your Comment: ");
        string commentContent = Console.ReadLine();

        Comment comment = new Comment { PostId = postId, Text = commentContent };
        commentManager.AddComment(comment);
    }

    private int GetValidIntegerInput(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
                break;
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }

        return result;
    }
}
