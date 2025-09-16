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

namespace UsingSha256
{
    public partial class Registrationcs : Form
    {
        public Registrationcs()
        {
            InitializeComponent();
        }
        public void GotoLogin()
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           GotoLogin();
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int[] salt = new int[5];

            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = random.Next(0, 11); 
            }

            SqlConnection conn = new SqlConnection(DatabaseCon.connString);
            string query = "insert into users(Name,Username,Password,Salt) values (@Name,@Username,@Password,@Salt)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name",txtName.Text);
            cmd.Parameters.AddWithValue("@Salt",string.Join("",salt));
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password",Hash1.ComputeSha256Hash(txtPassword.Text+ string.Join("", salt)));           
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Account Created Succesfully");
            GotoLogin();


        }
    }
}
