using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    [Serializable]
    public class ClassDataQR: INotifyPropertyChanged
    {
        //public string McNo {get;set;}
        //public string LotNo { get; set; }
       // public DateTime? LotStart { get; set; } // Datetime? คือจะทำให้ค่า เริ่มต้นเป็น NUll
       // public string McType { get; set; }
        //public string EmpNo { get; set; }
        //public string InputQty { get; set; }
        //public string TotalGood { get; set; }
        //public string TotalNg { get; set; }
       // public DateTime? LotClose { get; set; }
        //public string Ver { get; set; }
        //public string KanagataBefore { get; set; }
        //public string KanagataAfter { get; set; }
        //public string OneShotKanagata { get; set; }
        //public string OneShotAdjust { get; set; }
        //public string JigCheck { get; set; }
       // public string VisualCheck { get; set; }
       // public string VisualAdjust { get; set; }

       // public string DeviceName { get; set; }
        //public string PackageName { get; set; }
        //public string Recipes { get; set; }
        //public DateTime? LotSetting { get; set; }
        //public int MarkerM { get; set; }
        //public int MarkerK { get; set; }
        //public int MekaNG { get; set; }
        //public int MissingIC { get; set; }
        //public string EmpNoEnd { get; set; }

        private string c_McNo;

        public string McNo
        {
            get { return c_McNo; }
            set
            {
                c_McNo = value;
                ReportPeropertyChanged("McNo");
            }
        }

        private string c_LotNo;

        public string LotNo
        {
            get { return c_LotNo; }
            set { c_LotNo = value;
                ReportPeropertyChanged("LotNo");
            }
        }
        private DateTime? c_LotStart;

        public DateTime? LotStart
        {
            get { return c_LotStart; }
            set
            {
                c_LotStart = value;
                ReportPeropertyChanged("LotStart");
            }
        }

        private string c_McType;

        public string McType
        {
            get { return c_McType; }
            set
            {
                c_McType = value;
                ReportPeropertyChanged("McType");
            }
        }

        private string c_EmpNo;

        public string EmpNo
        {
            get { return c_EmpNo; }
            set { c_EmpNo = value;
                ReportPeropertyChanged("EmpNo");
            }
        }

        private string c_InputQty;

        public string InputQty
        {
            get { return c_InputQty; }
            set { c_InputQty = value;
                ReportPeropertyChanged("InputQty");
            }
        }

        private string c_TotalGood;

        public string TotalGood
        {
            get { return c_TotalGood; }
            set { c_TotalGood = value;
                ReportPeropertyChanged("TotalGood");
            }
        }

        private string c_TotalNg;

        public string TotalNg
        {
            get { return c_TotalNg; }
            set { c_TotalNg = value;
                ReportPeropertyChanged("TotalNg");
            }
        }

        private DateTime? c_LotClose;

        public DateTime? LotClose
        {
            get { return c_LotClose; }
            set { c_LotClose = value;
                ReportPeropertyChanged("LotClose");
            }
        }


        private string c_Ver;

        public string Ver
        {
            get { return c_Ver; }
            set { c_Ver = value;
                ReportPeropertyChanged("Ver");
            }
        }

        private string c_KanagataBefore;

        public string KanagataBefore
        {
            get { return c_KanagataBefore; }
            set { c_KanagataBefore = value;
                ReportPeropertyChanged("KanagataBefore");
            }
        }

        private string c_KanagataAfter;

        public string KanagataAfter
        {
            get { return c_KanagataAfter; }
            set { c_KanagataAfter = value;
                ReportPeropertyChanged("KanagataAfter");
            }
        }

        private string c_OneShotKanagata;

        public string OneShotKanagata
        {
            get { return c_OneShotKanagata; }
            set { c_OneShotKanagata = value;
                ReportPeropertyChanged("OneShotKanagata");
            }
        }

        private string c_OneShotAdjust;

        public string OneShotAdjust
        {
            get { return c_OneShotAdjust; }
            set { c_OneShotAdjust = value;
                ReportPeropertyChanged("OneShotAdjust");
            }
        }

        private string c_JigCheck;

        public string JigCheck
        {
            get { return c_JigCheck; }
            set { c_JigCheck = value;
                ReportPeropertyChanged("JigCheck");
            }
        }

        private string c_VisualCheck;

        public string VisualCheck
        {
            get { return c_VisualCheck; }
            set { c_VisualCheck = value;
                ReportPeropertyChanged("VisualCheck");
            }
        }

        private string c_VisualAdjust;

        public string VisualAdjust
        {
            get { return c_VisualAdjust; }
            set { c_VisualAdjust = value;
                ReportPeropertyChanged("VisualAdjust");
            }
        }

        private string c_DeviceName;

        public string DeviceName
        {
            get { return c_DeviceName; }
            set { c_DeviceName = value;
                ReportPeropertyChanged("DeviceName");
            }
        }

        private string c_PackageName;

        public string PackageName
        {
            get { return c_PackageName; }
            set { c_PackageName = value;
                ReportPeropertyChanged("PackageName");
            }
        }

        private string c_Recipes;

        public string Recipes
        {
            get { return c_Recipes; }
            set { c_Recipes = value;
                ReportPeropertyChanged("Recipes");
            }
        }

        private DateTime? c_LotSetting;

        public DateTime? LotSetting
        {
            get { return c_LotSetting; }
            set { c_LotSetting = value;
                ReportPeropertyChanged("LotSetting");
            }
        }

        private int c_MarkerM;

        public int MarkerM
        {
            get { return c_MarkerM; }
            set { c_MarkerM = value;
                ReportPeropertyChanged("MarkerM");
            }
        }

        private int c_MarkerK;

        public int MarkerK
        {
            get { return c_MarkerK; }
            set { c_MarkerK = value;
                ReportPeropertyChanged("MarkerM");
            }
        }

        private int c_MekaNG;

        public int MekaNG
        {
            get { return c_MekaNG; }
            set { c_MekaNG = value;
                ReportPeropertyChanged("MekaNG");
            }
        }

        private int c_MissingIC;

        public int MissingIC
        {
            get { return c_MissingIC; }
            set { c_MissingIC = value;
                ReportPeropertyChanged("MissingIC");
            }
        }

        private string c_EmpNoEnd;

  

        public string EmpNoEnd
        {
            get { return c_EmpNoEnd; }
            set { c_EmpNoEnd = value;
                ReportPeropertyChanged("EmpNoEnd");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        //public event PropertyChangedEventHandler PropertyChanged;

        protected void ReportPeropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }




    }
   
}
