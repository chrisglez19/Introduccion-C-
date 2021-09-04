using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    class Calculadora
    {
        public static decimal Sumar(decimal a, decimal b)
        {
            decimal resultado = a + b;
            return resultado;
        }

        public static decimal Restar(decimal a, decimal b)
        {
            decimal resultado = a - b;
            return resultado;
        }

        public static decimal Multiplicar(decimal a, decimal b)
        {
            decimal resultado = a * b;
            return resultado;
        }

        public static decimal Dividir(decimal a, decimal b)
        {
            decimal resultado = a / b;
            return resultado;
        }

        public static decimal Modulo(decimal a, decimal b)
        {
            decimal resultado = a % b;
            return resultado;
        }

        public enum operacion
        {
            Sumar,
            Restar,
            Multiplicar,
            Dividir,
            Modulo,
            Todas
        }

        public struct OperacionAritmetica
        {
            public decimal a, b;
            public operacion op;
        }

        public static decimal Operacion(decimal a,decimal b, operacion op)
        {
            decimal resultado;
            OperacionAritmetica oper ;
            oper.a = a;
            oper.b = b;
            oper.op = op;
            switch (oper.op)
            {
                case operacion.Sumar:
                    resultado = Sumar(oper.a, oper.b);
                    break;
                case operacion.Restar:
                    resultado = Restar(oper.a, oper.b);
                    break;
                case operacion.Multiplicar:
                    resultado = Multiplicar(oper.a, oper.b);
                    break;
                case operacion.Dividir:
                    resultado = Dividir(oper.a, oper.b);
                    break;
                case operacion.Modulo:
                    resultado = Modulo(oper.a, oper.b);
                    break;
                case operacion.Todas:
                default:
                    resultado = 0;
                    Console.WriteLine("Operador No Valido");
                    break;

            }
            return resultado;
        }

        public struct Resultados
        {
            public decimal suma, resta, multiplicacion, division, modulo;
        }


        public static Resultados Simultaneas(decimal a, decimal b)
        {
            Resultados resultados;
            resultados.suma = Sumar(a, b);
            resultados.resta = Restar(a, b);
            resultados.multiplicacion = Multiplicar(a, b);
            resultados.division = Dividir(a, b);
            resultados.modulo = Modulo(a, b);
            return resultados;

        }
        public static void Presentacion()
        {
            Resultados result;
            decimal a, b, resultado;
            operacion op;
            Console.Clear();
            Console.WriteLine("****Bienvenido a Calculadora****\n\n");
            Console.WriteLine("1.-Suma\n2.-Resta\n3.-Multiplicacion\n4.-Division\n5.-Modulo\n6.-Todas\n");
            Console.WriteLine("Selecciona operacion a realizar\n");
            op = (operacion)int.Parse(Console.ReadLine())-1;
            Console.WriteLine("Ingresa el numero 1");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el numero 2");
            b = int.Parse(Console.ReadLine());
            if (op == operacion.Todas)
            {
                result = Simultaneas(a, b);
                Console.WriteLine($"1.-Suma:{result.suma}\n2.-Resta: {result.resta}\n3.-Multiplicacion: {result.multiplicacion}\n4.-Division: {result.division}\n5.-Modulo: {result.modulo}\n");
            }
            else
            {
                resultado = Operacion(a, b, op);
                Console.WriteLine($"El resultado es{resultado.ToString()}");
            }
            
        }
    }
}
