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
        public static Boolean validate(ref Account act)
        {
            string userId = String.Empty, userPw = String.Empty, userMon = String.Empty, chNo = String.Empty;
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
                        userMon = reader["Act_Mon"].ToString();
                        chNo = reader["Act_Ch_No"].ToString();
                    }
                }
            }
            if(act.Act_Pw == userPw){
                act.Act_Id = userId;
                act.Act_Mon = userMon;
                act.Act_Ch_No = chNo;
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
        public static Boolean create(ref Account act)
        {
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection)
            {
                connection.DefaultTimeout = 60;
                connection.Open();

                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = String.Format(@"SELECT * FROM Act_Dtl WHERE Act_Nm = '{0}'", act.Act_Nm);
                
                using (var reader = selectCmd.ExecuteReader())
                {
                    if(!reader.Read()){
                        using (var transaction = connection.BeginTransaction())
                        {
                        var insertCmd = connection.CreateCommand();
                        insertCmd.CommandText = String.Format(
                            @"INSERT INTO Act_Dtl (
                                'Act_Nm', 'Act_Pw'
                                )VALUES(
                                '{0}', '{1}')"
                                , act.Act_Nm, act.Act_Pw);

                            insertCmd.ExecuteNonQuery();

                            try{
                                transaction.Commit();
                            }
                            catch(Exception ex){}  
                        }
                        return true;
                    }else{
                        return false;
                    }
                }
            }
        }
    }
}