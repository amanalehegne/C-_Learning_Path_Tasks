namespace Learning_Track_Tasks;

class Programs
{
    static void Main(string[] args)
    {
        Book book1 = new Book("1984", "George Orwell", "12SD81Jd4", 1950);
        Book book2 = new Book("Old Man And The sea", "Ernest Hemmingway", "123d4", 1990);

        MediaItem mediaItem1 = new MediaItem("Movie ABC", "DVD", 120);
        MediaItem mediaItem2 = new MediaItem("Media2", "CD", 70);

        Library library = new Library("AASTU", "Addis Ababa");
        library.AddBook(book1);
        library.AddBook(book2);

        library.AddMediaItem(mediaItem1);
        library.AddMediaItem(mediaItem2);

        library.PrintCatalog();
        Console.ReadLine();
    }
}