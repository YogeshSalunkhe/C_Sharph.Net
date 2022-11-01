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
    public partial class frm_Search_Student_Details : Form
    {
        public frm_Search_Student_Details()
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
        void Clear_Controls()
        {
            tb_Roll_No.Text = "";

            tb_Name.Text = "";
            tb_Mob_No.Text = "";
            cmb_Course.SelectedIndex = -1;
            dtp_D_O_B.Text = "01/01/2006";
        }
        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            tb_Name.Enabled = true;
            tb_Mob_No.Enabled = true;
            cmb_Course.Enabled = true;
            dtp_D_O_B.Enabled = true;

            Con_Open();

            SqlCommand Cmd = new SqlCommand("Select * From Student_Details Where Roll_No = @Rno", Con);

            Cmd.Parameters.Add("Rno", SqlDbType.Int).Value = tb_Roll_No.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                tb_Name.Text = Dr.GetString(Dr.GetOrdinal("Name"));
                tb_Mob_No.Text = (Dr["Mobile_No"].ToString());
                cmb_Course.Text = Dr.GetString(Dr.GetOrdinal("Course"));
                dtp_D_O_B.Text = (Dr["DOB"].ToString());
            }
            else
            {
                MessageBox.Show("No Record Found", "Invalid Roll No");
                tb_Roll_No.Clear();
            }

            Con_Close();
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Controls();
        }
        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student_Details obj = new frm_Add_New_Student_Details();

            this.Hide();
            obj.Show();
        }
        private void btn_View_Student_Details_Click(object sender, EventArgs e)
        {
            frm_Veiw_Student_Details obj = new frm_Veiw_Student_Details();

            this.Hide();
            obj.Show();
        }
        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are Sure To LogOut???", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (Res == DialogResult.Yes)
            {
                frm_Login obj = new frm_Login();

                this.Hide();
                obj.Show();
            }
        }

        private void frm_Search_Student_Details_Load(object sender, EventArgs e)
        {
            lbl_UName.Text = Shared_Class.Username;

            tb_Roll_No.Focus();
        }

    }
}
