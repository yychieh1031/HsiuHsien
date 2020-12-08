using System;
using System.Collections.Generic;

namespace lib
{
    public class ExpData
    {
        static public void post()
        {
            int[] baseWght = new int[] {200,500,2000,5000,30000,100000,300000,1000000,5000000,20000000};
            double weight = 2.85, baseLv = 1;
            string EXP = String.Empty;
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection){
                connection.DefaultTimeout = 60;
                //Insert initial exp data
                connection.Open();
                var insertCmd = connection.CreateCommand();
                for(int lv = 1; lv < 100; lv++){
                    if(lv%10 == 0){
                        baseLv++;
                        weight = weight * baseLv * 1.14;
                    }
                    EXP = ((long)(lv * weight * baseWght[(int)baseLv-1])).ToString();
                    insertCmd.CommandText = String.Format(@"INSERT INTO Exp_Dtl (Lv, EXP) VALUES ('{0}', '{1}')", lv, EXP);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }
    }
}