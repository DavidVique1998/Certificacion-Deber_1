using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queris
{
    public class MaquinariaBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(maquinaria a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.maquinarias.Add(a);
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

        public static maquinaria Get(int? id)
        {
            Entities db = new Entities();
            return db.maquinarias.Find(id);
        }

        public static void Update(maquinaria Maquinaria)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.maquinarias.Attach(Maquinaria);
                        db.Entry(Maquinaria).State = System.Data.Entity.EntityState.Modified;
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
                        maquinaria Maquinaria = db.maquinarias.Find(id);
                        db.Entry(Maquinaria).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<maquinaria> List()
        {
            Entities db = new Entities();
            return db.maquinarias.ToList();
        }

        public static List<maquinaria> ListToNames()
        {
            Entities db = new Entities();
            List<maquinaria> resultado = new List<maquinaria>();
            //db.maquinarias.ToList().ForEach(x =>
            //    resultado.Add(
            //        new maquinaria
            //        {
            //            nombre = x.nrc + " " + x.nombre,
            //            idMaquinaria = x.idMaquinaria
            //        }));
            return resultado;
        }


    }
}
