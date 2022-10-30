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
    public partial class frm_Add_New_Student_Details : Form
    {
        public frm_Add_New_Student_Details()
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
            tb_Roll_No.Text = Convert.ToString(Auto_Incr());

            tb_Name.Text = "";
            tb_Mob_No.Text = "";
            cmb_Course.SelectedIndex = -1;
            dtp_D_O_B.Text = "01/01/2006";
        }

        int Auto_Incr()
        {
            int Max_RNo = 0;

            Con_Open();

            SqlCommand Cmd = new SqlCommand();

            Cmd.Connection = Con;
            Cmd.CommandText = "Select Max(Roll_No) From Student_Details";

            Max_RNo = Convert.ToInt32(Cmd.ExecuteScalar());

            Con_Close();

            return Max_RNo + 1;
        }     
   

        private void frm_Add_New_Student_Details_Load(object sender, EventArgs e)
        {
            Clear_Controls();
            tb_Name.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Con_Open();

            if (tb_Roll_No.Text != "" && tb_Name.Text != "" && tb_Mob_No.Text != "" && cmb_Course.Text != "")
            {
                SqlCommand Cmd = new SqlCommand();

                Cmd.Connection = Con;
                Cmd.CommandText = "Insert Into Student_Details (Roll_No, Name, DOB, Mobile_No, Course) Values(@RNo, @Nm, @DOB, @MNo, @Course)";

                Cmd.Parameters.Add("RNo", SqlDbType.Int).Value = tb_Roll_No.Text;
                Cmd.Parameters.Add("Nm", SqlDbType.VarChar).Value = tb_Name.Text;
                Cmd.Parameters.Add("DOB", SqlDbType.Date).Value = dtp_D_O_B.Text;
                Cmd.Parameters.Add("MNo", SqlDbType.Decimal).Value = tb_Mob_No.Text;
                Cmd.Parameters.Add("Course", SqlDbType.NVarChar).Value = cmb_Course.Text;

                Cmd.ExecuteNonQuery();

                MessageBox.Show("Record Insert Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Clear_Controls();
            }
            else
            {
                MessageBox.Show("Fill All Fildes", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You Sure To Logout ???", "Log Out",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (Res == DialogResult.Yes)
            {
                frm_Login obj = new frm_Login();
                this.Hide();
                obj.Show();
            }
        }

        private void btn_View_Student_Details_Click(object sender, EventArgs e)
        {
            frm_Veiw_Student_Details obj = new frm_Veiw_Student_Details();

            this.Hide();
            obj.Show();
        }

        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void Only_Text(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Space)))
            {
                e.Handled = true;
            }
        }

        private void btn_Search_Student_Details_Click(object sender, EventArgs e)
        {
            frm_Search_Student_Details obj = new frm_Search_Student_Details();

            this.Hide();
            obj.Show();
        }
    }
}
