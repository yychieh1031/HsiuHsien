using System;
using HsiuHsien.Entity;

namespace lib
{
    public class Ro_Sts
    {
        //
        // Get room Detail
        //
        static public Room get(BattleReport btrpt)
        {
            Room room = new Room();
            string roNo = String.Empty;
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                var selectRouteCmd = connection.CreateCommand();
                selectRouteCmd.CommandText = String.Format(@"SELECT * FROM Ro_Rou WHERE Ch_No = '{0}'", btrpt.Ch_Dtl.Ch_No);
                using(var readerRoute = selectRouteCmd.ExecuteReader())
                {
                    while(readerRoute.Read())
                    {
                        roNo = readerRoute["Ro_No"].ToString();
                    }
                }

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = String.Format(@"SELECT * FROM Ro_Dtl WHERE Ro_No = '{0}'", roNo);
                using(var reader = selectCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        room.Ro_No = reader["Ro_No"].ToString();
                        room.Ro_Nm = reader["Ro_Nm"].ToString();
                        room.Ro_Type = Convert.ToInt32(reader["Ro_Type"]);
                        room.Mns_No = reader["Mns_No"].ToString();
                        room.Ro_Bos_No = reader["Ro_Bos_No"].ToString();
                        room.Ro_Lv = reader["Ro_Lv"].ToString();
                        room.Pre_Ro_No = reader["Pre_Ro_No"].ToString();
                        room.Child_Ro_No = reader["Child_Ro_No"].ToString();
                    }
                }
            }
            return room;
        }
    }   
}