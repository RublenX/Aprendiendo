using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFrmReferenciaExterna
{
    public class Resolucion271186
    {
        public static void ProbarExpresionRegular()
        {
            // Respuesta a https://es.stackoverflow.com/questions/271186/c-remover-saltos-de-lineas-de-un-texto-y-dejar-todo-en-lineas
            string texto = "[hola esto es una prueba] [Vamos a probar\r\nque sustituye los saltos\r\nde forma correcta] [Y\r\nsi funciona lo publico]\r\n[Esta debe serguir en una línea distinta] [Y\r\nprobamos otra vez]";
            string textoModificado = Regex.Replace(texto, @"\[{1}[^\]]*(\r\n)+[^\]]*\]", (m) =>
            {
                return m.Groups[0].Value.Replace("\r\n", " ");
            });
        }
    }
}
