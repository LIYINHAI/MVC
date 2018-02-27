using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Linq.Expressions;

namespace DAL
{
    public class UserInfoDal:BaseDal<userinfo>,IUserInfoDal
    {
      ///实现自己特有方法。
    }
}
