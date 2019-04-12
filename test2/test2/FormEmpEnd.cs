using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class FormEmpEnd : Form
    {
        public ClassDataQR DataQR { get; set; }
        public FormEmpEnd()
        {
            InitializeComponent();
            DataQR = new ClassDataQR();
        }
        public FormEmpEnd(ClassDataQR data)
        {
            InitializeComponent();
            DataQR = data;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //ตรวจสอบว่าพิมพ์เสร็จหรือยัง
            {
                if (textBox1.Text.Length == 6) //ตรวจสอบความยาวของข้อความใน textbox
                {
                    //FormSetting formSetting = new FormSetting(QRData); %windir%\system32\osk.exe


                    DataQR.EmpNoEnd = textBox1.Text;
                    //FormInpuQty inpuQty = new FormInpuQty(DataQR);
                   // DialogResult result = inpuQty.ShowDialog();

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    textBox1.Focus();
                    return;
                }
            }
        }

        private void FormEmpEnd_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
