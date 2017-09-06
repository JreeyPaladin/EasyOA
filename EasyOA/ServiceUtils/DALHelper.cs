using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ServiceUtils
{
    /// <summary>
    /// 数据库常用操作帮助类
    /// </summary>
    public class DALHelper
    {
        public DALHelper(string conn)
        {
            DbHelperSQL = new DbHelperSQLP(conn);
        }
        public DbHelperSQLP DbHelperSQL = new DbHelperSQLP();
        /// <summary>
        /// 获得表某个字段最大值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public int GetMax(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="strSet">要更新的字段</param>
        /// <param name="strWhere">更新条件</param>
        /// <param name="cmdParms">参数值集合，目前支持SqlParameter[]和IList，类型都是SqlParameter</param>
        /// <returns></returns>
        public bool Update(string table, string strSet, string strWhere = "", object cmdParms = null)
        {
            int rows = Modify(table, strSet, strWhere, cmdParms);
            if (rows > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="strSet">要更新的字段</param>
        /// <param name="strWhere">更新条件</param>
        /// <param name="cmdParms">参数值集合，目前支持SqlParameter[]和IList，类型都是SqlParameter</param>
        /// <returns></returns>
        public int Modify(string table, string strSet, string strWhere = "", object cmdParms = null)
        {
            if (string.IsNullOrEmpty(table) || string.IsNullOrEmpty(strSet))
                return 0;
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " where " + strWhere;
            return DbHelperSQL.ExecuteSql(string.Format("update {0} set {1} {2}", table, strSet, strWhere), cmdParms);

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="strWhere">条件</param>
        /// <param name="cmdParms">参数值集合，目前支持SqlParameter[]和IList，类型都是SqlParameter</param>
        /// <returns></returns>
        public bool Delete(string table, string strWhere = "", object cmdParms = null)
        {
            if (string.IsNullOrEmpty(table))
                return false;
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " where " + strWhere;
            int rows = DbHelperSQL.ExecuteSql(string.Format("delete from {0} {1}", table, strWhere), cmdParms);
            if (rows > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="strWhere">条件</param>
        /// <param name="cmdParms">参数值集合，目前支持SqlParameter[]和IList，类型都是SqlParameter</param>
        /// <returns>删除条数</returns>
        public int DeleteNum(string table, string strWhere = "", object cmdParms = null)
        {
            if (string.IsNullOrEmpty(table))
                return 0;
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = " where " + strWhere;
            return DbHelperSQL.ExecuteSql(string.Format("delete from {0} {1}", table, strWhere), cmdParms);

        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="strWhere">条件</param>
        /// <param name="cmdParms">条件附带的参数，目前支持SqlParameter[]和IList，类型都是SqlParameter</param>
        /// <param name="strSelect">需要查询的字段</param>
        /// <param name="top">前几行</param>
        /// <param name="filedOrder">排序字段</param>
        /// <returns></returns>
        public DataSet GetList(string table, string strWhere = "", object cmdParms = null, string strSelect = "", int top = 0, string filedOrder = "")
        {
            if (string.IsNullOrEmpty(table))
                return null;
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = "where " + strWhere;
            if (string.IsNullOrEmpty(strSelect))
                strSelect = "*";
            if (top > 0)
                strSelect = string.Format("top {0} {1}", top.ToString(), strSelect);
            if (!string.IsNullOrEmpty(filedOrder))
                filedOrder = "order by " + filedOrder;
            return DbHelperSQL.Query(string.Format("select {0} from {1} {2} {3}", strSelect, table, strWhere, filedOrder), cmdParms);
        }
        /// <summary>
        /// 获取指定条件记录总数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="cmdParms">参数值集合，目前支持SqlParameter[]和IList，类型都是SqlParameter</param>
        /// <returns></returns>
        public int GetRecordCount(string table, string strWhere = "", object cmdParms = null)
        {
            if (string.IsNullOrEmpty(table))
                return 0;
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = "where " + strWhere;
            object obj = DbHelperSQL.GetSingle(string.Format("select count(1) from {0} {1}", table, strWhere), cmdParms);
            if (obj == null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }
        /// <summary>
        /// 获取分页数据，表的别名为T
        /// </summary>
        /// <param name="table">表名(如果是一张表请带上别名T，多张表就请对主表使用T为别名)</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <param name="orderby">排序字段（带上别名），例如T.Id desc或者T.Id asc</param>
        /// <param name="strWhere">查询条件，默认表别名为T，请带上别名</param>
        /// <param name="cmdParms">参数值集合，目前支持SqlParameter[]和IList，类型都是SqlParameter</param>
        /// <param name="strSelect">要查询的字段，默认表别名为T，请带上别名</param>
        /// <returns></returns>
        public DataSet GetListByPage(string table, int startIndex, int endIndex, string orderby, string strWhere = "", object cmdParms = null, string strSelect = "")
        {
            if (string.IsNullOrEmpty(table) || string.IsNullOrEmpty(orderby))
                return null;
            orderby = "order by " + orderby;
            if (string.IsNullOrEmpty(strSelect))
                strSelect = "T.*";
            if (!string.IsNullOrEmpty(strWhere))
                strWhere = "where " + strWhere;
            string sql = string.Format("select * from (select row_number() over ({0}) as row,{1} from {2} {3}) TT where TT.row between {4} and {5}", orderby, strSelect, table, strWhere, startIndex, endIndex);
            return DbHelperSQL.Query(sql, cmdParms);
        }
    }
}
