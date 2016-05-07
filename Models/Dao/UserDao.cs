using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
namespace Models.Dao
{
    public class UserDao
    {
        private ShoeShopDbContext db = null;
        public UserDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(NguoiDung entity)
        {
            db.NguoiDungs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public int Login(string username, string password)
        {
            var res = db.NguoiDungs.SingleOrDefault(o => o.UserName == username && o.Password == password);
            if (res==null)
            {
                return 0;
            }
            else
            {
                if(res.Status==0)
                {
                    return -1;
                }
                else
                {
                    return res.Role;
                }
            }
        }
        public NguoiDung GetNguoiDungByName(string username)
        {
            return db.NguoiDungs.SingleOrDefault(o => o.UserName == username);
        }
    }
}
