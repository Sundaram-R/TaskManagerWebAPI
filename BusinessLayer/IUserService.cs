using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public  interface IUserService
    {
        List<UserDO> GetAll();
        UserDO GetById(int id);
        int Add(UserDO model);
        int Edit(UserDO model);
        int Delete(int id);
    }
}
