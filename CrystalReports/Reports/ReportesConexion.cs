using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace CrystalReports.Reports
{
    public class ReportesConexion
    {
        //Metodo que devolvera la conexion al reporte
        public static CrystalDecisions.Shared.ConnectionInfo getConexion()
        {
            CrystalDecisions.Shared.ConnectionInfo infocon = new
                CrystalDecisions.Shared.ConnectionInfo(); //Sirve para dar como parametro al reporte mediante esa Conexion de informacion
            infocon.ServerName = @"DESKTOP-L70286L\SQLEXPRESS"; //Nombre del servidor de la base de datos
            infocon.DatabaseName = "mitienda"; //Nombre de la base de datos
            infocon.IntegratedSecurity = true; 

            return infocon;
        }

    }
}