using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Government_Exams
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //comboBox1.Items.Add("Student");
        //    //comboBox1.Items.Add("Teacher");
        //    //comboBox1.Items.Add("General");
        //}

     

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        //login button
        private void button_login_Click(object sender, EventArgs e)
        {

        }

        //register button
        private void button_register_Click(object sender, EventArgs e)
        {
            String fname = textBox_register_firstname.Text;
            String lname = textBox_register_lastname.Text;
            String username = textBox_username_register.Text;
            String password = textBox_register_password.Text;
            String email = textBox_register_email.Text;

            //user objedt creation
            user user = new user();


            if (veriffields("register"))
            {
                if (!user.usernameExists(username))
                {
                    if (user.insertUser(fname, lname, username, password, email))
                    {
                        MessageBox.Show("Congratulations! you are now registered", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show("Sorry! something is not right", "Register", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    {
                        MessageBox.Show("Hey! This username is already registered please go to login screen", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

            }
            else
            {
                MessageBox.Show("*Required fields -username/password/email/", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                
           }


        

        //label to go to register page
        private void label_go_to_register_Click(object sender, EventArgs e)
        {
            timer1.Start();
           // timer1.Interval = 5;
            label_go_to_register.Enabled = false;
            label_go_to_login.Enabled = false;
        }

        //show register page at start of this timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(panel2.Location.X > -800)
            {
                panel2.Location = new Point(panel2.Location.X - 10, panel2.Location.Y);
            }
            else
            {
                timer1.Stop();
                label_go_to_login.Enabled = true;
                label_go_to_register.Enabled = true;    
            }
        }
        //show login page at start of this timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Location.X < 0)
            {
                panel2.Location = new Point(panel2.Location.X +15 , panel2.Location.Y);
            }
            else
            {
                timer2.Stop();
                label_go_to_login.Enabled = true;
                label_go_to_register.Enabled = true;
            }
        }

        private void label_go_to_login_Click(object sender, EventArgs e)
        {
            timer2.Start();
            // timer1.Interval = 5;
            label_go_to_register.Enabled = false;
            label_go_to_login.Enabled = false;
        }

        public bool veriffields(string operation)
        {
            bool check = false;
            if(operation == "register")
            {
                 if(textBox_username_register.Text.Equals("") || textBox_register_password.Text.Equals("")|| textBox_register_email.Text.Equals(""))
                 {
                      check = false;
                 }  
                 else
                  {
                    check = true;
                  }
            }

            //if operation is login
            if(operation == "login")
            {
                if(textBox_login_username.Text.Equals("") || textBox_login_password.Text.Equals(""))
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }

            return check;
        }




    }
}
