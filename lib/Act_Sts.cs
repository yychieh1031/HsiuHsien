using System;
using System.Collections.Generic;
using HsiuHsien.Entity;

namespace lib
{
    public class Act_Sts
    {
        //
        // Account Validation
        //
        public static Boolean validate(Account act)
        {
            string userId = String.Empty, userPw = String.Empty;
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = String.Format(@"SELECT * FROM Act_Dtl WHERE Act_Nm = '{0}'", act.Act_Nm);
                using(var reader = selectCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        userId = reader["Act_Id"].ToString();
                        userPw = reader["Act_Pw"].ToString();
                    }
                }
            }
            if(act.Act_Pw == userPw){
                return true;
            }else{
                return false;
            }
        }
        //
        // Get Account detail
        //
        public static Account get(string userId)
        {
            Account act = new Account();
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = String.Format(@"SELECT * FROM Act_Dtl WHERE Act_Id = '{0}'", userId);
                
                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        act.Act_Id = reader["Act_Id"].ToString();
                        act.Act_Nm = reader["Act_Nm"].ToString();
                        act.Act_Pw = reader["Act_Pw"].ToString();
                        act.Act_Mon = reader["Act_Mon"].ToString();
                        act.Act_Ch_No = reader["Act_Ch_No"].ToString();
                    }
                }
            }
            return act;
        }

        //
        // Create Account
        //
        public static void create(Account act)
        {
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = String.Format(
                    @"INSERT INTO Act_Dtl (
                        'Act_Nm', 'Act_Pw', 'Act_Mon', 'Act_Ch_No'
                        )VALUES(
                        '{0}', '{1}', '{2}', '{3}')"
                        , act.Act_Nm, act.Act_Pw, 0, '1');

                    insertCmd.ExecuteNonQuery();

                    try{
                        transaction.Commit();
                    }
                    catch(Exception ex){}  
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