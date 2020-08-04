using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queris
{
    public class TipoBecaBLL
    {
        public static void Create(tipoBeca tb)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tipoBecas.Add(tb);
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

        public static tipoBeca Get(int? id)
        {
            Entities db = new Entities();
            return db.tipoBecas.Find(id);
        }

        public static void Update(tipoBeca tipoBeca)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tipoBecas.Attach(tipoBeca);
                        db.Entry(tipoBeca).State = System.Data.Entity.EntityState.Modified;
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
        public static bool Updates(tipoBeca p)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tipoBeca prm = new tipoBeca();
                        var order = db.tipoBecas.AsNoTracking().Where(s => s.idTipoBecas == p.idTipoBecas).FirstOrDefault();
                        prm.idTipoBecas = order.idTipoBecas;
                        prm.nombre = p.nombre;
                        prm.porcentaje_matricula = p.porcentaje_matricula;
                        prm.requisitos_especificos = p.requisitos_especificos;
                        prm.tipo_calificacion_necesaria = p.tipo_calificacion_necesaria;
                        prm.documentos_respaldo = p.documentos_respaldo;
                        db.Entry(prm).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
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
                        tipoBeca tipoBeca = db.tipoBecas.Find(id);
                        db.Entry(tipoBeca).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<tipoBeca> List()
        {
            Entities db = new Entities();
            return db.tipoBecas.ToList();
        }

        public static List<tipoBeca> ListToNames()
        {
            Entities db = new Entities();
            List<tipoBeca> resultado = new List<tipoBeca>();
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
