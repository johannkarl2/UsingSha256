using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UsingSha256
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registrationcs registration = new Registrationcs();
            this.Hide();
            registration.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(DatabaseCon.connString);
            string query = "SELECT Username, Salt, Password FROM Users WHERE Username = @Username;";
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        string storedUsername = reader["Username"].ToString();
                        string storedSalt = reader["Salt"].ToString();
                        string storedPasswordHash = reader["Password"].ToString();

                        string enteredPasswordHash = Hash1.ComputeSha256Hash(txtPassword.Text + storedSalt);

                        if (enteredPasswordHash == storedPasswordHash)
                        {
                            HomePage homePage = new HomePage();
                            homePage.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Credentials");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credentials");
                    }
                }
            }
        }
    }
}
