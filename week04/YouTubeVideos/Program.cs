using System;
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C# Programming", "Marius Popescu", 1200); // 20 minutes
        video1.AddComment(new Comment("Alice Smith", "Great introductory video! Very clear explanations."));
        video1.AddComment(new Comment("Bob Johnson", "This really helped me understand classes. Thanks!"));
        video1.AddComment(new Comment("Charlie Brown", "Could you do a video on interfaces next?"));
        videos.Add(video1); // Add video1 to the list

        Video video2 = new Video("Cooking with Chef Remy: Pasta Perfection", "Chef Remy", 900); // 15 minutes
        video2.AddComment(new Comment("Dina Chen", "My pasta turned out amazing following this recipe!"));
        video2.AddComment(new Comment("Ethan Davis", "Love your cooking style, Chef Remy!"));
        video2.AddComment(new Comment("Fiona Green", "What kind of olive oil do you recommend?"));
        video2.AddComment(new Comment("George White", "Delicious and easy to follow."));
        videos.Add(video2); // Add video2 to the list

        Video video3 = new Video("Exploring the Amazon Rainforest", "Nature's Wonders", 2700); // 45 minutes
        video3.AddComment(new Comment("Hannah Lee", "Breathtaking footage! Educational and inspiring."));
        video3.AddComment(new Comment("Ivan Petrov", "The sounds of the jungle are so immersive."));
        video3.AddComment(new Comment("Jasmine King", "Protect our planet! #conservation"));
        videos.Add(video3); // Add video3 to the list

        Video video4 = new Video("DIY Home Renovation: Bathroom Remodel", "Handy Harry", 3600); // 60 minutes
        video4.AddComment(new Comment("Kelly Taylor", "This video gave me the confidence to start my own project!"));
        video4.AddComment(new Comment("Liam Wilson", "Very detailed steps, thanks for sharing."));
        video4.AddComment(new Comment("Mia Moore", "Are there any specific tools you'd recommend for tiling?"));
        videos.Add(video4); // Add video4 to the list

        Console.WriteLine("--- YouTube Video Program Output ---");
        Console.WriteLine("====================================\n");

        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }

        Console.WriteLine("====================================");
        Console.WriteLine("Program execution complete.");
    }
}