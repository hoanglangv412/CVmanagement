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
    public class PositionLayer
    {
        #region Selectalldata
        /// <summary>
        /// Lay toan bo account
        /// </summary>
        /// <returns value="List<Account>" name="listAccount"></returns>
        public List<Position> Selectalldata()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            List<Position> listPositon = null;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_Position", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", null);
            cmd.Parameters.AddWithValue("@name", null);
            cmd.Parameters.AddWithValue("@Query", 1);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            listPositon = new List<Position>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Position positionObject = new Position();
                positionObject.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                positionObject.Name = ds.Tables[0].Rows[i]["name"].ToString();
                listPositon.Add(positionObject);
            }

            return listPositon;
        }
        #endregion Selectalldata
    }
}