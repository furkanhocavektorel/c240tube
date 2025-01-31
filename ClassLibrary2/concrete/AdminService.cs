using c240tube.context;
using c240tube.entity;
using c240tube.service.abstracts;
using ClassLibrary2;

namespace c240tube.service.concrete
{
    public class AdminService : IAdminService
    {
        private C240tubeContext _context;


        public AdminService(C240tubeContext context)
        {
                _context = context;
        }



        public void save(string name, string surname, string phone, Auth auth)
        {
            
            TestC c = new TestC();



            if (surname == null)
            {
                throw new Exception("soy adi girilmeli ");
            }


            Admin admin = new Admin();
            admin.Name = name;
            admin.Surname = surname;
            admin.Phone = phone;
            admin.Auth = auth;

            _context.Admin.Add(admin);
            _context.SaveChanges();
           
        }
    }
}
