using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Datastore
{
    public class UserDataStore
    {
        static ManaliDataStoreDataContext userDB = new ManaliDataStoreDataContext();

        public static int CreateNewUser(UserDTO userDTO)
        {
            var newuser = userDB.Manali_CreateUser(userDTO.Name,
                                   userDTO.NIC,
                                   userDTO.Mobile,
                                   userDTO.Address,
                                   userDTO.Username, 
                                   userDTO.Password, 
                                   userDTO.ImagePath);
            return Convert.ToInt32(newuser.FirstOrDefault().MessageType);

        }
    }
}
