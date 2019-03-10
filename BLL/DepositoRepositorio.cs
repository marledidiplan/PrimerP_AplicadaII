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
           
            RepositorioBase<CuentasBancarias> ct = new RepositorioBase<CuentasBancarias>();
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
               
                Depositos DepAnt = contexto.depositos.Find(deposi.DepositoId);
                var cuenta = contexto.cuentasBancarias.Find(deposi.CuentaId);
                var cuentaAnt = contexto.cuentasBancarias.Find(DepAnt.CuentaId);

                if (deposi.CuentaId != DepAnt.CuentaId)
                {
                    cuenta.Balance += deposi.Monto;
                    cuentaAnt.Balance -= DepAnt.Monto;
                    
                }
                 decimal desigualdad = deposi.Monto - DepAnt.Monto;
                 cuenta.Balance += desigualdad;

                contexto = new Contexto();
                contexto.Entry(deposi).State = EntityState.Modified;
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
                bancarias.Details.Count();

                foreach (var item in bancarias.Details)
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
