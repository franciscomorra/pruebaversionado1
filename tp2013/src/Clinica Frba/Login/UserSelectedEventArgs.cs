using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClinicaFrba.Comun;

namespace ClinicaFrba.Login
{
    public class UserSelectedEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}
