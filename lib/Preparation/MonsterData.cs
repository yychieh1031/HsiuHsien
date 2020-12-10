using System;
using CsvHelper;
using HsiuHsien.Entity;

namespace lib
{
    public class MonsterData
    {
        static public void post()
        {
            var csvFile = SqliteHelper.CsvContext("MonsterData.csv");
            using(csvFile){
                using(var csv = new CsvReader( csvFile, System.Globalization.CultureInfo.CurrentCulture))
                {
                    // Get monster data .csv
                    var monsterData = csv.GetRecords<Monster>();

                    // Connnect to db
                    var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
                    using(connection){
                        connection.DefaultTimeout = 60;
                        // Insert initial monster data
                        connection.Open();
                        var insertCmd = connection.CreateCommand();
                        foreach(var mns in monsterData)
                        {
                            insertCmd.CommandText = String.Format(@"INSERT INTO Mns_Dtl (
                                                                    Mns_No, Mns_Nm, Mns_Type,
                                                                    Lv, HP, MP, ATK, MATK,
                                                                    Critical, DEF, MDEF,
                                                                    ASPD, re_EXP, re_Mon
                                                                    ) VALUES (
                                                                    '{0}', '{1}', {2},
                                                                    '{3}', '{4}', '{5}', {6}, {7},
                                                                    {8}, {9}, {10}, 
                                                                    {11}, '{12}', '{13}')", 
                                                                    mns.Mns_No, mns.Mns_Nm, mns.Mns_Type,
                                                                    mns.Lv, mns.HP, mns.MP, mns.ATK, mns.MATK,
                                                                    mns.Critical, mns.DEF, mns.MDEF,
                                                                    mns.ASPD, mns.re_EXP, mns.re_Mon);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            
        }
    }
}