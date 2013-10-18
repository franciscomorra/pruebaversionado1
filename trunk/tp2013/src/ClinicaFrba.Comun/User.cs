﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ClinicaFrba.Comun
{
    /// <summary>
    /// Representa a un usuario logueado en el sistema
    /// </summary>
    public class User
    {
        /// <summary>
        /// Permisos con los que cuenta el usuario
        /// </summary>
        public List<Functionalities> Permissions { get; private set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Role ID
        /// </summary>
        
        //public int RolSeleccionado { get; set; }
        public int RoleID { get; set; }

        public BindingList<Rol> Roles { get; set; } 
            //List<Rol> Roles { get; set; }
       // public SortedDictionary<Rol> Roles { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string UserName { get; set; }

        public DetallesPersona DetallePersona { get; set; }

        public User()
        {
            Permissions = new List<Functionalities>();
            DetallePersona = new DetallesPersona();
        }

        public override string ToString()
        {
            return UserName;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType().IsSubclassOf(typeof(User)))) return false;
            return ((User)obj).UserID == UserID;
        }

        public override int GetHashCode()
        {
            return UserID.GetHashCode();
        }
    }
}