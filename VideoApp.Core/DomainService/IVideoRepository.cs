using System.Collections.Generic;
using VideoApp.Core.Entity;

namespace VideoApp.Core.DomainService
{
    public interface IVideoRepository
    {
        Video CreateVideo(Video video);

        IEnumerable<Video> ReadAll();

        Video UpdateVideo(Video videoUpdate);

        Video DeleteVideo(int id);

        Video ReadById(int id);

        Video SearchByExactName(string name);

        IEnumerable<Video> ReadVideosContainingString(string name);
    }
}
