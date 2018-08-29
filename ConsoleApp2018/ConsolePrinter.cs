using System;
using System.Collections.Generic;
using VideoApp.Core.ApplicationService;
using VideoApp.Core.Entity;

namespace ConsoleApp2018
{
    public class ConsolePrinter : IConsolePrinter
    {
        readonly IVideoService _videoService;

        public ConsolePrinter(IVideoService videoService)
        {
            _videoService = videoService;
        }

        private readonly string[] _menuItems =
        {
            "List videos",
            "Add video",
            "Delete video",
            "Edit video",
            "Search by exact name", 
            "Search by string"
        };

        public void ChooseMenuItem()
        {          
            //int selection = 0;
            //while (!int.TryParse(Console.ReadLine(), out selection)
            //       || selection < 1
            //       || selection > 6)
            //Console.WriteLine("You need to choose to a number from 1 - 6");
            //Console.WriteLine("");
          
            Console.WriteLine("Select what you want to do. \n");
            

            for (var i = 0; i < _menuItems.Length; i++) Console.WriteLine($"{i + 1} : {_menuItems[i]}");

            string selection = Console.ReadLine();

            if (int.TryParse(selection, out int verified))
            { 
                    switch (verified)
                    {
                        case 1:                           
                            PrintVideoList();
                            break;

                        case 2:
                            AddVideo();
                            break;

                        case 3:
                            DeleteVideo();
                            break;

                        case 4:
                            EditVideo();
                            break;

                        case 5:
                            SearchByExactName();
                            break;

                        case 6:
                        SearchByContainingString();
                        break;
                    }
                ChooseMenuItem();
            }           
            //Console.WriteLine("Bye!");
            Console.ReadLine();
        }

        public void DeleteVideo()
        {
            Console.Clear();

            Console.WriteLine("You chose option 3 : Delete video.");
            Console.WriteLine("");
            Console.WriteLine("What video id do you want to delete?");
            int videoToDeleteId = int.Parse(Console.ReadLine());
            Video deletedVideo = _videoService.Delete(videoToDeleteId);

            Console.WriteLine($"Video with id: {deletedVideo.Id} was deleted.");
        }


        public void AddVideo()
        {
            Console.Clear();
         
            Console.WriteLine("You have chosen option 2 : Add video.");
            Console.WriteLine("");

            Console.WriteLine("Input Name of Video:");
            var newVideoName = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Input genre of the video:");
            var newVideoGenre = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Input duration of the video in minutes:");
            var newVideoDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            Video video = new Video();
            video.Name = newVideoName;
            video.Genre = newVideoGenre;
            video.Duration = newVideoDuration;

            Video createdVideo = _videoService.Create(video);

            PrintSingleVideo(createdVideo);
        }

        public void PrintVideoList()
        {
            Console.Clear();
            Console.WriteLine("You have chosen option 1 - print all videos:");
            Console.WriteLine("------------------------------------------------------------------------");
            var videos = _videoService.GetVideos();

            PrintAllVideo(videos);
        }


        public void EditVideo()
        {
            Console.WriteLine("You have chosen option 4 - edit a video");
            Console.WriteLine("");
            Console.WriteLine("Choose the id number for the video you want to edit:");
            int editVideoId = int.Parse(Console.ReadLine());
            var video = _videoService.GetById(editVideoId);

            Console.WriteLine("");
            Console.WriteLine("Input Name of Video:");
            var editVideoName = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Input genre of the video:");
            var editVideoGenre = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Input duration of the video in minutes:");
            var editVideoDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            video.Id = video.Id;
            video.Name = editVideoName;
            video.Genre = editVideoGenre;
            video.Duration = editVideoDuration;

            _videoService.Update(video);

            Console.Clear();
            Console.WriteLine($"Video with id: {video.Id} was updated.");
            Console.WriteLine("");
        }

        public void SearchByExactName()
        {
            Console.WriteLine("You have chosen option 5 - search by name.");
            Console.WriteLine("");
            Console.WriteLine("Insert a name to search for:");
            string searchName = Console.ReadLine()?.ToLower();

            Video video;
            video = _videoService.SearchByExactName(searchName);

            Console.WriteLine("");
            Console.WriteLine($"Id: {video.Id}");
            Console.WriteLine($"Name: {video.Name}");
            Console.WriteLine($"Genre: {video.Genre}");
            Console.WriteLine($"Duration: {video.Duration} minutes.");
            Console.WriteLine("");
        }

        public void SearchByContainingString()
        {
            Console.WriteLine("You have chosen option 6 - search videos which contain a string.");
            Console.WriteLine("");
            Console.WriteLine("Please input the string you want to search for:");
            string searchString = Console.ReadLine();
            Console.WriteLine("");
            var videos = _videoService.SearchByContainsString(searchString);
            PrintAllVideo(videos);
        }

        public void PrintSingleVideo(Video video)
        {
            Console.WriteLine($"Id: {video.Id}");
            Console.WriteLine($"Name: {video.Name}");
            Console.WriteLine($"Genre: {video.Genre}");
            Console.WriteLine($"Duration: {video.Duration}");
            Console.WriteLine("");
        }

        public void PrintAllVideo(List<Video> videos)
        {
            foreach (var video in videos)
            {
                PrintSingleVideo(video);
            }
        }
    }
}
