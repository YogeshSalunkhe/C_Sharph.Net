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
    public partial class frm_Veiw_Student_Details : Form
    {
        public frm_Veiw_Student_Details()
        {
            InitializeComponent();
        }
        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You Sure To Log Out ", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (Res == DialogResult.Yes)
            {
                frm_Login obj = new frm_Login();
                this.Hide();
                obj.Show();
            }
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student_Details obj = new frm_Add_New_Student_Details();

            this.Hide();
            obj.Show();

        }

        private void frm_Veiw_Student_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'y_Student_Details_DBDataSet1.Student_Details' table. You can move, or remove it, as needed.
            this.student_DetailsTableAdapter.Fill(this.y_Student_Details_DBDataSet1.Student_Details);

        }

    }
}
