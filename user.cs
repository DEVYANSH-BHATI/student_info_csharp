using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Government_Exams
{
    class user
    {
        My_DB db = new My_DB();
        //checking for existing username
        public bool usernameExists(string username)
        {
            string query = "select*from 'student_data' where 'uname' =@un";
            MySqlCommand command = new MySqlCommand(query, db.getConnection);
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //inserting new user
        public bool insertUser(string fname,string lname,string username , string password,string email)
        {
            MySqlCommand command = new MySqlCommand("insert into 'student_data'('fname', 'lname', 'uname', 'password', 'email') Values(@fn,@ln,@un,@pass,@email)",db.getConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value =  username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }


        }









    }
}
