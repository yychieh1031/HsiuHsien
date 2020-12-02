using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            lib.Ch_Sts.get();
            //lib.Ch_Sts.post();
            // Initial Setting ex. Create DB and Insert data
            string dir = ConfigurationManager.AppSettings["dir"];
            dir += "/HsiuHsien_MainDB.db";
            if(!File.Exists(dir)){
                lib.TableCreate.Ch_Dtl_Table();
                lib.TableCreate.Mns_Dtl_Table();
                lib.TableCreate.Exp_Dtl_Table();
                lib.ExpData.post();
            }
            // Application Run
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Form());
        }
    }
}
