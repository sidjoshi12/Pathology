using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Pathology
{
    public static class Engine
    {
        public static string cnString;
        public static string dbname;
        public static string ErrorMsg;
        public static void initConn()
        {
            string dataLocation = "local";
            //string dbname = "aadarsh";
            string dbuser = "sa";
            string dbpass = "";


            System.Data.DataSet ds = new System.Data.DataSet();

            ds.ReadXml(Application.StartupPath + "\\app.xml");
            if (ds.Tables.Count > 0)
            {
                System.Data.DataRow dr = ds.Tables[0].Rows[0];
                dataLocation = dr["DomainName"].ToString();
                dbname = dr["DbName"].ToString();
                dbuser = dr["userName"].ToString();
                dbpass = dr["password"].ToString();
            }
            Engine.cnString = "Data Source='" + dataLocation + "';Initial catalog=" + dbname + ";User ID=" + dbuser + ";Password=" + dbpass;
        }
        public static bool ExecuteQry(string qry)
        {
            SqlConnection cn = new SqlConnection(cnString);
            SqlCommand cmd = new SqlCommand();
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = qry;
            try
            {
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception ex)
            {
                cn.Close();
                ErrorMsg = ex.Message;
                return false;
            }
        }

        public static SqlDataReader getDataReader(string Sql_Qry)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand SqlCmd = new SqlCommand();
            SqlDataReader dr;
            cn.ConnectionString = cnString;
            cn.Open();
            SqlCmd.Connection = cn;
            SqlCmd.CommandText = Sql_Qry;
            dr = SqlCmd.ExecuteReader();
            return dr;
        }

        public static string getValue(string Para_Qry)
        {
            SqlConnection cn = new SqlConnection(cnString);
            SqlCommand SqlCmd = new SqlCommand();
            SqlDataReader dr;
            cn.Open();
            SqlCmd.Connection = cn;
            SqlCmd.CommandText = Para_Qry;
            dr = SqlCmd.ExecuteReader();
            if (dr.Read() == true)
                return dr[0].ToString().ToString();
            else
                return null;
        }
        public static DataTable getDataTable(string Sql_Qry, string TableName = "table1")
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cnString;
            cn.Open();
            SqlDataAdapter SqlAd = new SqlDataAdapter(Sql_Qry, cn);
            DataTable dt = new DataTable(TableName);
            SqlAd.Fill(dt);
            return dt;
        }
        public static DataRow getDataRow(string Sql_Qry)
        {
            DataRow dr = null;
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = cnString;
                    cn.Open();
                    SqlDataAdapter SqlAd = new SqlDataAdapter(Sql_Qry, cn);
                    DataTable dt = new DataTable();
                    SqlAd.Fill(dt);
                    if (dt.Rows.Count > 0)
                        dr = dt.Rows[0];
                }
            }
            catch (Exception ex)
            {
                Engine.ErrorMsg = ex.Message;
            }
            return dr;
        }
        public static bool ValidateAndExecute(string[] sql)
        {
            bool status = false;
            SqlConnection db = new SqlConnection(cnString);
            SqlTransaction transaction;

            db.Open();
            transaction = db.BeginTransaction();
            try
            {
                foreach (string statement in sql)
                {
                    new SqlCommand(statement, db, transaction).ExecuteNonQuery();
                }
                transaction.Commit();
                status = true;
            }
            catch (SqlException sqlError)
            {
                transaction.Rollback();
                status = false;
                ErrorMsg = sqlError.Message;
            }
            db.Close();
            return status;
        }
        public static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }
        public static bool ValidateAndUpdate(string[] sql, byte[] img)
        {
            bool status = false;
            SqlConnection db = new SqlConnection(cnString);
            SqlTransaction transaction;
            SqlCommand cmd;

            db.Open();
            transaction = db.BeginTransaction();
            try
            {
                if (sql.Length > 1)
                {
                    cmd = new SqlCommand(sql[0], db, transaction);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(sql[1], db, transaction);
                    if (img == null)
                    {
                        SqlParameter param = new SqlParameter("@img", System.Data.SqlDbType.Image);
                        param.Value = DBNull.Value;
                        cmd.Parameters.Add(param);
                    }
                    else
                        cmd.Parameters.AddWithValue("@img", img);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand(sql[0], db, transaction);
                    if (img == null)
                    {
                        SqlParameter param = new SqlParameter("@img", System.Data.SqlDbType.Image);
                        param.Value = DBNull.Value;
                        cmd.Parameters.Add(param);
                    }
                    else
                        cmd.Parameters.AddWithValue("@img", img);
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                status = true;
            }
            catch (SqlException sqlError)
            {
                transaction.Rollback();
                status = false;
                ErrorMsg = sqlError.Message;
            }
            db.Close();
            return status;
        }
        public static DataSet getDataSet(string Sql_Qry)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cnString;
            cn.Open();
            SqlDataAdapter SqlAd = new SqlDataAdapter(Sql_Qry, cn);
            DataSet ds = new DataSet();
            SqlAd.Fill(ds);
            return ds;
        }
    }
}
