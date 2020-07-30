using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queris
{
    public class MateriaBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(materia a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.materias.Add(a);
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

        public static materia Get(int? id)
        {
            Entities db = new Entities();
            return db.materias.Find(id);
        }

        public static void Update(materia materia)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.materias.Attach(materia);
                        db.Entry(materia).State = System.Data.Entity.EntityState.Modified;
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
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        materia materia = db.materias.Find(id);
                        db.Entry(materia).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<materia> List()
        {
            Entities db = new Entities();
            return db.materias.ToList();
        }

        public static List<materia> ListToNames()
        {
            Entities db = new Entities();
            List<materia> resultado = new List<materia>();
            db.materias.ToList().ForEach(x =>
                resultado.Add(
                    new materia
                    {
                        nombre = x.nrc + " " + x.nombre,
                        idmateria = x.idmateria
                    }));
            return resultado;
        }


    }
}
