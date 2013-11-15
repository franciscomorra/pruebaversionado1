using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;
using ClinicaFrba.Negocio;

namespace ClinicaFrba.Core
{
    /// <summary>
    /// Mantiene los datos de la sesion actual
    /// </summary>
    class Session
    {

        public static User User { get; private set; } //El que se esta logueando
        //Los siguientes son para la seleccion entre formularios
        public static Afiliado Afiliado { get;  set; } //El que se esta logueando
        public static Profesional Profesional { get;  set; } //El que se esta logueando
        public static String Errores { get; set; } //El que se esta logueando
        public static void StartSession(User user)
        {
            User = user; //Recibe la info del usuario
            ViewsManager.LoadMenu();
            
        }

        /// <summary>
        /// Cierra la sesion actual
        /// </summary>
        public static void Salir()
        {
            User = null;//Limpia la info del usuario
            Profesional = null;
            Afiliado = null;
            ViewsManager.BorrarMenu();
        }
    }
}

