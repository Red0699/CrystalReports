using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace CrystalReports.Reports
{
    public class ReportesConexion
    {
        public static CrystalDecisions.Shared.ConnectionInfo getConexion()
        {
            CrystalDecisions.Shared.ConnectionInfo infocon = new
                CrystalDecisions.Shared.ConnectionInfo();
            infocon.ServerName = @"DESKTOP-L70286L\SQLEXPRESS";
            infocon.DatabaseName = "mitienda";
            infocon.IntegratedSecurity = true;

            return infocon;
        }

    }
}