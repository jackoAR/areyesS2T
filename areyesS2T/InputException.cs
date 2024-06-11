using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace areyesS2T
{
    public class InputException : Exception
    {
        public InputException() { }// constructores defines a la clase y sus parametros

        //constructor que acpeta solo mensajes y
        //base(message) llama al constructor de la clase base (Exception) que acepta un mensaje de error.
        public InputException(string message) : base(message) { }

        //Permite especificar un mensaje de error y una excepción interna que causó esta excepción.
        //: base(message, inner) llama al constructor de la clase base (Exception) que acepta un mensaje de error y una excepción interna.
        public InputException(string message, Exception inner) : base(message, inner) { }
    }

}
