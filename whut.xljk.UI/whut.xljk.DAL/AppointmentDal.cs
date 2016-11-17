using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.COMMON;
using whut.xljk.MODEL;
namespace whut.xljk.DAL
{
    public class AppointmentDal
    {
        //学生板块
        public DataTable Getlist(string para)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("select * from T_Appointment where id=@id");
            SqlParameter[] paras={
                    new SqlParameter("@id",para)
                                 };
            return SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text,paras);
        }

        public int updateTdInfo(Td tdinfo)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("update T_Appointment set appo_time=@appotime,t_name=@tname,state=@state where id=@id");
            SqlParameter[] paras={
                                     new SqlParameter("@id",tdinfo.name),
                                     new SqlParameter("@appotime",tdinfo.time),
                                     new SqlParameter("@tname",tdinfo.t_name),
                                     new SqlParameter("@state",tdinfo.state)
                                 };
            return SqlHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, paras);
        }
        //管理员板块
        public DataTable GetData(string para)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from T_apoinfo");
            SqlParameter[] paras = {
                                  
                                   };
            DataTable dt = new DataTable();
            dt=SqlHelper.ExecuteDataTable(sb.ToString(), CommandType.Text, paras);
            return dt;
        }
        public int insert_apoinfo(T_stuinfo ts)
        {
            string sname=ts.sname;
            string sgender=ts.sgender;
            string sphone=ts.sphone;
            string tname=ts.tname;
            string apotime=ts.apo_time;
            string remark=ts.remark;
            StringBuilder sb=new StringBuilder();
            sb.Append("insert into T_apoinfo values(");
            sb.Append("@sname,@sphone,@tname,@sgender,@apotime,@remark");
            sb.Append(")");
            SqlParameter[] paras={
                                     new SqlParameter("@sname",sname),
                                     new SqlParameter("@sphone",sphone),
                                      new SqlParameter("@tname",tname),
                                     new SqlParameter("@sgender",sgender),                             
                                     new SqlParameter("@apotime",apotime),
                                     new SqlParameter("@remark",remark),
                                    
                                 };
            return SqlHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, paras);
        }
        public int delectData(string name,string phone)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("delete from T_apoinfo where C_stuname=@sname and C_stuphone=@sphone");
            SqlParameter[] paras={
                                     new SqlParameter("@sname",name),
                                     new SqlParameter("@sphone",phone)
                                 };
            return SqlHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, paras);

        }
    }
}
