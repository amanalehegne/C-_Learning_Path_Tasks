namespace BlogAppConsole;
using BlogAppConsole.Management;

class Program
{
    static void Main(string[] args)
    {
        UserInteraction userInteraction = new UserInteraction();
        userInteraction.UI();
    }
}