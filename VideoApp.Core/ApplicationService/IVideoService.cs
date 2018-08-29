using System.Collections.Generic;
using VideoApp.Core.Entity;

namespace VideoApp.Core.ApplicationService
{
    public interface IVideoService
    {
        List<Video> GetVideos();
        Video GetById(int id);

        Video Create(Video video);

        Video Delete(int id);

        Video Update(Video video);

        Video SearchByExactName(string name);

        List<Video> SearchByContainsString(string name);
    }
}
