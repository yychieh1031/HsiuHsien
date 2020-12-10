using System;
using CsvHelper;
using HsiuHsien.Entity;

namespace lib
{
    public class RoomData
    {
        static public void post()
        {
            var csvFile = SqliteHelper.CsvContext("RoomData.csv");
            using(csvFile){
                using(var csv = new CsvReader( csvFile, System.Globalization.CultureInfo.CurrentCulture))
                {
                    // Get room data
                    var roomData = csv.GetRecords<Room>();

                    // Connect to db
                    var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
                    using(connection){
                        connection.DefaultTimeout = 60;
                        //Insert initial room data
                        connection.Open();
                        var insertCmd = connection.CreateCommand();
                        foreach(var rm in roomData)
                        {
                            insertCmd.CommandText = String.Format(@"INSERT INTO Ro_Dtl (
                                                                    Ro_No, Ro_Lv, Ro_Nm, Ro_Type, 
                                                                    Ro_Bos_No, Mns_No, Pre_Ro_No, Child_Ro_No
                                                                    ) VALUES (
                                                                    '{0}', '{1}', '{2}', {3},
                                                                    '{4}', '{5}', '{6}', '{7}')",
                                                                    rm.Ro_No, rm.Ro_Lv, rm.Ro_Nm, rm.Ro_Type,
                                                                    rm.Ro_Bos_No, rm.Mns_No, rm.Pre_Ro_No, rm.Child_Ro_No
                                                                    );
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}