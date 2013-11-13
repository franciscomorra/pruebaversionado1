using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FrbaBus.Common
{

    public class Configuracion
    {

        private Configuracion() { }
        private static readonly Configuracion instancia = new Configuracion();
        public Usuario usuario;
        public event EventHandler<EventArgs> cerrarSe;


        public void meCierro(){
            cerrarSe(this, new EventArgs());
        }
        public static Configuracion Instancia()
        {
                return instancia;
        }

        public static DateTime fechaAhora()
        {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("../../../app.config");
                XmlNodeList fecha = xDoc.GetElementsByTagName("FechaAhora");
                return DateTime.Parse(fecha[0].InnerXml.ToString());
              
        }

        public static String ConnectionString()
        {
            
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("../../../app.config");
            XmlNodeList ConnectionString = xDoc.GetElementsByTagName("ConnectionString");
            return ConnectionString[0].InnerXml.ToString();
        }

    }
}