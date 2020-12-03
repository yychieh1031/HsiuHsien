using System;
using HsiuHsien.Entity;

namespace lib
{
    public class test
    {
        static public Character Ch_testValue(){
            Character ch = new Character();
            ch.Ch_No = "1";
            ch.Ch_Nm = "Jason";
            ch.Lv = "1";
            ch.EXP = "0";
            ch.HP = "100";
            ch.MP = "100";
            ch.ATK = 10;
            ch.MATK = 1;
            ch.Critical = 5;
            ch.DEF = 6;
            ch.MDEF = 1;
            ch.STR = 1;
            ch.INT = 1;
            ch.VIT = 1;
            ch.AGI = 1;
            ch.DEX = 1;
            ch.LUK = 1;
            ch.ASPD = 1;

            return ch;
        }
        static public Monster Mns_testValue(){
            Monster Mns = new Monster();
            Mns.Mns_No = "1";
            Mns.Mns_Nm = "Doncky";
            Mns.Lv = "1";
            Mns.HP = "100";
            Mns.MP = "100";
            Mns.ATK = 10;
            Mns.MATK = 1;
            Mns.Critical = 5;
            Mns.DEF = 5;
            Mns.MDEF = 1;
            Mns.ASPD = 1;
            Mns.re_EXP = "10";
            Mns.re_Mon = "0";

            return Mns;
        }
    }
}
