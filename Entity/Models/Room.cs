using System;

namespace HsiuHsien.Entity
{
    public class Room
    {
        public string Ro_No { get; set; }
        public string Ro_Nm { get; set; }
        public string Ro_Lv { get; set; }
        public int Ro_Type {get; set; }
        public string Ro_Bos_No { get; set; }
        public string Mns_No { get; set; }
        public string Pre_Ro_No { get; set; }
        public string Child_Ro_No { get; set; }
    }
}
