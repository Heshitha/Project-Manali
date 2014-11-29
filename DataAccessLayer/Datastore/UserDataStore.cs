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
            try
            {
                return (userDB.Manali_CreateUser(userDTO.Name,
                                           userDTO.NIC,
                                           userDTO.Mobile,
                                           userDTO.Address,
                                           userDTO.Username,
                                           userDTO.Password,
                                           userDTO.ImagePath).SingleOrDefault()).MessageType.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<UserDTO> GetAllUserDetails()
        {
            try
            {
                var results = userDB.Manali_GetAllUserDetails();

                List<UserDTO> lstDTO = new List<UserDTO>();

                foreach (var item in results)
                {
                    UserDTO userObject = new UserDTO
                    {
                        userID = item.UserID,
                        Name = item.Name,
                        NIC = item.NIC,
                        Mobile = item.Mobile,
                        Address = item.Address,
                        Username = item.Username,
                        ImagePath = item.Image
                    };

                    lstDTO.Add(userObject);
                }

                return lstDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static UserDTO GetUserDetailsByID(int userID)
        {
            try
            {
                var result = userDB.Manali_User_SelectAUser(userID).SingleOrDefault();

                if (result != null)
                {
                    UserDTO userDetails = new UserDTO
                    {
                        userID = result.UserID,
                        Name = result.Name,
                        NIC = result.NIC,
                        Mobile = result.Mobile,
                        Address = result.Address,
                        Username = result.Username,
                        ImagePath = result.Image
                    };

                    return userDetails;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
