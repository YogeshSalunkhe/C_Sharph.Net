using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CLG_MGT_System
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
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
            if (tb_Username.Text == "a" && tb_Password.Text == "a")
            {
                MessageBox.Show("Login Successfully !!!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            tb_Password.Enabled = false;
            btn_Submit.Enabled = false;
        }

       
        
    }
}
