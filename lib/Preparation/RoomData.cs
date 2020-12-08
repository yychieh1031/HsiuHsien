using System;
using System.Collections.Generic;

namespace lib
{
    public class RoomData
    {
        static public void post()
        {
            
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection){
                connection.DefaultTimeout = 60;
                //Insert initial exp data
                connection.Open();
                var insertCmd = connection.CreateCommand();
                
                insertCmd.CommandText = String.Format(@"INSERT INTO Ro_Dtl (
                                                        Ro_No, Ro_Lv, Ro_Nm, Ro_Type, 
                                                        Ro_Bos_No, Mns_No, Pre_Ro_No, Child_Ro_No
                                                        ) VALUES (
                                                        '{0}', '{1}', '{2}', {3},
                                                        '{4}', '{5}', '{6}', '{7}')",
                                                        "1", "1", "Noobies Room", 0,
                                                        null, null, null, null
                                                        );
                insertCmd.ExecuteNonQuery();
            }
        }
    }
}