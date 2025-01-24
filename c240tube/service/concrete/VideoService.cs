using c240tube.context;
using c240tube.dto.request;
using c240tube.entity;
using c240tube.service.abstracts;

namespace c240tube.service.concrete
{
    public class VideoService : IVideoService
    {
        private readonly C240tubeContext _context;
        private readonly IStreamerService _streamerService;
        public VideoService(C240tubeContext context, IStreamerService streamerService)
        {
            _context = context;
            _streamerService = streamerService;
        }

        public void uploadVideo(VideoSaveRequestDto dto)
        {

            Video video = new Video();
            video.Range = dto.Range;
            video.Title = dto.Title;
            video.Url = dto.Url;

            Streamer streamer = _streamerService.findStreamerById(dto.StreamerId);

            video.Streamer = streamer;

            _context.Video.Add(video);
            _context.SaveChanges();
            
        }
    }
}
