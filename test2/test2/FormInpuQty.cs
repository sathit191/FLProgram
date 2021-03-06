﻿using System;
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
    public partial class FormInpuQty : Form
    {
        public FormInpuQty()
        {
            InitializeComponent();
            DataQR = new ClassDataQR();
        }
        public FormInpuQty(ClassDataQR dataQR)
        {
            InitializeComponent();
            DataQR = dataQR;
        }
        private ClassDataQR DataQR { get; set; }
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1_KeyPress(sender, new KeyPressEventArgs((char)13));
        }

        private void FormInpuQty_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //ตรวจสอบว่าพิมพ์เสร็จหรือยัง
            {
                //if (textBox1.Text.Length == 6) //ตรวจสอบความยาวของข้อความใน textbox
                //{
                    //FormSetting formSetting = new FormSetting(QRData); %windir%\system32\osk.exe


                    DataQR.InputQty = textBox1.Text;

                    DialogResult = DialogResult.OK;
                //}
                //else
                //{
                //    textBox1.Focus();
                //    return;
                //}
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int countText = textBox1.Text.Length;

            if (countText > 0)
            {
                textBox1.Text = textBox1.Text.Remove(countText - 1, 1);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }
    }
}
