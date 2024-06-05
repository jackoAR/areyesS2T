using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace areyesS2T
{
    public class Calificacion


    {

        double seguimiento1;
        double seguimiento2;

        public static double Notaseguimiento1(double seguimiento1)
        {
            return seguimiento1 * 0.3;
        }

        public static double NotaExamen(double seguimiento2)
        {
            return seguimiento2 * 0.2;
        }

        public static double NotaParcial1(double seguimiento1, double seguimiento2)
        {
            return seguimiento1 + seguimiento2;
        }

        public static double NotaSeguimiento2(double seguimiento1P2)
        {
            return seguimiento1P2 * 0.2;
        }

        public static double NotaExamen2(double notaExamen2)
        {
            return notaExamen2 * 0.2;
        }

        public static double NotaFinal(double notaParcial1, double notaParcial2) {

            return notaParcial1 + notaParcial2;
        }

        public static string Estado(double notaFinal)
        {

            if (notaFinal >= 7)
            {
                return "Aprobado";
            }
            else if (notaFinal >= 5 && notaFinal <= 6.9)
            {
                return "Complementario";
            }
            else if (notaFinal < 5)
            {
                return "Reprobado";
            }
                    
             
        }
    }
}
