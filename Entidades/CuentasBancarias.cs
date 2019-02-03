using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class CuentasBancarias
    {
        [Key]
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public decimal Balance { get; set; }
        public virtual List<Depositos> Detalle { get; set; }

        public CuentasBancarias()
        {
            Balance = 0;
            this.Detalle = new List<Depositos>();
        }

        public void Agregar(int depositoId, int cuentaId, DateTime fecha, string concepto, decimal monto)
        {
            this.Detalle.Add(new Depositos(depositoId, cuentaId, fecha, concepto, monto ));
        }
        
    }
}
