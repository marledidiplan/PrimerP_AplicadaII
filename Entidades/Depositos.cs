using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Depositos
    {
        [Key]
        public int DepositoId { get; set; }
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("CuentaId")]
        public virtual CuentasBancarias CuentasB { get; set; }

        public Depositos()
        {
            DepositoId = 0;
            CuentaId = 0;
            Fecha = DateTime.Now;
            Concepto = string.Empty;
            Monto = 0;
        }
        public Depositos(int depositoId, int cuentaId, DateTime fecha, string concepto, decimal monto)
        {
            DepositoId = depositoId;
            CuentaId = cuentaId;
            Fecha = fecha;
            Concepto = concepto;
            Monto = monto;

        }
    }
}
