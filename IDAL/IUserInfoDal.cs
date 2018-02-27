using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    //接耦
   public interface IUserInfoDal:IBaseDal<userinfo>
    {
        //定义自己特有的方法。
    }
}
