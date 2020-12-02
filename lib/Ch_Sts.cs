using System;
using System.Collections.Generic;
using HsiuHsien.Entity;

namespace lib
{
    public class Ch_Sts
    {
        public static Character get(){
            Character ch = new Character();
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection){
                connection.DefaultTimeout = 60;
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Ch_Dtl";
                
                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        ch.Ch_No = reader["Ch_No"].ToString();
                        ch.Ch_Nm = reader["Ch_Nm"].ToString();
                        ch.Lv = reader["Lv"].ToString();
                        ch.EXP = reader["EXP"].ToString();
                        ch.HP = reader["HP"].ToString();
                        ch.MP = reader["MP"].ToString();
                        ch.ATK = Convert.ToInt32(reader["ATK"]);
                        ch.MATK = Convert.ToInt32(reader["MATK"]);
                        ch.Critical = Convert.ToInt32(reader["Critical"]);
                        ch.DEF = Convert.ToInt32(reader["DEF"]);
                        ch.MDEF = Convert.ToInt32(reader["MDEF"]);
                        ch.STR = Convert.ToInt32(reader["STR"]);
                        ch.INT = Convert.ToInt32(reader["INT"]);
                        ch.VIT = Convert.ToInt32(reader["VIT"]);
                        ch.AGI = Convert.ToInt32(reader["AGI"]);
                        ch.DEX = Convert.ToInt32(reader["DEX"]);
                        ch.LUK = Convert.ToInt32(reader["LUK"]);
                        ch.ASPD = Convert.ToInt32(reader["ASPD"]);
                    }
                }
            }
            return ch;
        }
    }
}