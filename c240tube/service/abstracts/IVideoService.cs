using c240tube.dto.request;
using c240tube.entity;

namespace c240tube.service.abstracts
{
    public interface IVideoService
    {
        void uploadVideo(VideoSaveRequestDto dto);
    }
}
