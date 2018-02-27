using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class BaseDal<T>where T:class,new()
    {
        RuanKaoEntities Db = new RuanKaoEntities();
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
            return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLanbda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLanbda)
        {
            return Db.Set<T>().Where<T>(whereLanbda);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIdex"></param>
        /// <param name="pageSize"></param>
        /// <param name="toalCount"></param>
        /// <param name="whereLanbda"></param>
        /// <param name="orderbyLandba"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLanbda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLandba, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLanbda);
            toalCount = temp.Count();
            if (isAsc)//升序
            {
                temp = temp.OrderBy<T, s>(orderbyLandba).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize);
            }
            else//降序
            {
                temp = temp.OrderByDescending<T, s>(orderbyLandba).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
    }
}

