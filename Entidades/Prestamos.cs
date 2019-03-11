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
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public decimal Capital { get; set; }
        public decimal InteresAnual { get; set; }
        public int TiempoMeses { get; set; }
        public int MontoPrestamo { get; set; }

        [ForeignKey("CuentaId")]
        public virtual CuentasBancarias CuentasBancarias { get; set; }

        public virtual List<Cuotas> Detalle { get; set; }

        public Prestamos()
        {
            PrestamoId = 0;
            Fecha = DateTime.Now;
            CuentaId = 0;
            Capital = 0;
            InteresAnual = 0;
            TiempoMeses = 0;
            MontoPrestamo = 0;
            this.Detalle = new List<Cuotas>();

        }

        public void AgregarDetalle(int id, int nCuota, int prestamoId, DateTime fecha, decimal interes, decimal capital, decimal bce, decimal monto)
        {
            this.Detalle.Add(new Cuotas(id, nCuota, prestamoId, fecha, interes, capital, bce, monto));
        }

    }
}
