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
        public static Afiliado Afiliado { get; private set; } 
        public static Profesional Profesional { get; private set; }
        public static Turno Turno { get; private set; }

        public static void StartSession(User user)
        {
            User = user; //Recibe la info del usuario
            Afiliado = new Afiliado();
            Profesional = new Profesional();
            Turno = new Turno();
            ViewsManager.LoadMenu();
        }

        /// <summary>
        /// Cierra la sesion actual
        /// </summary>
        public static void Salir()
        {
            User = null;//Limpia la info del usuario
            Afiliado = null;
            Profesional = null;
            Turno = null;
            ViewsManager.BorrarMenu();
        }
    }
}

