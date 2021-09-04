using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCS
{
    class CalculadoraIMMS
    {
        public struct Aportaciones
        {
            public decimal EnfermedadMaternidadPatron, InvalidezVidaPatron, RetiroPatron, CesantiaPatron, InfonavitPatron, TotalPatron;
            public decimal    EnfermedadMaternidadTrabajador, InvalidezVidaTrabajador, RetiroTrabajador, CesantiaTrabajador, InfonavitTrabajador, TotalTrabajador;

        }


        public static Aportaciones Calcular(decimal sbc, decimal uma)
        {
            Aportaciones aportaciones;
            aportaciones.EnfermedadMaternidadPatron = (sbc - (3 * (uma*30)))*(1.1m)/100;
            aportaciones.EnfermedadMaternidadTrabajador = (sbc - (3 * (uma*30))) * (0.4m) / 100;
            aportaciones.InvalidezVidaPatron = sbc * 1.75m / 100;
            aportaciones.InvalidezVidaTrabajador = sbc * 0.625m / 100;
            aportaciones.RetiroPatron = sbc * 2 / 100;
            aportaciones.RetiroTrabajador = 0;
            aportaciones.CesantiaPatron = sbc * 3.150m / 100;
            aportaciones.CesantiaTrabajador = sbc * 1.125m / 100;
            aportaciones.InfonavitPatron = sbc * 5 / 100;
            aportaciones.InfonavitTrabajador = 0;
            aportaciones.TotalPatron = aportaciones.EnfermedadMaternidadPatron+aportaciones.InvalidezVidaPatron+aportaciones.RetiroPatron+aportaciones.CesantiaPatron+aportaciones.InfonavitPatron;
            aportaciones.TotalTrabajador = aportaciones.EnfermedadMaternidadTrabajador+aportaciones.InvalidezVidaTrabajador+aportaciones.RetiroTrabajador+aportaciones.CesantiaTrabajador+aportaciones.InfonavitTrabajador;
            return aportaciones;
        }

        public static void Presentacion()
        {
            decimal sbc, uma;
            Aportaciones aport;
            Console.Clear(); 
            Console.WriteLine("***Bienvenido a Calculadora IMSS***\n");
            Console.WriteLine("Ingresa tu Salario Base de Cotizacion");
            sbc = decimal.Parse((Console.ReadLine()).Trim());
            Console.WriteLine("Ingresa el valor del UMA");
            uma = decimal.Parse((Console.ReadLine()).Trim());
            aport = Calcular(sbc, uma);
            Console.WriteLine("\n-----Aportaciones del Patron-----\n\n");
            Console.WriteLine($"Enfermedades y Maternidad: {aport.EnfermedadMaternidadPatron}\nInvalidez y Vida: {aport.InvalidezVidaPatron}");
            Console.WriteLine($"Retiro: {aport.RetiroPatron}\nCesantia: {aport.CesantiaPatron}\nCredito Infonavit: {aport.InfonavitPatron}\nTotal: {aport.TotalPatron}\n");

            Console.WriteLine("-----Aportaciones del Trabajador-----\n");
            Console.WriteLine($"Enfermedades y Maternidad: {aport.EnfermedadMaternidadTrabajador}\nInvalidez y Vida: {aport.InvalidezVidaTrabajador}");
            Console.WriteLine($"Retiro: {aport.RetiroTrabajador}\nCesantia: {aport.CesantiaTrabajador}\nCredito Infonavit: {aport.InfonavitTrabajador}\nTotal:{aport.TotalTrabajador}\n");
        }
    }
}
