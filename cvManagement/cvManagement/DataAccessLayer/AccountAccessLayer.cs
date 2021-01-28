using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cvManagement.DataAccessLayer
{
    public class AccountAccessLayer
    {
        const int query1 = 1;
        const int query2 = 2;
        const int query4 = 4;
        const int query3 = 3;
        const int query5 = 5;

        #region Selectalldata
        /// <summary>
        /// Lay toan bo account
        /// </summary>
        /// <returns value="List<Account>" name="listAccount"></returns>
        public List<Account> Selectalldata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_Account", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id", null);
            cmd.Parameters.AddWithValue("@name", null);
            cmd.Parameters.AddWithValue("@password", null);
            cmd.Parameters.AddWithValue("@role", null);
            cmd.Parameters.AddWithValue("@Query", query4);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = cmd
            };
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Account> listAccount = new List<Account>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Account cobj = new Account
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                    Name = ds.Tables[0].Rows[i]["name"].ToString(),
                    PassWord = ds.Tables[0].Rows[i]["password"].ToString(),
                    Role = Convert.ToInt32(ds.Tables[0].Rows[i]["role"].ToString())
                };
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
            SqlConnection con = null;
            string result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", account.Name);
                cmd.Parameters.AddWithValue("@password", account.PassWord);
                cmd.Parameters.AddWithValue("@role", account.Role);
                cmd.Parameters.AddWithValue("@Query", query1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {

                return result = null;
            }
            finally
            {
                con.Close();
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
            SqlConnection con = null;
            string result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", account.Id);
                cmd.Parameters.AddWithValue("@name", account.Name);
                cmd.Parameters.AddWithValue("@password", account.PassWord);
                cmd.Parameters.AddWithValue("@role", account.Role);
                cmd.Parameters.AddWithValue("@Query", query2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {

                return result = null;
            }
            finally
            {
                con.Close();
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
            SqlConnection con = null;
            Account foundAccount = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_Account", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", accountId);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@password", null);
                cmd.Parameters.AddWithValue("@role", null);
                cmd.Parameters.AddWithValue("@query", query5);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foundAccount = new Account
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                        PassWord = ds.Tables[0].Rows[i]["password"].ToString(),
                        Role = Convert.ToInt32(ds.Tables[0].Rows[i]["role"].ToString())
                    };
                }

                return foundAccount;
            }
            catch (Exception)
            {

                return foundAccount;
            }
            finally
            {
                con.Close();
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
                SqlCommand cmd = new SqlCommand("Usp_Account", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@password", null);
                cmd.Parameters.AddWithValue("@role", null);
                cmd.Parameters.AddWithValue("@Query", query3);
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
    }
}