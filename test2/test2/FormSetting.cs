using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace test2
{
    
    public partial class FormSetting : Form
    {
        public ClassDataQR DataQR { get; set; }
        private WebServiceAPCS.ServiceiLibraryClient webService;
        //public string LotNo { get; set; }


        public FormSetting()
        {
            InitializeComponent();
            DataQR = new ClassDataQR();
        }
        public FormSetting(ClassDataQR dataQR)
        {
            InitializeComponent();
            DataQR = dataQR; 
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            textBoxScanQr.Focus();
        }

        private void textBoxScanQr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //ตรวจสอบว่าพิมพ์เสร็จหรือยัง
            {
                if (textBoxScanQr.Text.Length == 252) //ตรวจสอบความยาวของข้อความใน textbox
                {
                    // label2.Text = textBoxScanQr.Text.Substring(0, 10);
                    DataQR.McNo = Properties.Settings.Default.McNo;
                    DataQR.LotNo = textBoxScanQr.Text.Substring(30, 10);
                    DataQR.DeviceName = textBoxScanQr.Text.Substring(10, 20);
                    DataQR.PackageName = textBoxScanQr.Text.Substring(0, 10);
                    DataQR.LotSetting = DateTime.Now;//บันทึกค่าลง class
                    DataQR.Ver = Properties.Settings.Default.Version;
                    DataQR.McType = Properties.Settings.Default.McType;
                    
                    FormScanEmp scanEmp = new FormScanEmp(DataQR);
                    DialogResult result = scanEmp.ShowDialog();

                    DataQR.LotStart = null;
                    DataQR.LotClose = null;
                    DataQR.TotalNg = null;
                    DataQR.MarkerM = 0;
                    DataQR.MarkerK = 0;
                    DataQR.MekaNG = 0;
                    DataQR.MissingIC = 0;
                    if (result == DialogResult.OK)
                    {
                        webService = new WebServiceAPCS.ServiceiLibraryClient(); //เช็คค่าจากเว็บ SV
                        WebServiceAPCS.SetupLotResult setupLot = webService.SetupLot(DataQR.LotNo, DataQR.McNo, DataQR.EmpNo, Properties.Settings.Default.ProcessName, Properties.Settings.Default.LayNo);

                        if (setupLot.IsPass == WebServiceAPCS.SetupLotResult.Status.NotPass)
                        {
                            MessageDialog.MessageBoxDialog.ShowMessageDialog("Input Lot", setupLot.Cause, setupLot.Type.ToString());
                            DataQR.LotNo = null;
                            DataQR.DeviceName = null;
                            DataQR.PackageName = null;
                            DataQR.LotSetting = null;//บันทึกค่าลง class
                            DataQR.EmpNo = null;
                            DataQR.InputQty = null;
                            DialogResult = DialogResult.No;
                        }
                        else
                        {
                            DataQR.Recipes = setupLot.Recipe;
                            SaveXml(DataQR, AppDomain.CurrentDomain.BaseDirectory + "/xmlData.txt"); //บันทึกข้อมูลลงไฟล์ไบนารี่
                            ClassLog.SaveLog("Click Setting Button", "Lot No.:" + DataQR.LotNo, DataQR.McNo, DataQR.EmpNo);
                            DialogResult = DialogResult.OK;

                        }
                    }else
                    {
                        DialogResult = DialogResult.No;
                    }

                    
                    
                }
            }
            progressBar1.Value = textBoxScanQr.Text.Length;
        }
        
        private void SaveXml(ClassDataQR qRData, string pathFile) //สร้างฟังชั่นสำหรับบันทึกข้อมูลลงไฟล์ XML
        {
            using (StreamWriter strWriter = new StreamWriter(pathFile, false))
            {
                var bs = new XmlSerializer(qRData.GetType()); //ใช้ข้อมูลจากคาสมาเขียน

                bs.Serialize(strWriter, qRData);
            }
        }

        

    }
}
