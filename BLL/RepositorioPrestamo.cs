using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioPrestamo : RepositorioBase<Prestamos>
    {
        public override bool Guardar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            decimal total=0;
            try
            {
                foreach (var item in prestamo.Detalle)
                {
                    total = item.Capital += item.Interes;
                }
                contexto.cuentasBancarias.Find(prestamo.CuentaId).Balance += total;
                contexto.prestamos.Add(prestamo);

                if(contexto.SaveChanges()>0)
                         paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public override bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Ante = contexto.prestamos.Find(prestamo.CuentaId);
                foreach (var item in Ante.Detalle)
                {
                    if (!prestamo.Detalle.Exists(m => m.NCuota == item.NCuota))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in prestamo.Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public override Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos = new Prestamos();

            try
            {
                prestamos = contexto.prestamos.Find(id);
                prestamos.Detalle.Count();
            }
            catch
            {
                throw;
            }
            return prestamos;
            
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();
            Contexto contexto = new Contexto();
            try
            {
                prestamo = contexto.prestamos.Find(id);
                var Ante = contexto.prestamos.Find(prestamo.CuentaId);
                foreach (var item in Ante.Detalle)
                {
                    if (!prestamo.Detalle.Exists(m => m.NCuota == item.NCuota))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                    contexto.prestamos.Remove(prestamo);
                }
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                return paso;
               
              
            }
            catch (Exception)
            {
                throw;
            }
          
        }


    }
}
