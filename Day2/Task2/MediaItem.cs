namespace Learning_Track_Tasks;

class MediaItem
{
    private string title;
    private string mediaType;
    private int duration;

    public MediaItem(string title, string mediaType, int duration)
    {
        this.title = title;
        this.mediaType = mediaType;
        this.duration = duration;
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string MediaType
    {
        get { return mediaType; }
        set { mediaType = value; }
    }

    public int Duration
    {
        get { return duration; }
        set
        {
            if (value > 0)
            {
                duration = value;
            }
            else
            {
                throw new ArgumentException("Invalid input. Please provide a valid integer.");
            }
        }
    }

}
