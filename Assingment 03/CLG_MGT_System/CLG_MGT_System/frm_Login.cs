using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CLG_MGT_System
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Y_Student_Details_DB;Integrated Security=True");

        void Con_Open()
        {
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
        }
        void Con_Close()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Con.Close();
            }
        }
        private void tb_Username_TextChanged(object sender, EventArgs e)
        {
            lbl_Error.Visible = true;
            tb_Password.Enabled = true;
        }
        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            btn_Submit.Enabled = true;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            int Cnt = 0;

            Con_Open();

            SqlCommand Cmd = new SqlCommand();

            Cmd.Connection = Con;
            Cmd.CommandText = "Select Count (*) From Login_Details Where Username = @Uname And Password = @Pass";

            Cmd.Parameters.Add("Uname",SqlDbType.NVarChar).Value = tb_Username.Text;
            Cmd.Parameters.Add("Pass",SqlDbType.NVarChar).Value = tb_Password.Text;

            Cnt = Convert.ToInt32(Cmd.ExecuteScalar());

            if (Cnt > 0)
            {
                MessageBox.Show("Login Successfully !!!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Shared_Class.Username = "Welcome " + tb_Username.Text;

                frm_Add_New_Student_Details obj = new frm_Add_New_Student_Details();
                this.Hide();
                obj.Show();
            }
            else
            {
                lbl_Error.Text = "Invalid Username Or Password.";
                tb_Username.Clear();
                tb_Password.Clear();
            }
            

            Con_Close();

            tb_Password.Enabled = false;
            btn_Submit.Enabled = false;
        }

       
        
    }
}
