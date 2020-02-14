using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Hj.SqlSugarFactory.Lib
{
    public class MySqlSugarClient : SqlSugarClient
    {
        public MySqlSugarClient(ConnectionConfig config) : base(config)
        {
        }
        #region Insertable
        public  IInsertable<T> Insertable<T>(Dictionary<string, object> columnDictionary) where T : class, new()
        {
            return this.Context.Insertable<T>(columnDictionary).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IInsertable<T> Insertable<T>(dynamic insertDynamicObject) where T : class, new()
        {
            return this.Context.Insertable<T>(insertDynamicObject).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IInsertable<T> Insertable<T>(List<T> insertObjs) where T : class, new()
        {
            return this.Context.Insertable<T>(insertObjs).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IInsertable<T> Insertable<T>(T insertObj) where T : class, new()
        {
            return this.Context.Insertable<T>(insertObj).EnableDiffLogEvent(typeof(T).Name);//添加aop日志记录
        }

        public IInsertable<T> Insertable<T>(T[] insertObjs) where T : class, new()
        {
            return this.Context.Insertable<T>(insertObjs).EnableDiffLogEvent(typeof(T).Name); ;
        }

        #endregion
        #region Updateable
        public IUpdateable<T> Updateable<T>() where T : class, new()
        {
            return this.Context.Updateable<T>();
        }

        public IUpdateable<T> Updateable<T>(Dictionary<string, object> columnDictionary) where T : class, new()
        {
            return this.Context.Updateable<T>(columnDictionary).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IUpdateable<T> Updateable<T>(dynamic updateDynamicObject) where T : class, new()
        {
            return this.Context.Updateable<T>(updateDynamicObject).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IUpdateable<T> Updateable<T>(Expression<Func<T, bool>> columns) where T : class, new()
        {
            return this.Context.Updateable<T>(columns).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IUpdateable<T> Updateable<T>(Expression<Func<T, T>> columns) where T : class, new()
        {
            return this.Context.Updateable<T>(columns).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IUpdateable<T> Updateable<T>(List<T> UpdateObjs) where T : class, new()
        {
            return this.Context.Updateable<T>(UpdateObjs).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IUpdateable<T> Updateable<T>(T UpdateObj) where T : class, new()
        {
            return this.Context.Updateable<T>(UpdateObj).EnableDiffLogEvent(typeof(T).Name);//添加日志
        }

        public IUpdateable<T> Updateable<T>(T[] UpdateObjs) where T : class, new()
        {
            return this.Context.Updateable<T>(UpdateObjs).EnableDiffLogEvent(typeof(T).Name); ;
        }

        #endregion
        #region Deleteable
        public IDeleteable<T> Deleteable<T>() where T : class, new()
        {
            return this.Context.Deleteable<T>().EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IDeleteable<T> Deleteable<T>(dynamic primaryKeyValue) where T : class, new()
        {
            return this.Context.Deleteable<T>(primaryKeyValue).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IDeleteable<T> Deleteable<T>(dynamic[] primaryKeyValues) where T : class, new()
        {
            return this.Context.Deleteable<T>(primaryKeyValues).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IDeleteable<T> Deleteable<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            return this.Context.Deleteable(expression).EnableDiffLogEvent(typeof(T).Name);//添加日志
        }

        public IDeleteable<T> Deleteable<T>(List<dynamic> pkValue) where T : class, new()
        {
            return this.Context.Deleteable<T>(pkValue).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IDeleteable<T> Deleteable<T>(List<T> deleteObjs) where T : class, new()
        {
            return this.Context.Deleteable<T>(deleteObjs).EnableDiffLogEvent(typeof(T).Name); ;
        }

        public IDeleteable<T> Deleteable<T>(T deleteObj) where T : class, new()
        {
            return this.Context.Deleteable<T>(deleteObj).EnableDiffLogEvent(typeof(T).Name); ;
        }


        #endregion
    }
}
