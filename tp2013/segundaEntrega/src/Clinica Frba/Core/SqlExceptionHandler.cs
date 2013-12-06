using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicaFrba.Core
{
    class SqlExceptionHandler
    {
        public static void Handle(SqlException exception)
        {
            var message = exception.Message.ToUpperInvariant();
            foreach (var key in ConstraintMessages.Keys)
            {
                if (message.Contains(key))
                {
                    MessageBox.Show(ConstraintMessages[key]);
                    return;
                }
            }
            MessageBox.Show(exception.Message);
        }

        private static Dictionary<string, string> ConstraintMessages
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {"IX_USUARIO", "Ya hay un usuario con ese DNI, seleccione otro por favor."}
                };
            }
        }
    }
}
