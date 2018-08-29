using System.Collections.Generic;
using System.Linq;
using VideoApp.Core.DomainService;
using VideoApp.Core.Entity;


namespace VideoApp.Infrastructure.Static.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {      
        public Video CreateVideo(Video video)
        {
            video.Id = FakeDb.Id++;

            FakeDb.Videos.Add(video);

            return video;
        }

        public IEnumerable<Video> ReadAll()
        {
            return FakeDb.Videos.ToList();
        }

        public Video UpdateVideo(Video videoUpdate)
        {
            Video video = ReadById(videoUpdate.Id);
            video.Name = videoUpdate.Name;
            video.Genre = videoUpdate.Genre;
            video.Duration = videoUpdate.Duration;

            return video;
        }

        public Video DeleteVideo(int id)
        {
            Video video = ReadById(id);
            FakeDb.Videos.Remove(video);
            return video;
        }

        public Video ReadById(int id)
        {
            foreach (var video in FakeDb.Videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            return null;
        }

        public Video SearchByExactName(string name)
        {
            foreach (var video in FakeDb.Videos)
            {
                if (video.Name.ToLower() == name)
                {
                    return video;
                }
            }
            return null;
        }

        public IEnumerable<Video> ReadVideosContainingString(string name)
        {
            List<Video> videosContainingString = new List<Video>();

            foreach (var video in FakeDb.Videos)
            {
                if (video.Name.ToLower().Contains(name.ToLower()))
                {
                    videosContainingString.Add(video);
                }
                
            }
            return videosContainingString.ToList();            
        }
    }
}
