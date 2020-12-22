using System.Collections.Generic;
using System.Linq;
using System;

namespace P0_AndresOrozco
{
    public class StoreAppRepositoryLayer
    {
        StoreAppDBContext db = new StoreAppDBContext();
        public User CreateUser(string fName, string lName)
        {
            User u = new User(fName, lName);
            //u = db.users.Where(x => x.FName == fName && x.LName == lName).FirstOrDefault();
            db.users.Add(u);
            db.SaveChanges();
            //u = StoreAppDBContext.user
            //db.users.Add(u);
            //db.SaveChanges();
            return u;
        }

    }
}