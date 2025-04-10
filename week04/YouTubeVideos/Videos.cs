public class Videos
{
    private List<Video> _videos;

    public Videos()
    {
        _videos = new List<Video>();
    }

    public void AddVideo(Video video)
    {
        _videos.Add(video);

    }

    public void Display()
    {
        int video_number = 1;
        foreach (Video video in _videos)
        {

            Console.WriteLine($"Video {video_number}");
            video.Display();
            video_number++;
        }
    }
}