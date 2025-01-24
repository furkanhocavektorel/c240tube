namespace c240tube.entity
{
    public class Video : BaseEntity
    {

        public Streamer Streamer { get; set; }
        public string Title { get; set; }

        public double Range { get; set; }
        public string Url { get; set; }
        public int like { get; set; }

        public Video()
        {
            like = 0;
        }

    }
}
