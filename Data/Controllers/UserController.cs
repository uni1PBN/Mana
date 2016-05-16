namespace Data.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class UserController
    {
        private DBManaEntities _dbcontext = DBManaEntitiesSingleton.Instance;

        public User UserCurrent { get; set; }
        public List<User> UserCollection { get; set; }

        public UserController()
        {
        }

        public List<User> GetAll()
        {
            UserCollection = _dbcontext.MANA_User.ToList();
            return UserCollection;
        }
        public User GetItem(int pk)
        {
            UserCurrent = _dbcontext.MANA_User.Where(x => x.PK == pk).FirstOrDefault();
            return UserCurrent;
        }
        public User GetItem(string userID)
        {
            UserCurrent =  _dbcontext.MANA_User.Where(x => x.UserID == userID).FirstOrDefault();
            return UserCurrent;
        }



    }
}

//