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
    public class EmailTemplateLayer
    {
        #region Selectalldata
        /// <summary>
        /// Lay toan bo email template
        /// </summary>
        /// <returns value="List<emailTemplate>" name="listEmailTemplate"></returns>
        public List<emailTemplate> Selectalldata()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            List<emailTemplate> listEmailTemplate = null;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", null);
            cmd.Parameters.AddWithValue("@name", null);
            cmd.Parameters.AddWithValue("@content", null);
            cmd.Parameters.AddWithValue("@Query", 4);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            listEmailTemplate = new List<emailTemplate>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                emailTemplate cobj = new emailTemplate();
                cobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                cobj.Name = ds.Tables[0].Rows[i]["name"].ToString();
                cobj.Content = ds.Tables[0].Rows[i]["content"].ToString();
                listEmailTemplate.Add(cobj);
            }

            return listEmailTemplate;
        }
        #endregion Selectalldata

        #region InsertData
        /// <summary>
        /// Them vao 1 email template
        /// </summary>
        /// <param name="emailtemplate" value="emailTemplate"></param>
        /// <returns name="result" value="string"></returns>
        public string Insertdata(emailTemplate emailtemplate)
        {
            SqlConnection conn = null;
            String result = "";
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", emailtemplate.Name);
                cmd.Parameters.AddWithValue("@content", emailtemplate.Content);
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
        /// Cap nhat du lieu 1 email template
        /// </summary>
        /// <param name="emailtemplate" value="emailTemplate"></param>
        /// <returns name="result" value="string"></returns>
        public string Updatedata(emailTemplate emailtemplate)
        {
            SqlConnection conn = null;
            String result = "";

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", emailtemplate.Id);
                cmd.Parameters.AddWithValue("@name", emailtemplate.Name);
                cmd.Parameters.AddWithValue("@content", emailtemplate.Content);
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
        /// Lay ra 1 email template theo id
        /// </summary>
        /// <param name="EmailTemplateId" value="string"></param>
        /// <returns name="foundTemplate" value="emailTemplate"></returns>
        public emailTemplate SelectDataById(string EmailTemplateId)
        {
            SqlConnection conn = null;
            emailTemplate foundTemplate = null;
            DataSet ds = null;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", EmailTemplateId);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@content", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foundTemplate = new emailTemplate();
                    foundTemplate.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    foundTemplate.Name = ds.Tables[0].Rows[i]["name"].ToString();
                    foundTemplate.Content = ds.Tables[0].Rows[i]["content"].ToString();
                }

                return foundTemplate;
            }
            catch (Exception)
            {

                return foundTemplate;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion SelectDataById

        #region SearchDataByName
        /// <summary>
        /// Tim template theo ten
        /// </summary>
        /// <param name="templateName" value="string"></param>
        /// <returns name="listFoundTemplate" value="List<emailTemplate>"></returns>
        public List<emailTemplate> SearchDataByName(string templateName)
        {
            SqlConnection conn = null;
            DataSet ds = null;
            emailTemplate foundTemplate = null;
            List<emailTemplate> listFoundTemplate = new List<emailTemplate>();
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", templateName);
                cmd.Parameters.AddWithValue("@content", null);
                cmd.Parameters.AddWithValue("@Query", 6);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foundTemplate = new emailTemplate();
                    foundTemplate.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    foundTemplate.Name = ds.Tables[0].Rows[i]["name"].ToString();
                    foundTemplate.Content = ds.Tables[0].Rows[i]["content"].ToString();
                    listFoundTemplate.Add(foundTemplate);
                }

                return listFoundTemplate;
            }
            catch (Exception)
            {

                return listFoundTemplate = null;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion SearchDataByName

        #region DeleteData
        /// <summary>
        /// Xoa 1 template
        /// </summary>
        /// <param name="ID" value="string"></param>
        /// <returns name="result" value="int"></returns>
        public int DeleteData(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@content", null);
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
    }
}