using System;
using System.Collections.Generic;
using HsiuHsien.Entity;

namespace lib
{
    public class Ch_Sts
    {
        //
        // Get Character detail
        //
        public static Character get(){
            Character ch = new Character();
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = @"SELECT * FROM Ch_Dtl";
                
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

        //
        // Create Character
        //
        public static void create()
        {
            //Character ch = new Character();
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = String.Format(
                    @"INSERT INTO Ch_Dtl (
                        Ch_No, Ch_Nm, Lv, EXP, 
                        HP, MP, ATK, MATK,
                        Critical, DEF, MDEF,
                        STR, INT, VIT, AGI,
                        DEX, LUK, ASPD
                        )VALUES(
                        '{0}', '{1}', '{2}', '{3}', 
                        '{4}', '{5}', {6}, {7}, 
                        {8}, {9}, {10}, 
                        {11}, {12}, {13}, {14}, 
                        {15}, {16}, {17})",

                        "1", "Jason", "1", "0",
                        "100", "100", 10, 1,
                        5, 1, 1,
                        1, 1, 1, 1,
                        1, 1, 1);

                    insertCmd.ExecuteNonQuery();

                    try{
                        transaction.Commit();
                    }
                    catch(Exception ex){
                        //Console.WriteLine("{0}", ex.ToString());
                    }  
                }
            }
        }
        public static void update(Character ch)
        {
            ch = check(ch);
            //Character ch = new Character();
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                var updateCmd = connection.CreateCommand();
                updateCmd.CommandText = String.Format(
                    @"UPDATE Ch_Dtl SET Lv = '{0}', EXP = '{1}' WHERE Ch_No = {2}", ch.Lv, ch.EXP, ch.Ch_No);

                    updateCmd.ExecuteNonQuery();

                    try{
                        transaction.Commit();
                    }
                    catch(Exception ex){
                        //Console.WriteLine("{0}", ex.ToString());
                    }  
                }
            }
        }
        //
        // Check for leveling up
        //
        private static Character check(Character ch)
        {
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            var nextEXP = String.Empty;
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = String.Format(@"SELECT * FROM Exp_Dtl WHERE Lv = {0}", ch.Lv);
                using(var reader = selectCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        nextEXP = reader["EXP"].ToString();
                    }
                }
                connection.Close();
            }
            if(Convert.ToInt32(nextEXP)<=Convert.ToInt32(ch.EXP))
            {
                ch.Lv = (Convert.ToInt32(ch.Lv)+1).ToString();
            }
            return ch;
        }
    }
}