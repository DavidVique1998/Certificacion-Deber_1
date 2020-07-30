using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queris
{
    public class MatriculaBLL
    {
        public static void Create(matricula a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        materia mt = db.materias.Find(a.idmateria);
                        Config(a, mt);
                        db.matriculas.Add(a);
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

        private static void Config(matricula a, materia mt)
        {
            a.fecha = DateTime.Now;
            a.estado = "1"; //Creada
            if (a.tipo.Equals("P"))
            {
                a.costo = 0;
            }
            else if (a.tipo.Equals("S"))
            {
                a.costo = (decimal)(12.25 * mt.creditos);
            }
            else
            {
                a.costo = (decimal)(24.50 * mt.creditos);
            }
        }

        public static matricula Get(int? id)
        {
            Entities db = new Entities();
            return db.matriculas.Find(id);
        }

        public static void Update(matricula matricula)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        materia mt = db.materias.Find(matricula.idmateria);
                        Config(matricula, mt);
                        db.matriculas.Attach(matricula);
                        db.Entry(matricula).State = System.Data.Entity.EntityState.Modified;
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
                        matricula matricula = db.matriculas.Find(id);
                        db.Entry(matricula).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<matricula> List()
        {
            Entities db = new Entities();
            return db.matriculas.ToList();
        }
    }
}
