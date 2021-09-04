using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class OperacionesBasicas2
    {
        public static List<Estado> estados;
        public static List<Alumnos> alumnos;
        public static List<Estatus> status;
        public static void MetLinQ()
        {
            Serializar();
            //1.De la lista de estados, obtener el estado que tiene el id = 5
            Console.WriteLine("Consulta 1");
            var consulta1 =
                    from edo in estados
                    where edo.id == 5
                    select edo;
            foreach (var edoSelect in consulta1)
            {
                Console.WriteLine($"Id: {edoSelect.id} Estado: {edoSelect.nombre}");
            }

            //2.De la lista de alumnos obtener a los alumnos cuyo idEstado 29 y 13, Ordenado
            //por nombre
            Console.WriteLine("\nConsulta 2");

            var consulta2 =
                from alu in alumnos
                join edo in estados on alu.idEstado equals edo.id
                where alu.idEstado == 29 || alu.idEstado== 13
                orderby alu.nombre
                select new { Nombre = alu.nombre, EstadoAlu = alu.idEstado };
            foreach (var aluSelect in consulta2)
            {
                Console.WriteLine($"Id: {aluSelect.Nombre} Estado: {aluSelect.EstadoAlu}");
            }

            //3.De la lista de alumnos obtener los alumnos que son IdEstado 19 y 20 y
            //además de que estén en el estatus 4 o 5
            Console.WriteLine("\nConsulta 3");
            var consulta3 =
                from alu in alumnos
                join edo in estados on alu.idEstado equals edo.id
                //join stat in status on alu.idEstatus equals stat.id
                where (alu.idEstado == 19 || alu.idEstado == 20)&&(alu.idEstatus==4 || alu.idEstatus==5)
                orderby alu.nombre
                select new { Nombre = alu.nombre, EstadoAlu = alu.idEstado, Status = alu.idEstatus };
            foreach (var aluSelect in consulta3)
            {
                Console.WriteLine($"Id: {aluSelect.Nombre} Estado: {aluSelect.EstadoAlu} Estatus: {aluSelect.Status}");
            }
            //4.Obtener una lista de los alumnos que tienen calificación aprobatoria,
            //considerando esta como 6 o mayor, ordenado por calificación del mayor al
            //   menor
            Console.WriteLine("\nConsulta 4");

            var consulta4 =
                from alu in alumnos
                where alu.calificacion >= 6
                orderby alu.calificacion descending
                select alu;
            foreach (var aluselect in consulta4)
            {
                Console.WriteLine($"Alumno: {aluselect.nombre} Calificacion: {aluselect.calificacion}");
            }
            //5.Obtener la calificación promedio de los alumnos
            Console.WriteLine("\nConsulta 5");
            var consulta5 =
                from alu in alumnos
                select new
                {
                    alu.calificacion
                };
            int suma=0;
            foreach (var cal in consulta5)
            {
                suma = suma + cal.calificacion;
            }

            decimal prom = suma/alumnos.Count();
            Console.WriteLine($"El promedio es: {prom}");
            

            //6.En caso de que todos los alumnos de que ningún alumno tenga 10, sumarles
            //un punto de calificación, y en caso de que todos estén entre 6 y 7 sumarles
            //dos puntos.

            var mayorA10 = alumnos.All(x => x.calificacion == 10);
            var entre6y7 = alumnos.All(x => x.calificacion == 7|| x.calificacion==6);
            var consultaSimple = from alu in alumnos
                                 select alu;
            if (mayorA10)
            {
                foreach(var alumno in consultaSimple)
                {
                    alumno.calificacion = alumno.calificacion + 1;
                }
            }
            if(entre6y7)
            {
                foreach (var alumno in consultaSimple)
                {
                    alumno.calificacion = alumno.calificacion + 2;
                }
            }

            //7.Mostar en la consola los siguientes datos, de aquellos alumnos que estén en
            //estatus 3:
            //a.idAlumnos,
            //b.nombreAlumno,
            //c.nombre del Estado al que pertenece
            Console.WriteLine("\nConsulta 7");
            var consulta7 =
                from alu in alumnos
                join edo in estados on alu.idEstado equals edo.id
                where alu.idEstatus == 3
                select new { Nombre = alu.nombre, EstadoAlu = edo.nombre, Id = alu.id };
            foreach (var aluSelect in consulta7)
            {
                Console.WriteLine($"Id: {aluSelect.Id} Nombre: {aluSelect.Nombre} Estado: {aluSelect.EstadoAlu}");
            }

            //8.Mostar en la consola los siguientes datos, de aquellos alumnos que estén en
            //    estatus 2, ordenado por nombre del Estatus:
            //        a.idAlumnos,
            //        b.nombreAlumno,
            //        c.nombre del Estatus en que se encuentran
            Console.WriteLine("\nConsulta 8");
            var consulta8 =
                from alu in alumnos
                join stat in status on alu.idEstatus equals stat.id
                where alu.idEstatus == 2
                select new { Nombre = alu.nombre, EstatusAlu = stat.nombre, Id = alu.id };
            foreach (var aluSelect in consulta8)
            {
                Console.WriteLine($"Id: {aluSelect.Id} Nombre: {aluSelect.Nombre} Estatus: {aluSelect.EstatusAlu}");
            }




            //9.Mostar en la consola los siguientes datos, de aquellos alumnos cuyo estatus
            //    sea mayor a 2, ordenado por nombre del estatus:
            //        a.idAlumnos,
            //        b.nombreAlumno,
            //        c.nombre del Estado al que pertenece
            //        d.nombre del Estatus en que se encuentran
            Console.WriteLine("\nConsulta 9");
            var consulta9 =
                from alu in alumnos
                join stat in status on alu.idEstatus equals stat.id
                join edo in estados on alu.idEstado equals edo.id
                where alu.idEstatus > 2
                select new { Nombre = alu.nombre, EstadoAlu = edo.nombre, EstatusAlu = stat.nombre, Id = alu.id };
            foreach (var aluSelect in consulta9)
            {
                Console.WriteLine($"Id: {aluSelect.Id} Nombre: {aluSelect.Nombre} Estado: {aluSelect.EstadoAlu} Estatus: {aluSelect.EstatusAlu}");
            }



            ////Console.WriteLine(alumno1);
            //Console.WriteLine(jsonAlu);

        }

        public static void Serializar()
        {
            string rutaAlu = @"C:\Users\DOTNET6\Documents\DESARROLLO .NET\2_INTRODUCCION C#\Alumnos.json";
            string rutaEstado = @"C:\Users\DOTNET6\Documents\DESARROLLO .NET\2_INTRODUCCION C#\Estados.json";
            string rutaStatus = @"C:\Users\DOTNET6\Documents\DESARROLLO .NET\2_INTRODUCCION C#\Estatus.json";

            StreamReader jsonAluStr = new StreamReader(rutaAlu);
            var jsonAlu = jsonAluStr.ReadToEnd();
            jsonAluStr.Close();
            alumnos = JsonConvert.DeserializeObject<List<Alumnos>>(jsonAlu);


            StreamReader jsonEdoStr = new StreamReader(rutaEstado);
            var jsonEdo = jsonEdoStr.ReadToEnd();
            jsonAluStr.Close();
            estados = JsonConvert.DeserializeObject<List<Estado>>(jsonEdo);


            StreamReader jsonEstStr = new StreamReader(rutaStatus);
            var jsonEst = jsonEstStr.ReadToEnd();
            jsonAluStr.Close();
            status = JsonConvert.DeserializeObject<List<Estatus>>(jsonEst);
             

        }
    }
}
