using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public static class ClassLog
    {
        public static void SaveLog(string action,string lotNo,string mcNo,string empNo) // ฟังช้่นสร้างlogfile
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory + "backupLog";
            string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logFile.txt");
            string destFile = Path.Combine(directory, "logFile" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt");
            bool append = true;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            TextWriter txt;//= new StreamWriter(sourceFile,true);
            if(File.Exists(sourceFile))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);  //get file info 
                long size = fileInfo.Length; //ตรวจสอบขนาดไฟล์
                if (size >= 3145728) //3mb 
                {
                    File.Copy(sourceFile, destFile); //copy file
                    append = false;
                }
                
            }
            
                txt = new StreamWriter(sourceFile, append);
            
            txt.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "|" + action + "| " + lotNo + "| Mc No.:" + mcNo + "| Emp No.:" + empNo);
           
            txt.Close();

        }

        public static void ChkText(TextBox textBox,string message)
        {
            if (textBox.Text == null || textBox.Text == "")
            {
                MessageBox.Show(message);
                textBox.Focus();
                
            }
            return;
        }
        public static void ChkNum(TextBox textBox)
        {
            int num;
            if (int.TryParse(textBox.Text, out num))
            {
                MessageBox.Show("Please Input numeral");
                textBox.Focus();
                return;
            }
        }


    }
}
