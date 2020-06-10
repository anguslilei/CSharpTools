using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CSharpTools.DB
{
    /// <summary>
    /// MariaDB数据库处理
    /// </summary>
    class MariaDBHelper
    {
        MySqlConnection conn = null;
        MySqlDataAdapter adapter;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="server">服务器IP</param>
        /// <param name="userid">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="database">数据库名称</param>
        /// <param name="port">端口号</param>
        public MariaDBHelper(string server, string userid, string password, string database, int port = 3306)
        {
            string connStr = string.Format("server={0};user id={1}; password={2}; port={3}; database={4};charset=utf8", server, userid, password, port, database);
            conn = new MySqlConnection(connStr);
            conn.Open();
        }
        public bool Execute(string exeCmd, out DataTable dataTable)
        {
            dataTable = new DataTable();
            try
            {

                adapter = new MySqlDataAdapter(exeCmd, conn);
                adapter.Fill(dataTable);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public int ExecuteCmd(string cmd)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(cmd, conn);
                int affectLines = command.ExecuteNonQuery();
                return affectLines;
            }
            catch (Exception exp)
            {
                return 0;
            }
        }
        /// <summary>
        /// 事物处理
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool ExecuteTrans(string cmd)
        {
            MySqlTransaction transaction = conn.BeginTransaction();
            MySqlCommand command = conn.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = cmd;
            try
            {
                int affectLines = command.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception)
                {

                    throw;
                }
                return false;
            }
        }
    }
}
