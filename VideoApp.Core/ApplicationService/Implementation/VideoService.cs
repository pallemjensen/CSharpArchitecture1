using System.Collections.Generic;
using System.Linq;
using VideoApp.Core.DomainService;
using VideoApp.Core.Entity;

namespace VideoApp.Core.ApplicationService.Implementation
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public List<Video> GetVideos()
        {
            return _videoRepository.ReadAll().ToList();
        }

        public Video GetById(int id)
        {
            return _videoRepository.ReadById(id);
        }

        public Video Create(Video video)
        {
            return _videoRepository.CreateVideo(video);
        }

        public Video Delete(int id)
        {
            return _videoRepository.DeleteVideo(id);
        }

        public Video Update(Video video)
        {
            return _videoRepository.UpdateVideo(video);
        }

        public Video SearchByExactName(string name)
        {
            return _videoRepository.SearchByExactName(name);
        }

        public List<Video> SearchByContainsString(string name)
        {         
            return _videoRepository.ReadVideosContainingString(name).ToList();
        }
    }
}
