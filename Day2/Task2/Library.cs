namespace Learning_Track_Tasks;

class Library
{
    private string name;
    private string address;
    private List<Book> books;
    private List<MediaItem> mediaItems;

    public Library(string name, string address)
    {
        this.name = name;
        this.address = address;
        this.books = new List<Book>();
        this.mediaItems = new List<MediaItem>();
    }

    // Setters and Getters
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public List<Book> Books
    {
        get { return books; }
        set { books = value; }
    }

    public List<MediaItem> MediaItems
    {
        get { return mediaItems; }
        set { mediaItems = value; }
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public void AddMediaItem(MediaItem item)
    {
        mediaItems.Add(item);
    }

    public void RemoveMediaItem(MediaItem item)
    {
        mediaItems.Remove(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("Library Catalog");
        // Print Books
        if (books.Count > 0)
        {
            Console.WriteLine("\nBooks");
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title} | Author: {book.Author} | ISBN: {book.ISBN} | Publication Year: {book.PublicationYear}");
            }
        }

        // Print Media Itea
        if (mediaItems.Count > 0)
        {
            Console.WriteLine("\nMedia Items");
            foreach (MediaItem mediaItem in mediaItems)
            {
                Console.WriteLine($"Title: {mediaItem.Title} | Media Type: {mediaItem.MediaType} | Duration: {mediaItem.Duration}");
            }
        }


    }
}