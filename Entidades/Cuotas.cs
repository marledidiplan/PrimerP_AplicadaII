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
    public class Cuotas
    {
        [Key]
        public int Id { get; set; }
        public int NCuota { get; set; }
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Bce { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual Prestamos Prestamo { get; set; }

        public Cuotas()
        {
            Id = 0;
            PrestamoId = 0;
            NCuota = 0;          
            Fecha = DateTime.Now;
            Interes = 0;
            Capital = 0;
            Bce = 0;
            Monto = 0;

        }

        public Cuotas(int id, int nCuota, int prestamoId, DateTime fecha, decimal interes, decimal capital, decimal bce,decimal monto)
        {
            this.Id = id;
            this.NCuota = nCuota;
            this.PrestamoId = prestamoId;
            this.Fecha = fecha;
            this.Interes = interes;
            this.Capital = capital;
            this.Bce = bce;
            this.Monto = monto;

        }
    }
}
