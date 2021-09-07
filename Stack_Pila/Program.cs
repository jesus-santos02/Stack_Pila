using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Pila
{
    class Program
    {
        static void Main(string[] args)
        {
            CStack pila = new CStack();

            pila.Push(5);
            pila.Push(10);
            pila.Push(25);
            pila.Push(7);
            Console.WriteLine("---------");
            pila.Transversa();
            Console.WriteLine("---------");

            pila.Pop();
            pila.Transversa();

        }
    }

    public class CNodo
    {
        private int dato;

        private CNodo siguiente = null;

        public int Dato { get => dato; set => dato = value; }
        public CNodo Siguiente { get => siguiente; set => siguiente = value; }

        public override string ToString()
        {
            return string.Format("[{0}]", dato);
        }
    }

    class CStack
    {
        //Hacemos una implementacion basada en la lista ligada

        //Es el ancla o encabezado del stack
        private CNodo ancla;

        //Esta variable de referencia nos ayuda a trabajar con el stack
        private CNodo trabajo;

        public CStack()
        {
            //Instanciamos el ancla
            ancla = new CNodo();

            //Como es un stack vacio su siguiente es null
            ancla.Siguiente = null;
        }
        //CNodo temp = new CNodo();
        //Push 
        public void Push(int pDato)
        {
            //Creamos el nodo temporal
            CNodo temp = new CNodo();
            temp.Dato = pDato;

            //Conectamos el temporal a la lista
            temp.Siguiente = ancla.Siguiente;

            //Conectamos el ancla al temporal
            ancla.Siguiente = temp; trabajo = temp;

            Console.WriteLine("Valor Ancla: {0}", ancla);
            Console.WriteLine("Valor Ancla.Siguiente: {0}", ancla.Siguiente);
            Console.WriteLine("Valor temp: {0}", temp);
            Console.WriteLine("Valor temp.Siguiente: {0}", temp.Siguiente);
        }

        //Pop
        public int Pop()
        {
            //Esta version no contiene codigo de seguridad
            //Colocar una excepcion cuando se intente hacer un pop a un stack vacio

            int valor = 0;

            //Llevamos a cabo el trabajo solo si hay elementos en el stack
            if (ancla.Siguiente != null)
            {
                //Obtenemos el dato correspondiente
                trabajo = ancla.Siguiente;
                valor = trabajo.Dato;

                //Lo sacamos del stack
                ancla.Siguiente = trabajo.Siguiente;
                trabajo.Siguiente = null;
            }
            return valor;
        }

        //Peek
        public int Peek()
        {
            //Esta version no contiene codigo de seguridad
            //Colocar una excepcion cuando se intente hacer un pop a un stack vacio

            int valor = 0;
            //Llevamos a cabo el trabajo solo si hay elementos en el stack
            if (ancla.Siguiente != null)
            {
                //Obtenemos el dato correspondiente
                trabajo = ancla.Siguiente;
                valor = trabajo.Dato;
            }
            return valor;
        }

        //Transversa
        public void Transversa()
        {
            //Trabajo al inicio
            trabajo = ancla;

            //Recorremos hasta encontrar el final
            while (trabajo.Siguiente != null)
            {
                //Avanzamos trabajo
                trabajo = trabajo.Siguiente;

                //Obtenemos el dato y lo mostramos
                int d = trabajo.Dato;

                Console.WriteLine("[{0}]", d);
            }
        }

        //public void Estado()
        //{
        //    Console.WriteLine("Valor Ancla: {0}", ancla);
        //    Console.WriteLine("Valor Ancla.Siguiente: {0}", ancla.Siguiente);
        //    Console.WriteLine("Valor temp: {0}", temp);
        //    Console.WriteLine("Valor temp.Siguiente: {0}", temp.Siguiente);
        //}
    }

}
