using System;
using System.Configuration;
using System.IO;
using Microsoft.Data.Sqlite;

namespace lib
{
    public class TableCreate
    {
        //
        // Create Character Detail Table 
        //
        static public void Ch_Dtl_Table()
        {
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection){
                connection.DefaultTimeout = 60;
                //If table not exist than create one
                connection.Open();
                 var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = String.Format(@"CREATE TABLE IF NOT EXISTS Ch_Dtl(
                                                            Ch_No VARCHAR(255) PRIMARY KEY,
                                                            Ch_Nm VARCHAR(100),
                                                            Lv VARCHAR(100),
                                                            EXP VARCHAR(255),
                                                            HP VARCHAR(255),
                                                            MP VARCHAR(255),
                                                            ATK INTEGER,
                                                            MATK INTEGER,
                                                            Critical INTEGER,
                                                            DEF INTEGER,
                                                            MDEF INTEGER,
                                                            STR INTEGER,
                                                            INT INTEGER,
                                                            VIT INTEGER,
                                                            AGI INTEGER,
                                                            DEX INTEGER,
                                                            LUK INTEGER,
                                                            ASPD INTEGER)"
                                                            );
                createTableCmd.ExecuteNonQuery();
            }
        }

        //
        // Create Monster Detail Table
        //
        static public void Mns_Dtl_Table()
        {
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection){
                connection.DefaultTimeout = 60;
                //If table not exist than create one
                connection.Open();
                 var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = String.Format(@"CREATE TABLE IF NOT EXISTS Mns_Dtl(
                                                            Mns_No VARCHAR(255) PRIMARY KEY,
                                                            Mns_Nm VARCHAR(100),
                                                            Lv VARCHAR(100),
                                                            HP VARCHAR(255),
                                                            MP VARCHAR(255),
                                                            ATK INTEGER,
                                                            MATK INTEGER,
                                                            Critical INTEGER,
                                                            DEF INTEGER,
                                                            MDEF INTEGER,
                                                            ASPD INTEGER,
                                                            re_EXP VARCHAR(255),
                                                            re_Mon VARCHAR(255))"
                                                            );
                createTableCmd.ExecuteNonQuery();
            }
        }

        //
        // Create Exp Detail Table
        //
        static public void Exp_Dtl_Table()
        {
            var connection = SqliteHelper.DBContext("HsiuHsien_MainDB.db");
            using(connection){
                connection.DefaultTimeout = 60;
                //If table not exist than create one
                connection.Open();
                 var createTableCmd = connection.CreateCommand();
                createTableCmd.CommandText = String.Format(@"CREATE TABLE IF NOT EXISTS Exp_Dtl(
                                                            Lv VARCHAR(100) PRIMARY KEY,
                                                            EXP VARCHAR(255))"
                                                            );
                createTableCmd.ExecuteNonQuery();
            }
        }
    }   
}