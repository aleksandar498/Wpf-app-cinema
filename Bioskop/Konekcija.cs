using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Bioskop
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnsb = new SqlConnectionStringBuilder();
            ccnsb.DataSource= @"DESKTOP-1709\SQLEXPRESS";
            ccnsb.InitialCatalog = @"Bioskop";
            ccnsb.IntegratedSecurity = true;
            string con = ccnsb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
