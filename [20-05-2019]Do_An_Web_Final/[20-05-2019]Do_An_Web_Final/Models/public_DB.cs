using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI;

namespace Do_An_Web_Final.Models
{
    public class public_DB
    {
        public static String strConn = ConfigurationManager.ConnectionStrings["strConn_shop_banHang"].ConnectionString;

        public static SqlConnection getConnection()
        {
            SqlConnection conn = null;
            conn = new SqlConnection(strConn);
            conn.Open();

            return conn;
        }

        public static bool isConnection()
        {
            try
            {
                using (getConnection())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static DataTable getData_TO_DATATABLE(SqlCommand cmd)
        {
            using (cmd.Connection = getConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
        }

        public static int thucThiCauLenh(SqlCommand cmd)
        {
            using (cmd.Connection = getConnection())
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public static String maHoa(String oldPassword)
        {
            StringBuilder newPass = new StringBuilder();
            MD5 md5 = MD5.Create();
            Byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(oldPassword));
            for (int i = 0; i < data.Length; i++)
            {
                newPass.Append(data[i].ToString("x2"));
            }

            return newPass.ToString();
        }

        public static int getSoLuong(SqlCommand cmd)
        {
            using (cmd.Connection = getConnection())
            {
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
        }

        public static String getClassActive(int n)
        {
            if (n == 0) return "active";
            return "";
        }
    }
}