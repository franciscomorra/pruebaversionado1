using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Common
{
    public class Semestre
    {

        public static DateTime calcularFechaSemestre(int anio, int semestre)
        {
            DateTime retorno;

            if( semestre == 1) {
                retorno = new DateTime(anio, 6, 30);

            }else {
                retorno = new DateTime(anio, 12, 31);
            }

            return retorno;
        }

    }
}
