using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Contract.ServiceInterface;

public interface IUserService
{
    User GetUserById(int id);
    List<User> GetAllUsers();
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int id);
}
