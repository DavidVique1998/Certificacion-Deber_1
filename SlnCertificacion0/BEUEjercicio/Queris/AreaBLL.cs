using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queris
{
    //BLL Business Logic Layer
    //Capa de Logia del negocio
    public class AreaBLL
    {
        public static void Create(area a)
        {
            using (Entities db= new Entities())
            {
                using (var transaction= db.Database.BeginTransaction())
                {
                    try
                    {
                        db.areas.Add(a);
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

        public static area Get(int? id)
        {
            Entities db = new Entities();
            return db.areas.Find(id);
        }

        public static void Update(area area)
        {
            using (Entities db=new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.areas.Attach(area);
                        db.Entry(area).State = System.Data.Entity.EntityState.Modified;
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
                        area area = db.areas.Find(id);
                        db.Entry(area).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<area> List()
        {
            Entities db = new Entities();
            return db.areas.ToList();
        }

        private static List<area> GetAreas(string criterio)
        {
            Entities db = new Entities();
            return db.areas.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
        }

        private static area GetArea(string cordinador)
        {
            Entities db = new Entities();
            return db.areas.FirstOrDefault(x => x.cordinador == cordinador);
        }
    }
}
