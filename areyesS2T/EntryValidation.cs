using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace areyesS2T
{
    public class EntryValidation
    {

        public void CamposVacios(Dictionary<string, string> notas)
        {
            foreach (var clave in notas)
            {
                if (string.IsNullOrEmpty(clave.Value) && string.IsNullOrWhiteSpace(clave.Value))
                {

                    throw new InputException("El campo " + clave.Key + " esta vacio.");

                }
            }
        }

        public void RangoNotas(Dictionary<string, string> notas)
        {
            foreach (var clave in notas)
            {
                if (double.Parse(clave.Value) < 0.1 || double.Parse(clave.Value) > 10)
                {
                    throw new InputException("La " + clave.Key + " debe ser mayor a 0,1 y menor a 10.");
                }

            }

        }

        public void ValidarCaracteres(Dictionary<string, string> notas)
        {
            Regex regex = new Regex(@"^[\d.]+$");

            foreach (var fila in notas)
            {


                if (regex.IsMatch(fila.Value))
                {
                    //pasa el filtro porque es correcto el ingreso
                }
                else
                {
                    throw new InputException("El campo " + fila.Key + " debe contener solo números enteros o decimales!");
                }

            }

        }

        public void NumerosNegativos(Dictionary<string, string> notas)
        {
            foreach (var clave in notas)
            {
                if (double.Parse(clave.Value) <= 0)
                {
                    throw new InputException("La " + clave.Key + " no puede ser negativa o igual a cero!");
                }
            }
        }
    }
}
