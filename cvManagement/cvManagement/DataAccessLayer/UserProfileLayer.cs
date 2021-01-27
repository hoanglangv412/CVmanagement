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
    public class UserProfileLayer
    {
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public string InsertData(userProfile pro)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@positionId", pro.PositionId);
                cmd.Parameters.AddWithValue("@sourceId", pro.SourceId);
                cmd.Parameters.AddWithValue("@applyDate", pro.ApplyDate);
                cmd.Parameters.AddWithValue("@cvResult", pro.CvResult);
                cmd.Parameters.AddWithValue("@cvLink", pro.CvLink);
                cmd.Parameters.AddWithValue("@note", pro.Note);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }

            catch
            {
                return result = "";
            }

            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Update database
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public string UpdateData(userProfile pro)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", pro.Id);
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@positionId", pro.PositionId);
                cmd.Parameters.AddWithValue("@sourceId", pro.SourceId);
                cmd.Parameters.AddWithValue("@applyDate", pro.ApplyDate);
                cmd.Parameters.AddWithValue("@cvResult", pro.CvResult);
                cmd.Parameters.AddWithValue("@interviewDate", pro.InterviewDate);
                cmd.Parameters.AddWithValue("@interviewResult", pro.InterviewResult);
                cmd.Parameters.AddWithValue("@status", pro.Status);
                cmd.Parameters.AddWithValue("@cvLink", pro.CvLink);
                cmd.Parameters.AddWithValue("@note", pro.Note);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Select all data
        /// </summary>
        /// <returns></returns>
        public List<userProfile> Selectalldata()
        {
            SqlConnection con = null;
            List<userProfile> ListProfile = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@positionId", null);
                cmd.Parameters.AddWithValue("@sourceId", null);
                cmd.Parameters.AddWithValue("@applyDate", null);
                cmd.Parameters.AddWithValue("@cvResult", null);
                cmd.Parameters.AddWithValue("@interviewDate", null);
                cmd.Parameters.AddWithValue("@interviewResult", null);
                cmd.Parameters.AddWithValue("@status", null);
                cmd.Parameters.AddWithValue("@cvLink", null);
                cmd.Parameters.AddWithValue("@note", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);
                ListProfile = new List<userProfile>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    userProfile pro = new userProfile
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                        PositionId = Convert.ToInt32(ds.Tables[0].Rows[i]["positionId"].ToString()),
                        SourceId = Convert.ToInt32(ds.Tables[0].Rows[i]["sourceId"].ToString()),
                        ApplyDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["applyDate"].ToString()),
                        CvResult = Convert.ToInt32(ds.Tables[0].Rows[i]["cvResult"].ToString()),
                        InterviewDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["interviewDate"].ToString()),
                        InterviewResult = Convert.ToInt32(ds.Tables[0].Rows[i]["interviewResult"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["status"].ToString()),
                        CvLink = ds.Tables[0].Rows[i]["name"].ToString(),
                        Note = ds.Tables[0].Rows[i]["name"].ToString()
                    };

                    ListProfile.Add(pro);
                }

                return ListProfile;
            }

            catch
            {
                return ListProfile;
            }

            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Select data by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public userProfile SelectDatabyID(string Id)
        {
            SqlConnection con = null;
            userProfile pro = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@sourceId", null);
                cmd.Parameters.AddWithValue("@positionId", null);
                cmd.Parameters.AddWithValue("@applyDate", null);
                cmd.Parameters.AddWithValue("@cvResult", null);
                cmd.Parameters.AddWithValue("@interviewDate", null);
                cmd.Parameters.AddWithValue("@interviewResult", null);
                cmd.Parameters.AddWithValue("@status", null);
                cmd.Parameters.AddWithValue("@cvLink", null);
                cmd.Parameters.AddWithValue("@note", null);
                cmd.Parameters.AddWithValue("@Query", 4);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    pro = new userProfile
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                        PositionId = Convert.ToInt32(ds.Tables[0].Rows[i]["positionId"].ToString()),
                        SourceId = Convert.ToInt32(ds.Tables[0].Rows[i]["sourceId"].ToString()),
                        ApplyDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["applyDate"].ToString()),
                        CvResult = Convert.ToInt32(ds.Tables[0].Rows[i]["cvResult"].ToString()),
                        InterviewDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["interviewDate"].ToString()),
                        InterviewResult = Convert.ToInt32(ds.Tables[0].Rows[i]["interviewResult"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["status"].ToString()),
                        CvLink = ds.Tables[0].Rows[i]["name"].ToString(),
                        Note = ds.Tables[0].Rows[i]["name"].ToString()
                    };
                }

                return pro;
            }

            catch
            {
                return pro;
            }

            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Search Profile by Name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<userProfile> SearchProfileByName(string Name)
        {
            SqlConnection con = null;
            userProfile searchProfile;
            List<userProfile> listSearchProfile = new List<userProfile>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@sourceId", null);
                cmd.Parameters.AddWithValue("@positionId", null);
                cmd.Parameters.AddWithValue("@applyDate", null);
                cmd.Parameters.AddWithValue("@cvResult", null);
                cmd.Parameters.AddWithValue("@interviewDate", null);
                cmd.Parameters.AddWithValue("@interviewResult", null);
                cmd.Parameters.AddWithValue("@status", null);
                cmd.Parameters.AddWithValue("@cvLink", null);
                cmd.Parameters.AddWithValue("@note", null);
                cmd.Parameters.AddWithValue("@Query", 5);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    searchProfile = new userProfile
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                        PositionId = Convert.ToInt32(ds.Tables[0].Rows[i]["positionId"].ToString()),
                        SourceId = Convert.ToInt32(ds.Tables[0].Rows[i]["sourceId"].ToString()),
                        ApplyDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["applyDate"].ToString()),
                        CvResult = Convert.ToInt32(ds.Tables[0].Rows[i]["cvResult"].ToString()),
                        InterviewDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["interviewDate"].ToString()),
                        InterviewResult = Convert.ToInt32(ds.Tables[0].Rows[i]["interviewResult"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["status"].ToString()),
                        CvLink = ds.Tables[0].Rows[i]["name"].ToString(),
                        Note = ds.Tables[0].Rows[i]["name"].ToString()
                    };
                    listSearchProfile.Add(searchProfile);
                }

                return listSearchProfile;
            }

            catch (Exception)
            {
                return listSearchProfile = null;
            }

            finally
            {
                con.Close();
            }
        }
    }
}