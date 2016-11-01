using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.xljk.DAL;
using whut.xljk.MODEL;

namespace whut.xljk.BLL
{

    public class infoadminBLL
    {
        infoadminDAL dal = new infoadminDAL();
        
        /// <summary>
        /// 获得adminmodel
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public T_InfoAdmin GetInfoAdmin(string username)
        {
            T_InfoAdmin InfoAdminmodel = new T_InfoAdmin();
            DataTable InfoAdminTab = dal.GetInfoAdmin(username);
            if (InfoAdminTab.Rows.Count > 0)
            {
                InfoAdminmodel.InfoAdminAccount = InfoAdminTab.Rows[0]["C_InfoAdminAccount"].ToString();
                InfoAdminmodel.InfoAdminPwd = InfoAdminTab.Rows[0]["C_InfoAdminPwd"].ToString(); InfoAdminmodel.InfoAdminName = InfoAdminTab.Rows[0]["C_InfoAdminName"].ToString();
                InfoAdminmodel.InfoAdminTel = InfoAdminTab.Rows[0]["C_InfoAdminTel"].ToString();
                InfoAdminmodel.InfoAdminEmail = InfoAdminTab.Rows[0]["C_InfoAdminEmail"].ToString();
                InfoAdminmodel.InfoAdminSector = InfoAdminTab.Rows[0]["C_InfoAdminSector"].ToString();
                InfoAdminmodel.InfoAdminCategory = (int)InfoAdminTab.Rows[0]["C_InfoAdminCategory"];
            }
            return InfoAdminmodel;
        }

        /// <summary>
        /// 获取所有的文章列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        public T_InfoAdmin getAdminByID(string username)
        {
            return dal.getAdminByID(username);
        }

        /// <summary>
        /// 业务逻辑层添加model方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(T_InfoAdmin model)
        {
            return dal.InsertInfoAdmin(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_InfoAdmin model)
        {
            return dal.UpdateInfoAdmin(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.DeleteInfoAdmin(id);
        }

        public DataTable GetInfoAdminTeacherList()
        {
            return dal.GetInfoAdminTeacherList();
        }
    }
}
