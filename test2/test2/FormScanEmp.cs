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

namespace test2
{
    public partial class FormScanEmp : Form
    {
        protected override CreateParams CreateParams => base.CreateParams;

        public FormScanEmp()
        {
            
            InitializeComponent();
            DataQR = new ClassDataQR();
        }
        public FormScanEmp(ClassDataQR dataQR)
        {
            DataQR = dataQR;
            InitializeComponent();
        }

        public ClassDataQR DataQR { get; set; }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13) //ตรวจสอบว่าพิมพ์เสร็จหรือยัง
            {
                if (textBox1.Text.Length == 6) //ตรวจสอบความยาวของข้อความใน textbox
                {
                    //FormSetting formSetting = new FormSetting(QRData); %windir%\system32\osk.exe


                    DataQR.EmpNo = textBox1.Text;
                    FormInpuQty inpuQty = new FormInpuQty(DataQR); 
                    DialogResult result = inpuQty.ShowDialog();

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    textBox1.Focus();
                    return;
                }
            }
        }
        //private void UpdateSqlData(string emNo)
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        //cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["Dbxuser"]);
        //        cmd.Connection = new SqlConnection(Properties.Settings.Default.Dbxuser);
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "UPDATE FTData SET EmNo = @EmNo WHERE LotNo = @LotNo";
        //        //INSERT INTO [dbo].[FTData] ([MCNo],[LotNo],[LotStartTime]) VALUES (@MCNo,@LotNo,@StartTime)";
        //        cmd.Parameters.Add("@EmNo", SqlDbType.VarChar).Value = emNo;
                
                
        //        cmd.Connection.Open();
        //        cmd.ExecuteNonQuery();
        //        cmd.Connection.Close();
        //    }
        //}

        private void FormScanEmp_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
           // System.Diagnostics.Process.Start("osk.exe");
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //textBox1.Text += (char)13;
            textBox1_KeyPress(sender, new KeyPressEventArgs((char)13));
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }
    }
}
