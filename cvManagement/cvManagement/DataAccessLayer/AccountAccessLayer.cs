using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace cvManagement.DataAccessLayer
{
    public class AccountAccessLayer
    {
        #region Selectalldata
        /// <summary>
        /// Lay toan bo account
        /// </summary>
        /// <returns value="List<Account>" name="listAccount"></returns>
        public List<Account> Selectalldata()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            List<Account> listAccount = null;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_Account", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", null);
            cmd.Parameters.AddWithValue("@name", null);
            cmd.Parameters.AddWithValue("@password", null);
            cmd.Parameters.AddWithValue("@role", null);
            cmd.Parameters.AddWithValue("@Query", 4);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            listAccount = new List<Account>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Account cobj = new Account();
                cobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                cobj.Name = ds.Tables[0].Rows[i]["name"].ToString();
                cobj.PassWord = ds.Tables[0].Rows[i]["password"].ToString();
                cobj.Role = Convert.ToInt32(ds.Tables[0].Rows[i]["role"].ToString());
                listAccount.Add(cobj);
            }

            return listAccount;
        }
        #endregion Selectalldata

        #region InsertData
        /// <summary>
        /// Them vao 1 account
        /// </summary>
        /// <param name="account" value="Account"></param>
        /// <returns name="result" value="string"></returns>
        public string Insertdata(Account account)
        {
            SqlConnection conn = null;
            String result = "";
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", account.Name);
                cmd.Parameters.AddWithValue("@password", account.PassWord);
                cmd.Parameters.AddWithValue("@role", account.Role);
                cmd.Parameters.AddWithValue("@Query", 1);
                conn.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {

                return result = null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion InsertData

        #region Updatedata
        /// <summary>
        /// Cap nhat du lieu 1 account
        /// </summary>
        /// <param name="account" value="Account"></param>
        /// <returns name="result" value="string"></returns>
        public string Updatedata(Account account)
        {
            SqlConnection conn = null;
            String result = "";
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", account.Id);
                cmd.Parameters.AddWithValue("@name", account.Name);
                cmd.Parameters.AddWithValue("@password", account.PassWord);
                cmd.Parameters.AddWithValue("@role", account.Role);
                cmd.Parameters.AddWithValue("@Query", 2);
                conn.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {

                return result = null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion Updatedata

        #region SelectDataById
        /// <summary>
        /// Lay ra 1 account theo id
        /// </summary>
        /// <param name="accountId" value="string"></param>
        /// <returns name="foundAccount" value="Account"></returns>
        public Account SelectDataById(string accountId)
        {
            SqlConnection conn = null;
            Account foundAccount = null;
            DataSet ds = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", accountId);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@password", null);
                cmd.Parameters.AddWithValue("@role", null);
                cmd.Parameters.AddWithValue("@query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foundAccount = new Account();
                    foundAccount.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    foundAccount.Name = ds.Tables[0].Rows[i]["name"].ToString();
                    foundAccount.PassWord = ds.Tables[0].Rows[i]["password"].ToString();
                    foundAccount.Role = Convert.ToInt32(ds.Tables[0].Rows[i]["role"].ToString());
                }

                return foundAccount;
            }
            catch (Exception)
            {

                return foundAccount;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion SelectDataById

        #region DeleteData
        /// <summary>
        /// Xoa 1 account
        /// </summary>
        /// <param name="ID" value="int"></param>
        /// <returns name="result" value="int"></returns>
        public int DeleteData(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@password", null);
                cmd.Parameters.AddWithValue("@role", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion DeleteData

        #region CheckPasswordAndId
        /// <summary>
        /// kiem tra co ton tai password
        /// </summary>
        /// <param name="ID" value="int"></param>
        /// <returns name="result" value="int"></returns>
        public bool CheckPasswordAndId(String password, int id)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", null);
                cmd.Parameters.AddWithValue("@query", 6);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion CheckPasswordAndId
    }
}