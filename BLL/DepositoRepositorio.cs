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
   public class DepositoRepositorio : RepositorioBase<Depositos>
    {
        public override bool Guardar(Depositos deposi)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.depositos.Add(deposi);
                contexto.cuentasBancarias.Find(deposi.CuentaId).Balance += deposi.Monto;
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Modificar(Depositos deposi)
        {
            CuentasBancarias bancarias = new CuentasBancarias();
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(bancarias).State = EntityState.Modified;

                Depositos dep = contexto.depositos.Find(deposi.DepositoId);
                var cuenta = contexto.cuentasBancarias.Find(deposi.CuentaId);
                var cuentaAnt = contexto.cuentasBancarias.Find(dep.CuentaId);

                if (deposi.CuentaId != dep.CuentaId)
                {
                    cuenta.Balance += deposi.Monto;
                    cuentaAnt.Balance -= dep.Monto;
                }
                else
                {
                    decimal diferencia = deposi.Monto - dep.Monto;
                    cuenta.Balance += diferencia;
                }
                contexto.SaveChanges();
                paso = true;
            }
      
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public override Depositos Buscar(int id)
        {
            CuentasBancarias bancarias = new CuentasBancarias();
            Depositos deposi = new Depositos();
            
            try
            {
                bancarias = _contexto.cuentasBancarias.Find(id);
                bancarias.Detalle.Count();

                foreach (var item in bancarias.Detalle)
                {
                    string s = item.CuentasB.Nombre;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return deposi;
        }
        public override bool Eliminar(int id)
        {
            CuentasBancarias bancarias = new CuentasBancarias();
            //Depositos deposi = new Depositos();

            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {

                Depositos dep = contexto.depositos.Find(id);
                contexto.cuentasBancarias.Find(dep.CuentaId).Balance -= dep.Monto;
                contexto.depositos.Remove(dep);
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


    }
}
