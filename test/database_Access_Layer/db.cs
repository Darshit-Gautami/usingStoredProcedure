using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AngualarCrudeOperation.Models;

namespace AngualarCrudeOperation.database_Acces_Layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        // Add Record
        public void Add_record(register rs)
        {
            SqlCommand com = new SqlCommand("Sp_register", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", rs.Email);
            com.Parameters.AddWithValue("@Password", rs.Password);
            com.Parameters.AddWithValue("@Name", rs.Name);
            com.Parameters.AddWithValue("@Address", rs.Address);
            com.Parameters.AddWithValue("@City", rs.City);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //Display all record
        public DataSet get_record()
        {
            SqlCommand com = new SqlCommand("Sp_register_get", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        // Update all record
        public void update_record(register rs)
        {
            SqlCommand com = new SqlCommand("Sp_register_Update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Sr_no", rs.Sr_no);
            com.Parameters.AddWithValue("@Email", rs.Email);
            com.Parameters.AddWithValue("@Password", rs.Password);
            com.Parameters.AddWithValue("@Name", rs.Name);
            com.Parameters.AddWithValue("@Address", rs.Address);
            com.Parameters.AddWithValue("@City", rs.City);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        // Get Record by id
        public DataSet get_recordbyid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_byid", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Sr_no", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        // Delete record
        public void deletedata(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Sr_no", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet search_data(string search)
        {
            SqlCommand com = new SqlCommand("Sp_Search", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@search", search);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}