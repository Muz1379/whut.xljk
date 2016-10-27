using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
using COMMON;

namespace whut.xljk.DAL
{
    public class infoadminDAL
    {
        /// <summary>
        /// 查找管理员
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable GetInfoAdmin(string username)
        {
            string sql = "select * from T_InfoAdmin where C_InfoAdminAccount=@name";
            SqlParameter[] sp = { new SqlParameter("@name", username) };
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_InfoAdminAccount,C_InfoAdminPwd,C_InfoAdminSector,C_InfoAdminCategory,C_InfoAdminName,C_InfoAdminTel,C_InfoAdminEmail");
            strSql.Append(" FROM T_InfoAdmin ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        public T_InfoAdmin getAdminByID(string id)
        {
            string strSql = "select * from T_InfoAdmin where C_InfoAdminAccount = '"+id+"'";
            T_InfoAdmin model = new T_InfoAdmin();
            DataSet tb = DbHelperSQL.Query(strSql.ToString());
            if (tb.Tables[0].Rows.Count > 0)
            {
                model = DataRowToModel(tb.Tables[0].Rows[0]);
            }
            return model;

        }
        
        /// <summary>
        /// 转化datarow 到文章实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public T_InfoAdmin DataRowToModel(DataRow row)
        {
            T_InfoAdmin model = new T_InfoAdmin();
            if (row != null)
            {
                if (row["C_InfoAdminName"] != null && row["C_InfoAdminName"].ToString() != "")
                {
                    model.InfoAdminName = row["C_InfoAdminName"].ToString();
                }
                if (row["C_InfoAdminAccount"] != null)
                {
                    model.InfoAdminAccount = row["C_InfoAdminAccount"].ToString();
                }
                if (row["C_InfoAdminTel"] != null)
                {
                    model.InfoAdminTel = row["C_InfoAdminTel"].ToString();
                }
                if (row["C_InfoAdminEmail"] != null)
                {
                    model.InfoAdminEmail = row["C_InfoAdminEmail"].ToString();
                }
                if (row["C_InfoAdminPwd"] != null)
                {
                    model.InfoAdminPwd = row["C_InfoAdminPwd"].ToString();
                }
                if (row["C_InfoAdminCategory"] != null && row["C_InfoAdminCategory"].ToString() != "")
                {
                    model.InfoAdminCategory = int.Parse(row["C_InfoAdminCategory"].ToString());
                }
            }
            return model;

        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">传入model类</param>
        /// <returns></returns>
        public int InsertInfoAdmin(T_InfoAdmin model)
        { //C_InfoAdminAccount, C_InfoAdminPwd, C_InfoAdminSector, C_InfoAdminCategory, C_InfoAdminName, C_InfoAdminTel, C_InfoAdminEmail
            string sql = "insert into T_InfoAdmin(C_InfoAdminAccount,C_InfoAdminPwd, C_InfoAdminSector,C_InfoAdminCategory,C_InfoAdminName,C_InfoAdminTel,C_InfoAdminEmail) values(@account,@pwd,@sector,@category,@name,@tel,@email)";
            SqlParameter[] pms = new SqlParameter[] {
            new SqlParameter("@account",model.InfoAdminAccount),
            new SqlParameter("@pwd",model.InfoAdminPwd),
            new SqlParameter("@sector",model.InfoAdminSector),
            new SqlParameter("@category",model.InfoAdminCategory),
            new SqlParameter("@name",model.InfoAdminName),
            new SqlParameter("@tel",model.InfoAdminTel),
            new SqlParameter("@email",model.InfoAdminEmail),
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }

        //修改信息发布者
        public bool UpdateInfoAdmin(T_InfoAdmin model)
        {  //C_InfoAdminAccount, C_InfoAdminPwd, C_InfoAdminSector, C_InfoAdminCategory, C_InfoAdminName, C_InfoAdminTel, C_InfoAdminEmail
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_InfoAdmin  set ");
            strSql.Append("C_InfoAdminPwd=@pwd,");
            strSql.Append("C_InfoAdminName=@name,");
            strSql.Append("C_InfoAdminTel=@tel,");
            strSql.Append("C_InfoAdminEmail=@email");
            strSql.Append(" where C_InfoAdminAccount=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Char,8),
                    new SqlParameter("@pwd", SqlDbType.NVarChar,100),
                    new SqlParameter("@name", SqlDbType.NVarChar,40),
                    new SqlParameter("@tel", SqlDbType.Char,11),
                    new SqlParameter("@email", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.InfoAdminAccount;
            parameters[1].Value = model.InfoAdminPwd;
            parameters[2].Value = model.InfoAdminName;
            parameters[3].Value = model.InfoAdminTel;
            parameters[4].Value = model.InfoAdminEmail;
            int flag = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //删除
        public bool DeleteInfoAdmin(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_InfoAdmin ");
            strSql.Append("where C_InfoAdminAccount=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Char,8)
            };
            parameters[0].Value = id;
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
