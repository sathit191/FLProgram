using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace test2
{
    public partial class Form1 : Form
    {
        private ClassDataQR QRData;
        private WebServiceAPCS.ServiceiLibraryClient webService;

        public Form1()
        {


            InitializeComponent();
            QRData = new ClassDataQR();
            labelMcNo.Text = Properties.Settings.Default.McNo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //chk lot not error to next step.
            FormSetting formSetting = new FormSetting(QRData);
            DialogResult result = formSetting.ShowDialog(); //ฟังชั่นเพื่อรีเทินค่า Dialog ว่า OK , Close 
            if (result == DialogResult.OK) //เช็คค่า Dialog ที่รีเทินกลับมาว่า Ok หรือไม่ ***ถ้าปิดหน้าต่างฟอม2 จะไม่เข้า loop นี้
            {

                //ShowData(QRData);
                //classDataQRBindingSource.ResetBindings(true);
               // classDataQRBindingSource.DataSource = QRData;
                button1.BackgroundImage = test2.Properties.Resources.input_gray;
                labelStatus.Text = "Status : Wait Start Lot";
                button1.Enabled = false;
                buttonStart.BackgroundImage = test2.Properties.Resources.Start_blue;
                buttonStart.Enabled = true;
                buttonCancelLot.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
            }
        }

        private void ShowData(ClassDataQR dataQR)
        {
            classDataQRBindingSource.ResetBindings(true);
            classDataQRBindingSource.DataSource = QRData; //Binding data from class
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //classDataQRBindingSource.DataSource = QRData;
            // TODO: This line of code loads data into the 'dBxDataSet.FLData' table. You can move, or remove it, as needed.
            this.fLDataTableAdapter.FillBy1(this.dBxDataSet.FLData, Properties.Settings.Default.McNo);
            labelVer.Text = Properties.Settings.Default.Version;
            menuStrip1.ForeColor = Color.White;

            string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xmlData.txt");
           // button1.BackgroundImage = test2.Properties.Resources.PictureBoxButtonLotEndGreen; เปลี่ยนรูปพื้นหลัง
            if (File.Exists(sourceFile))
            {
                ClassDataQR classData = LoadXml(AppDomain.CurrentDomain.BaseDirectory + "/xmlData.txt");
                ClassLog.SaveLog("Restore Lot ", "Lot No.:" + classData.LotNo,classData.McNo, classData.EmpNo);
                if(classData.LotSetting.HasValue == true)
                {
                    labelStatus.Text = "Status : Wait Start Lot";
                    button1.Enabled = false;
                    button1.BackgroundImage = test2.Properties.Resources.input_gray;
                    buttonCancelLot.Visible = true;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                }
                if (classData.LotStart.HasValue == true)
                {
                    labelStatus.Text = "Status : Lot Running";
                    buttonStart.Enabled = false;
                    button1.Enabled = false;
                    button1.BackgroundImage = test2.Properties.Resources.input_gray;
                    buttonStart.BackgroundImage = test2.Properties.Resources.Start_gray;
                    buttonCancelLot.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                }
                if (classData.LotClose.HasValue == true)
                {
                    labelStatus.Text = "Status : Wait Setting Lot";
                    buttonLotEnd.Enabled = false;
                    buttonStart.Enabled = false;
                    buttonStart.BackgroundImage = test2.Properties.Resources.Start_gray;
                    buttonLotEnd.BackgroundImage = test2.Properties.Resources.End_gray;
                    button1.Enabled = true;
                    button1.BackgroundImage = test2.Properties.Resources.input_blue;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    return;
                }
                QRData = classData;

            }
            classDataQRBindingSource.DataSource = QRData;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            
            QRData.LotStart = DateTime.Now;
            QRData.Recipes = textBoxRecipes.Text;

            
            webService = new WebServiceAPCS.ServiceiLibraryClient(); //เช็คค่าจากเว็บ SV
            WebServiceAPCS.StartLotResult startLot = webService.StartLot(QRData.LotNo, QRData.McNo, QRData.EmpNo, QRData.Recipes);

            if (startLot.IsPass == false)
            {
                MessageDialog.MessageBoxDialog.ShowMessageDialog("Start Lot", startLot.Cause, startLot.Type.ToString());
                return;
            }
            else
            {
                InsertSqlData(labelLotNo.Text, labelMcNo.Text, QRData.LotStart);
                SaveXml(QRData, AppDomain.CurrentDomain.BaseDirectory + "/xmlData.txt");
                ClassLog.SaveLog("Click Start Button", "Lot No.:" + QRData.LotNo, QRData.McNo, QRData.EmpNo + "| InputQty: " + QRData.InputQty);
                

                labelStatus.Text = "Status : Lot Running";
                buttonStart.Enabled = false;
                buttonStart.BackgroundImage = test2.Properties.Resources.Start_gray;
                buttonLotEnd.Enabled = true;
                buttonLotEnd.BackgroundImage = test2.Properties.Resources.End_blue;
                buttonCancelLot.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
           // classDataQRBindingSource.ResetBindings(true);



        }
        private void UpdateSqlData(string mcNo, string lotNo , DateTime? date)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(Properties.Settings.Default.Dbxuser);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [dbo].[FLData]"+
                                  "SET [TotalGood] = @TotalGood " +
                                  ",[TotalNG] = @TotalNG " +
                                  ",[LotEndTime] = @LotClose" +
                                  ",[FrontMarkerNG] = @FrontMarkerNG" +
                                  ",[FLMarkerNG] = @FLMarkerNG" +
                                  ",[ActualMekaNG1] = @TotalNG " +
                                  ",[MekaNG1] = @TotalNG" +
                                  ",[MissingIC] = @MissingIC" +
                                  ",[JigCheck] = @JigCheck" +
                                  ",[KanaCleanBefore] = @KanaCleanBeFore" +
                                  ",[KanaCleanAfter] = @KanaCleanAfter" +
                                  ",[VisualCheckMode] = @VisualCheckMode" +
                                  ",[VisualCheckAdjust] = @VisualCheckAdjust" +
                                  ",[FirstShotCheckMode] = @FirstShotCheckMode" +
                                  ",[FirstShotCheckModeAdjust] = @FirstShotCheckModeAdjust" +
                                  ",[MekaNGAdjust] = @TotalNG " +
                                  " WHERE LotNo = @LotNo AND McNo = @McNo AND LotStartTime = @LotStartTime";
                cmd.Parameters.Add("@LotNo", SqlDbType.VarChar).Value = lotNo;
                cmd.Parameters.Add("@McNo", SqlDbType.VarChar).Value = mcNo;
                cmd.Parameters.Add("@LotStartTime", SqlDbType.DateTime).Value = QRData.LotStart;
                //value//
                cmd.Parameters.Add("@LotClose", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@TotalGood", SqlDbType.VarChar).Value = QRData.TotalGood;
                cmd.Parameters.Add("@TotalNG", SqlDbType.VarChar).Value = QRData.TotalNg;
                cmd.Parameters.Add("@FrontMarkerNG", SqlDbType.VarChar).Value = QRData.MarkerM;
                cmd.Parameters.Add("@FLMarkerNG", SqlDbType.VarChar).Value = QRData.MarkerK;
                cmd.Parameters.Add("@MissingIC", SqlDbType.VarChar).Value = QRData.MissingIC;
                cmd.Parameters.Add("@JigCheck", SqlDbType.VarChar).Value = QRData.JigCheck;
                cmd.Parameters.Add("@KanaCleanBeFore", SqlDbType.VarChar).Value = QRData.KanagataBefore;
                cmd.Parameters.Add("@KanaCleanAfter", SqlDbType.VarChar).Value = QRData.KanagataAfter;
                cmd.Parameters.Add("@VisualCheckMode", SqlDbType.VarChar).Value = QRData.VisualCheck;
                cmd.Parameters.Add("@VisualCheckAdjust", SqlDbType.VarChar).Value = QRData.VisualAdjust;
                cmd.Parameters.Add("@FirstShotCheckMode", SqlDbType.VarChar).Value = QRData.OneShotKanagata;
                cmd.Parameters.Add("@FirstShotCheckModeAdjust", SqlDbType.VarChar).Value = QRData.OneShotAdjust;
                cmd.Parameters.Add("@EmpNoEnd", SqlDbType.VarChar).Value = QRData.EmpNoEnd;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

            }
        }
        private void SaveBinary(ClassDataQR qRData, string pathFile) // บันทึกข้อมูลลงไปในไฟล์ ไบนารี่
        {
            using (Stream stream = File.Open(pathFile, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, qRData);
                stream.Close();
            }

        }

        private void SaveXml(ClassDataQR qRData, string pathFile) //สร้างฟังชั่นสำหรับบันทึกข้อมูลลงไฟล์ XML
        {
            using (StreamWriter strWriter = new StreamWriter(pathFile, false))
            {
                var bs = new XmlSerializer(qRData.GetType()); //ใช้ข้อมูลจากคาสมาเขียน

                bs.Serialize(strWriter, qRData);
            }
        }

        private ClassDataQR LoadXml(string path) // สร้างฟังชั่นโหลดข้อมูงจากไฟล์ XML มาลงใน คาส
        {
            if (File.Exists(path) == false)
            {
                return null; //ส่งค่าคาสเป็นค่าว่าง//null
            }
            ClassDataQR classQRData; //กำหนดตัวแปรเพื่อรับค่าคาส
            using (StreamReader readXml = new StreamReader(path)) //กำหนดตัวแปรเพื่อทำการอ่านข่อมูลจาก file path
            {

                var bs = new XmlSerializer(QRData.GetType()); //กำหนดชนิดของตัวแปลตามคาส
                //bs.Deserialize(readXml);

                classQRData = (ClassDataQR)bs.Deserialize(readXml); //กำหนดค่าตัวแปลให้มีค่าเท่ากับตัวแปลbs ที่ไฟล์ readXml
            }
            return classQRData;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            ClassDataQR classData = LoadXml(AppDomain.CurrentDomain.BaseDirectory + "/xmlData.txt");
           // ClassLog.SaveLog("Click Restore Lot Button", "Lot No.:" + classData.LotNo, classData.EmpNo);
            if (classData.LotStart.HasValue == true )
            {
                buttonStart.Enabled = false;
                button1.Enabled = false;
            }
            if(classData.LotClose.HasValue == true)
            {
                MessageBox.Show("Lot End : " + classData.LotClose);
                buttonLotEnd.Enabled = false;
                buttonStart.Enabled = false;
                button1.Enabled = true;

                return;
            }
            QRData = classData;

            ShowData(QRData);
        }
        
        private void Cleartext()
        {
            labelLotStart.Text = "-";
            labelLotClose.Text = "-";
            textBoxTotalNG.Text = null;
            textBoxM.Text = null;
            textBoxK.Text = null;
            textBoxMekaNG = null;
            textBoxIC.Text = null;
            
        }

        private void textBoxTotalGood_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLotEnd_Click(object sender, EventArgs e)
        {
            FormDataRecord formDataRecord = new FormDataRecord(QRData);
            DialogResult resultDatarecode = formDataRecord.ShowDialog();
            /////////goto emp end form ///////////////
            ///
            //check by webserv
            if (resultDatarecode == DialogResult.OK)
            {
                QRData.LotClose = DateTime.Now;
                webService = new WebServiceAPCS.ServiceiLibraryClient();

                int good = int.Parse(QRData.TotalGood);
                int ng = int.Parse(QRData.TotalNg);

                WebServiceAPCS.EndLotResult endLot = webService.EndLot(QRData.LotNo, QRData.McNo, QRData.EmpNoEnd, good, ng);

                if (endLot.IsPass == false)
                {
                    MessageDialog.MessageBoxDialog.ShowMessageDialog("End Lot", endLot.Cause, endLot.Type.ToString()); //setupLot.Cause, setupLot.Type.ToString()
                    return;
                }
                else
                {
                    UpdateSqlData(QRData.McNo, QRData.LotNo,QRData.LotStart);
                    SaveXml(QRData, AppDomain.CurrentDomain.BaseDirectory + "/xmlData.txt"); //update binary file
                    ClassLog.SaveLog("Click Lot End Button", "Lot No.:" + QRData.LotNo, QRData.McNo, QRData.EmpNoEnd + "| Total Good " + QRData.TotalGood + "| Total NG " + QRData.TotalNg);
                    

                    labelStatus.Text = "Status : Wait Input Lot";
                    buttonLotEnd.Enabled = false;
                    buttonLotEnd.BackgroundImage = test2.Properties.Resources.End_gray;
                    button1.Enabled = true;
                    button1.BackgroundImage = test2.Properties.Resources.input_blue;
                    pictureBox2.Visible = false;

                }
            }
            // ShowData(QRData); 
            //classDataQRBindingSource.ResetBindings(true);



        }

        private void AndonToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void WorkRecordToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void HelpToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void BMRequestToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void PMRepairingToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void andonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("iexplore.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files\internet explorer\iexplore.exe";
            startInfo.Arguments = "" + "http://webserv/andon" + "";
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
        }

        private void workRecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files\internet explorer\iexplore.exe";
            startInfo.Arguments = "" + "http://webserv/ERecord/Default.aspx" + "";
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
        }

        private void bMRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmpstr = "McNo=" + QRData.McNo + "&LotNo=" + QRData.LotNo + "&MCStatus=Running&AlarmNo=&AlarmName=";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files\internet explorer\iexplore.exe";
            startInfo.Arguments = "" + "http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?" + tmpstr;
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);

            Process.Start(@"C:\Windows\System32\osk.exe");
        }

        private void InsertSqlData(string lotNo, string mcNo ,DateTime? startLot)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["Dbxuser"]);
                cmd.Connection = new SqlConnection(Properties.Settings.Default.Dbxuser);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [dbo].[FLData] " +
                                  "([MCNo],[LotNo],[LotStartTime],[McType],[OPNo],[InputQty]) " +
                                  "VALUES (@MCNo,@LotNo,@StartTime,@McType,@EmpNo,@InputQty)"; /// 
                cmd.Parameters.Add("@MCNo", SqlDbType.VarChar).Value = mcNo;
                cmd.Parameters.Add("@LotNo", SqlDbType.VarChar).Value = lotNo;
                cmd.Parameters.Add("@McType", SqlDbType.VarChar).Value = QRData.McType;
                cmd.Parameters.Add("@InputQty", SqlDbType.VarChar).Value = QRData.InputQty;
                cmd.Parameters.Add("@EmpNo", SqlDbType.VarChar).Value = QRData.EmpNo;
                cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = startLot;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        private void pMRepairingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" & "MCNo=" & lbMC.Text
            string tmpstr = "McNo=" + QRData.McNo ;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Program Files\internet explorer\iexplore.exe";
            startInfo.Arguments = "" + "http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" + tmpstr;
            startInfo.CreateNoWindow = true;
            startInfo.ErrorDialog = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
            Process.Start("osk.exe");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.fLDataTableAdapter.FillBy(this.dBxDataSet.FLData);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.fLDataTableAdapter.FillBy1(this.dBxDataSet.FLData, mcNoToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormDataRecord formDataRecord = new FormDataRecord(QRData);
            DialogResult result = formDataRecord.ShowDialog();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancelLot_Click(object sender, EventArgs e)
        {
            FormEmpEnd formEmpEnd = new FormEmpEnd(QRData);
            DialogResult result = formEmpEnd.ShowDialog();
            //WebServiceAPCS.EndLotResult endLot = webService.EndLot(QRData.LotNo, QRData.McNo, QRData.EmpNoEnd, good, ng);
            if (result == DialogResult.OK)
            {
                webService = new WebServiceAPCS.ServiceiLibraryClient();
                WebServiceAPCS.CancelLotResult cancelLot = webService.CancelLot(QRData.McNo, QRData.LotNo, QRData.EmpNoEnd);
                if (cancelLot.IsPass == false)
                {
                    MessageDialog.MessageBoxDialog.ShowMessageDialog("End Lot", cancelLot.Cause, cancelLot.Type.ToString()); //setupLot.Cause, setupLot.Type.ToString()
                    return;
                }
                else
                {
                    ClassLog.SaveLog("Click Cancel Lot Button", "Lot No.:" + QRData.LotNo, QRData.McNo, QRData.EmpNoEnd);

                    QRData.LotNo = null;
                    QRData.DeviceName = null;
                    QRData.PackageName = null;
                    QRData.LotSetting = null;//บันทึกค่าลง class
                    QRData.EmpNo = null;
                    QRData.InputQty = null;
                    QRData.LotStart = null;
                    QRData.LotClose = null;
                    QRData.TotalNg = null;
                    QRData.MarkerM = 0;
                    QRData.MarkerK = 0;
                    QRData.MekaNG = 0;
                    QRData.MissingIC = 0;

                    SaveXml(QRData, AppDomain.CurrentDomain.BaseDirectory + "/xmlData.txt"); //update binary file

                    // ShowData(QRData);
                    //classDataQRBindingSource.ResetBindings(true);

                    labelStatus.Text = "Status : Wait Input Lot";
                    buttonLotEnd.Enabled = false;
                    buttonLotEnd.BackgroundImage = test2.Properties.Resources.End_gray;
                    button1.Enabled = true;
                    button1.BackgroundImage = test2.Properties.Resources.input_blue;
                    buttonStart.Enabled = false;
                    buttonStart.BackgroundImage = test2.Properties.Resources.Start_gray;
                }
            }
        }
    }
}
