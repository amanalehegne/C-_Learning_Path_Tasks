namespace Learning_Track_Tasks;

class Book
{
    private string title;
    private string author;
    private string isbn;
    private int publicationYear;

    public Book(string title, string author, string isbn, int publicationYear)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.publicationYear = publicationYear;
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string ISBN
    {
        get { return isbn; }
        set { isbn = value; }
    }

    public int PublicationYear
    {
        get { return publicationYear; }
        set
        {
            if (value > 0)
            {
                publicationYear = value;
            }
            else
            {
                throw new ArgumentException("Invalid input. Please provide a valid integer.");
            }
        }
    }

}