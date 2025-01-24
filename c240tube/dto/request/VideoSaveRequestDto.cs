using c240tube.entity;

namespace c240tube.dto.request
{
    public class VideoSaveRequestDto
    {
        public long StreamerId { get; set; }
        public string Title { get; set; }

        public double Range { get; set; }
        public string Url { get; set; }

    }
}
