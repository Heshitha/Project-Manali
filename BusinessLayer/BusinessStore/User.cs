﻿using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessStore
{
    public class User
    {
        public static int CreateUser(UserDTO userDTO)
        {
            return DataAccessLayer.Datastore.UserDataStore.CreateNewUser(userDTO);
        }

        public static List<UserDTO> GetAllUserDetails()
        {
            return DataAccessLayer.Datastore.UserDataStore.GetAllUserDetails();
        }

        public static UserDTO GetUserDetailsByID(int userID)
        {
            return DataAccessLayer.Datastore.UserDataStore.GetUserDetailsByID(userID);
        }
    }
}
