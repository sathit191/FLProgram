using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test2
{
    public partial class FormDataRecord : Form
    {
        public ClassDataQR DataQR;
        private TextBox c_textBoxFocus;

        public FormDataRecord(ClassDataQR qRData)
        {

            InitializeComponent();
            DataQR = qRData;
        }

        private void button52_Click(object sender, EventArgs e)
        {

            c_textBoxFocus.Text += button52.Text;
            c_textBoxFocus.Focus();
            
            
        }

        private void FormDataRecord_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxKanaB.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Before.");
                textBoxKanaB.Focus();
                return;
            }else if(textBoxKanaB.Text == "A")
            {
                MessageBox.Show("After is Null.");
                textBoxKanaA.Text = null;
                return;
            }else
            {
                textBoxKanaA.Text = "A";
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBoxKanaB.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Before.");
                textBoxKanaB.Focus();
                return;
            }
            else if (textBoxKanaB.Text == "A")
            {
                MessageBox.Show("After is Null.");
                textBoxKanaA.Text = null;
                return;
            }
            else
            {
                textBoxKanaA.Text = "B";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBoxKanaB.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Before.");
                textBoxKanaB.Focus();
                return;
            }
            else if (textBoxKanaB.Text == "A")
            {
                MessageBox.Show("After is Null.");
                textBoxKanaA.Text = null;
                return;
            }
            else
            {
                textBoxKanaA.Text = "C";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxKanaB.Text = "A";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBoxKanaB.Text = "B";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBoxKanaB.Text = "C";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1SKana.Text = "A";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1SKana.Text = "B";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1SKana.Text = "C";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1SKana.Text.Trim() == "")
            {
                MessageBox.Show("Please Input 1 Shot Kanagata .");
                textBox1SKana.Focus();
                return;
            }
            else if (textBox1SKana.Text == "A")
            {
                MessageBox.Show("1 Shot Adjust is Null.");
                textBox1SAdj.Text = null;
                return;
            }
            else
            {
                textBox1SAdj.Text = "A";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1SKana.Text.Trim() == "")
            {
                MessageBox.Show("Please Input 1 Shot Kanagata .");
                textBox1SKana.Focus();
                return;
            }
            else if (textBox1SKana.Text == "A")
            {
                MessageBox.Show("1 Shot Adjust is Null.");
                textBox1SAdj.Text = null;
                return;
            }
            else
            {
                textBox1SAdj.Text = "B";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1SKana.Text.Trim() == "")
            {
                MessageBox.Show("Please Input 1 Shot Kanagata .");
                textBox1SKana.Focus();
                return;
            }
            else if (textBox1SKana.Text == "A")
            {
                MessageBox.Show("1 Shot Adjust is Null.");
                textBox1SAdj.Text = null;
                return;
            }
            else
            {
                textBox1SAdj.Text = "C";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxJigChk.Text = "OK";

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxJigChk.Text = "NG";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxVisualChk.Text = "A";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBoxVisualChk.Text = "B";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBoxVisualChk.Text = "C";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxVisualChk.Text.Trim() == "")
            {
                MessageBox.Show("Please Input 1 Shot Kanagata .");
                textBoxVisualChk.Focus();
                return;
            }
            else if (textBoxVisualChk.Text == "A")
            {
                MessageBox.Show("Visual Check Adlust is Null.");
                textBox1SAdj.Text = null;
                return;
            }
            else
            {
                textBoxVisualAdj.Text = "A";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBoxVisualChk.Text.Trim() == "")
            {
                MessageBox.Show("Please Input 1 Shot Kanagata .");
                textBoxVisualChk.Focus();
                return;
            }
            else if (textBoxVisualChk.Text == "A")
            {
                MessageBox.Show("Visual Check Adlust is Null.");
                textBox1SAdj.Text = null;
                return;
            }
            else
            {
                textBoxVisualAdj.Text = "C";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBoxVisualChk.Text.Trim() == "")
            {
                MessageBox.Show("Please Input 1 Shot Kanagata .");
                textBoxVisualChk.Focus();
                return;
            }
            else if (textBoxVisualChk.Text == "A")
            {
                MessageBox.Show("Visual Check Adlust is Null.");
                textBox1SAdj.Text = null;
                return;
            }
            else
            {
                textBoxVisualAdj.Text = "B";
            }
        }

        private void textBoxKanaB_TextChanged(object sender, EventArgs e)
        {
            if(textBoxKanaB.Text == "A")
            {
                textBoxKanaA.Text = null;
            }
        }

        private void textBox1SKana_TextChanged(object sender, EventArgs e)
        {
            if(textBox1SKana.Text == "A")
            {
                textBox1SAdj.Text = null;
            }
        }

        private void textBoxVisualChk_TextChanged(object sender, EventArgs e)
        {
            if(textBoxVisualChk.Text == "A")
            {
                textBoxVisualAdj.Text = null;
            }
        }

        
        private void textBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            c_textBoxFocus = textBox;
            c_textBoxFocus.Focus();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button51.Text;
            c_textBoxFocus.Focus();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button50.Text;
            c_textBoxFocus.Focus();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button49.Text;
            c_textBoxFocus.Focus();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button48.Text;
            c_textBoxFocus.Focus();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button47.Text;
            c_textBoxFocus.Focus();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button46.Text;
            c_textBoxFocus.Focus();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button45.Text;
            c_textBoxFocus.Focus();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button44.Text;
            c_textBoxFocus.Focus();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            c_textBoxFocus.Text += button43.Text;
            c_textBoxFocus.Focus();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (c_textBoxFocus.TextLength > 0)
            {
                c_textBoxFocus.Text = c_textBoxFocus.Text.Remove(c_textBoxFocus.Text.Length - 1, 1);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBoxKanaB.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Before.");
                textBoxKanaB.Focus();
            }
            else if (textBoxKanaA.Text.Trim() == "")
            {
                if (textBoxKanaB.Text != "A")
                {
                    MessageBox.Show("Please Input After.");
                    textBoxKanaA.Focus();
                }
            }
            else if (textBox1SKana.Text.Trim() == "")
            {

                MessageBox.Show("Please Input 1 Shot Kanagata.");
                textBox1SKana.Focus();
            }
            else if (textBox1SAdj.Text.Trim() == "")
            {
                if (textBox1SKana.Text != "A")
                {
                    MessageBox.Show("Please Input 1 Shot Adjust.");
                    textBox1SAdj.Focus();
                }
            }
            else if (textBoxJigChk.Text.Trim() == "")
            {

                MessageBox.Show("Please Input Visual Check.");
                textBoxJigChk.Focus();
            }
            else if (textBoxVisualChk.Text.Trim() == "")
            {

                MessageBox.Show("Please Input 1 Shot Kanagata.");
                textBoxVisualChk.Focus();
            }
            else if (textBoxVisualAdj.Text.Trim() == "")
            {
                if (textBoxVisualChk.Text != "A")
                {
                    MessageBox.Show("Please Input Visual Check Adlust :.");
                    textBoxVisualAdj.Focus();
                }
            }
            else if (textBoxTotalNG.Text == "")
            {
                MessageBox.Show("Please Input Total NG.");
                textBoxTotalNG.Focus();
            }
            else if (textBoxM.Text == "")
            {
                MessageBox.Show("Please Input Marker M.");
                textBoxM.Focus();
            }
            else if (textBoxK.Text == "")
            {
                MessageBox.Show("Please Input Marker K.");
                textBoxK.Focus();
            }
            else if (textBoxMekaNG.Text == "")
            {
                MessageBox.Show("Please Input Meka NG.");
                textBoxMekaNG.Focus();
            }
            else if (textBoxIC.Text == "")
            {
                MessageBox.Show("Please Input Missing IC.");
                textBoxIC.Focus();
            }
            else
            {

                DataQR.KanagataBefore = textBoxKanaB.Text;
                DataQR.KanagataAfter = textBoxKanaA.Text;
                DataQR.OneShotKanagata = textBox1SKana.Text;
                DataQR.OneShotAdjust = textBox1SAdj.Text;
                DataQR.JigCheck = textBoxJigChk.Text;
                DataQR.VisualCheck = textBoxVisualChk.Text;
                DataQR.VisualAdjust = textBoxVisualAdj.Text;

                DataQR.TotalNg = textBoxTotalNG.Text;
                DataQR.MarkerM = int.Parse(textBoxM.Text);
                DataQR.MarkerK = int.Parse(textBoxK.Text);
                DataQR.MekaNG = int.Parse(textBoxMekaNG.Text);
                DataQR.MissingIC = int.Parse(textBoxIC.Text);

                DialogResult = DialogResult.OK;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
