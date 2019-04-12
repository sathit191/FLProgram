using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    [Serializable]
    public class ClassDataQR
    {
        public string McNo {get;set;}
        public string LotNo { get; set; }
        public DateTime? LotStart { get; set; } // Datetime? คือจะทำให้ค่า เริ่มต้นเป็น NUll
        public string McType { get; set; }
        public string EmpNo { get; set; }
        public string InputQty { get; set; }
        public string TotalGood { get; set; }
        public string TotalNg { get; set; }
        public DateTime? LotClose { get; set; }
        public string Ver { get; set; }
        public string KanagataBefore { get; set; }
        public string KanagataAfter { get; set; }
        public string OneShotKanagata { get; set; }
        public string OneShotAdjust { get; set; }
        public string JigCheck { get; set; }
        public string VisualCheck { get; set; }
        public string VisualAdjust { get; set; }

        public string DeviceName { get; set; }
        public string PackageName { get; set; }
        public string Recipes { get; set; }
        public DateTime? LotSetting { get; set; }
        public int MarkerM { get; set; }
        public int MarkerK { get; set; }
        public int MekaNG { get; set; }
        public int MissingIC { get; set; }
        public string EmpNoEnd { get; set; }
        


    }
   
}
