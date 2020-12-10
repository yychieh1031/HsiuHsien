using System;
using System.Collections.Generic;

namespace HsiuHsien.Entity
{
    public class BattleReport
    {
        public Account Acc_Dtl { get; set; }
        public Character Ch_Dtl { get; set; }
        public List<Monster> Mns_Dtl { get; set; }
        public List<string> message { get; set; }
        public Room room { get; set; }
    }
}
