using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Government_Exams
{
    class My_DB
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=root;database=student");

        //return connection
          public MySqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }




    }
}
