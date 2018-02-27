using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DAL;
using Model;

namespace DALFactory
{
    /// <summary>
    /// DBSession:工厂类（数据会话层），作用：创建数据操作类的实例，业务层通过DBSession调用相应的数据操作类的实例，这样将数据层与业务层解耦。
    /// </summary>
   public class DBSession:IDBSession
    {
        RuanKaoEntities Db = new RuanKaoEntities();
        private IUserInfoDal _IUserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get {
                if (_IUserInfoDal == null)
                {
                    //_IUserInfoDal = new UserInfoDal();//如果更换数据层，这里也要修改。
                    _IUserInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _IUserInfoDal;
            }
            set { _IUserInfoDal = value; }
        }
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
