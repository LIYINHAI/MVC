using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 封装
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
   public interface IBaseDal<T>where T:class,new()
    {
        //数据表达方式
        //基本查询
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLanbda);
        //分页
        //s为一个泛型（页面不确定数据类型传递进来）
        //isAsc为一个方法来确定升降序
        IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLanbda,
            System.Linq.Expressions.Expression<Func<T, s>> orderbyLandba, bool isAsc);
        //删除
        bool DeleteEntity(T entity);
        //编辑
        bool EditEntity(T entity);
        T AddEntity(T entity);
    }
}
