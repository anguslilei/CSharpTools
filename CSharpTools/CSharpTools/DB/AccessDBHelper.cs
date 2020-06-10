using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace CSharpTools.DB
{
    /// <summary>
    /// 用于访问Access数据库
    /// </summary>
    class AccessDBHelper
    {
        OleDbConnection conn = null;
        OleDbDataAdapter adapter = null;
        OleDbCommandBuilder cmd = null;
        /// <summary>
        /// Access数据库连接
        /// </summary>
        /// <param name="source">accdb文件目录</param>
        public AccessDBHelper(string source,string provider= "Microsoft.ACE.OleDB.12.0")
        {
            var oleString = new OleDbConnectionStringBuilder
            {
                Provider = provider,
                DataSource = source
            };
            conn = new OleDbConnection { ConnectionString = oleString.ToString() };
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="exeCmd"></param>
        /// <param name="dataTable">查询结果数据表</param>
        /// <returns></returns>
        public bool Execute(string exeCmd, out DataTable dataTable)
        {
            dataTable = new DataTable();
            try
            {

                adapter = new OleDbDataAdapter(exeCmd, conn);
                adapter.Fill(dataTable);
                return true;
            }
            catch
            {
                return false;
            }

        }
        //关闭数据库连接
        public void Close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

    }
}
