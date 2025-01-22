using c240tube.context;
using c240tube.entity;
using c240tube.service.abstracts;

namespace c240tube.service.concrete
{
    public class StreamerService : IStreamerService
    {
        private C240tubeContext _context;
        public StreamerService(C240tubeContext context)
        {
            _context = context;        
        }

        public void save(string mail,string name, string phone, Auth auth)
        {


            Streamer streamer = new Streamer();
            streamer.Auth= auth;
            streamer.Name=name;
            streamer.Phone=phone;
            _context.Streamer.Add(streamer);
            _context.SaveChanges();
           
        }
    }
}
