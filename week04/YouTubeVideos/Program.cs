using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("This is Africa!", "Jean Marie", 100);
        video1.AddComment(new Comment("David", "I like this!"));
        video1.AddComment(new Comment("Don", "I love this!"));
        video1.AddComment(new Comment("Jaribu", "Can't wait for the next!"));

        Video video2 = new Video("Visit Namibia", "Nasibu", 250);
        video2.AddComment(new Comment("Netumo", "I wish to visit Namibia one day!"));
        video2.AddComment(new Comment("Radjul", "Where is this?"));
        video2.AddComment(new Comment("Kabange", "Nasibu nice video, I love it!"));

        Video video3 = new Video("Dicover Himba Nation", "Moleni Shipanga", 600);
        video3.AddComment(new Comment("Emma", "This documentary is amazing!"));
        video3.AddComment(new Comment("Paulina", "More history content, please!"));
        video3.AddComment(new Comment("BestMan", "Absolutely fascinating!"));

        Video video4 = new Video("Visit The Temple", "Joseph Tumelani", 330);
        video4.AddComment(new Comment("Nancy", "Very Inspired"));
        video4.AddComment(new Comment("Mukalenga", "The best video ever"));
        video4.AddComment(new Comment("Benjamin", "Best compilation ever!"));

        Videos videos = new Videos();
        videos.AddVideo(video1);
        videos.AddVideo(video2);
        videos.AddVideo(video3);
        videos.AddVideo(video4);

        videos.Display();

    }
}