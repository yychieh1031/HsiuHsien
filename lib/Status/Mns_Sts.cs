using System;
using HsiuHsien.Entity;

namespace lib
{
    public class Mns_Sts
    {
        //
        // Get room Detail
        //
        static public BattleReport get(BattleReport btrpt)
        {
            Monster mns = new Monster();
            // Clear Monster Pre-Data
            btrpt.Mns_Dtl.Clear();
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                var selectRouteCmd = connection.CreateCommand();
                selectRouteCmd.CommandText = String.Format(@"SELECT * FROM Mns_Dtl WHERE Mns_No = '{0}'", btrpt.room.Mns_No);
                using(var readerRoute = selectRouteCmd.ExecuteReader())
                {
                    while(readerRoute.Read())
                    {
                        mns.Mns_No = readerRoute["Mns_No"].ToString();
                        mns.Mns_Nm = readerRoute["Mns_Nm"].ToString();
                        mns.Mns_Type = Convert.ToInt32(readerRoute["Mns_Type"]);
                        mns.Lv = readerRoute["Lv"].ToString();
                        mns.HP = readerRoute["HP"].ToString();
                        mns.MP = readerRoute["MP"].ToString();
                        mns.ATK = Convert.ToInt32(readerRoute["ATK"]);
                        mns.MATK = Convert.ToInt32(readerRoute["MATK"]);
                        mns.Critical = Convert.ToInt32(readerRoute["Critical"]);
                        mns.DEF = Convert.ToInt32(readerRoute["DEF"]);
                        mns.MDEF = Convert.ToInt32(readerRoute["MDEF"]);
                        mns.ASPD = Convert.ToInt32(readerRoute["ASPD"]);
                        mns.re_EXP = readerRoute["re_EXP"].ToString();
                        mns.re_Mon = readerRoute["re_Mon"].ToString();
                    }
                }
                btrpt.Mns_Dtl.Add(mns);
            }
            
            return btrpt;
        }
    }   
}