using System;
using HsiuHsien.Entity;

namespace lib
{
    public class Ro_Rou
    {
        //
        // Initial route set
        //
        static public void post(BattleReport btrpt)
        {
            
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection){
                connection.DefaultTimeout = 60;
                //Insert initial exp data
                connection.Open();
                var insertCmd = connection.CreateCommand();
                
                insertCmd.CommandText = String.Format(@"INSERT INTO Ro_Rou( Ro_No, Ch_No) VALUES( '1', '{0}')", btrpt.Ch_Dtl.Ch_No);
                insertCmd.ExecuteNonQuery();
            }
        }
    }   
}