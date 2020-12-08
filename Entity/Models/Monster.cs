using System;

namespace HsiuHsien.Entity
{
    public class Monster
    {
        public string Mns_No { get; set; }
        public string Mns_Nm { get; set; }
        public int Mns_Type {get; set; }
        public string Lv { get; set; }
        public string HP { get; set; }
        public string MP { get; set; }
        public int ATK { get; set; }
        public int MATK { get; set; }
        public int Critical { get; set; }
        public int DEF { get; set; }
        public int MDEF { get; set; }
        public int ASPD { get; set; }
        public string re_EXP { get; set; }
        public string re_Mon { get; set; }
    }
}
