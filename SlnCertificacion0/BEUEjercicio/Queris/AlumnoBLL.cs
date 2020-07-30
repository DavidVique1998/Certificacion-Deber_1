using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queris
{
    //BLL Business Logic Layer
    //Capa de Logica del Negocio
    public class AlumnoBLL
    {
        public static void Create(alumno a)
        {   //Se crea una instancia de la Entidad Base de datos
            using (Entities db=new Entities())
            {
                //Se crea una instancia de la transaccion
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.alumnoes.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static alumno Get(int? id)
        {
            Entities db = new Entities();
            return db.alumnoes.Find(id);
        }

        public static void Update (alumno alumno)
        {
            using (Entities db=new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.alumnoes.Attach(alumno);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db=new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        alumno alumno = db.alumnoes.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<alumno> List()
        {
            Entities db = new Entities();
            return db.alumnoes.ToList();
        }

        private static List<alumno> GetAlumnos(string criterio)
        {
            Entities db = new Entities();
            return db.alumnoes.Where(x => x.apellidos.ToLower().Contains(criterio)).ToList();
        }

        private static alumno GetAlumno(string cedula)
        {
            Entities db = new Entities();
            return db.alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }


        //Nombre completos fucionados
        public static List<alumno> ListToNames()
        {
            Entities db = new Entities();
            List<alumno> result = new List<alumno>();
            db.alumnoes.ToList().ForEach(x =>
                result.Add(
                    new alumno
                    {
                        nombres = x.nombres + " " + x.apellidos,
                        idalumno = x.idalumno
                    }));
            return result;
        }

        private static List<alumno> Getalumnos(string criterio)
        {
            //Ejemplo: criterio = 'quin'
            //Posibles resultados => Quintana, Quintero, Pulloquinga, Quingaluisa...
            Entities db = new Entities();
            return db.alumnoes.Where(x => x.apellidos.ToLower().Contains(criterio)).ToList();
        }

        private static alumno Getalumno(string cedula)
        {
            Entities db = new Entities();
            return db.alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }

    }
}
