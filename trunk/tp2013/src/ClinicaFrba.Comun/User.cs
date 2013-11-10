using System;
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
        public List<Functionalities> Permissions { get; private set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public Profile Perfil{ get; set; }
        public BindingList<Rol> Roles { get; set; } 
        public string UserName { get; set; }
        public bool FaltanDatos { get; set; }
        public DetallesPersona DetallePersona { get; set; }

        public User()
        {
            Permissions = new List<Functionalities>();
            DetallePersona = new DetallesPersona();
        }

        public override string ToString()
        {
            return DetallePersona.Apellido+", "+DetallePersona.Nombre;
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
