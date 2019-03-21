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
            decimal total = 0;
            try
            {
                foreach (var item in prestamo.Detalle)
                {
                    total = item.Capital += item.Interes;
                }
                contexto.cuentasBancarias.Find(prestamo.CuentaId).Balance += total;
                contexto.prestamos.Add(prestamo);

                if (contexto.SaveChanges() > 0)
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
                //decimal monto = 0;
                //decimal anteMonto = 0;
                var Ante = contexto.cuotas.Where(m => m.PrestamoId == prestamo.PrestamoId).AsNoTracking().ToList();
                //foreach (var item in Ante)
                //{
                //    anteMonto += item.Monto;

                //}
                //contexto.cuentasBancarias.Find(prestamo.CuentaId).Balance -= anteMonto;
                //foreach (var item in prestamo.Detalle)
                //{
                //    monto += item.Monto;
                //}
                //contexto.cuentasBancarias.Find(prestamo.CuentaId).Balance += monto;

                foreach (var item in Ante)
                {
                    if (!prestamo.Detalle.Exists(m => m.Id.Equals(item.Id)))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }
                foreach (var item in prestamo.Detalle)
                {
                    contexto.Entry(item).State = item.Id == 0 ? EntityState.Added : EntityState.Modified;
                }
                contexto.Entry(prestamo).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public override Prestamos Buscar(int id)
        {
            Prestamos Cuotas = new Prestamos();
            try
            {
                Cuotas = _contexto.prestamos.Find(id);
                if (Cuotas != null)
                {
                    Cuotas.Detalle.Count();
                    foreach (var item in Cuotas.Detalle)
                    {
                        //int a = item.NumCuotas;
                        //int b = item.ID;
                        //DateTime c = item.Fecha;
                        //decimal d = item.Interes;
                        //decimal e = item.Capital;
                        //decimal f = item.BCE;
                    }
                }
                _contexto.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return Cuotas;
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
                    if (!prestamo.Detalle.Exists(m => m.Id == item.Id))
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
