namespace OrdenCompraAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDEN_COMPRA
    {
        public DateTime? FECHA_REGISTRO { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid GUID { get; set; }

        [StringLength(50)]
        public string NOMBRE_VENDEDOR { get; set; }

        [StringLength(200)]
        public string DIRECCION_VENDEDOR { get; set; }

        [StringLength(30)]
        public string TELEFONO_VENDEDOR { get; set; }

        [StringLength(50)]
        public string NOMBRE_COMPRADOR { get; set; }

        [StringLength(200)]
        public string DIRECCION_COMPRADOR { get; set; }

        [StringLength(30)]
        public string TELEFONO_COMPRADOR { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string CIUDAD_ENTREGA { get; set; }

        public decimal? VALOR { get; set; }

        public decimal? VALOR_IVA { get; set; }

        [StringLength(50)]
        public string AUTORIZADO_POR { get; set; }

        public string OBSERVACIONES { get; set; }

        [StringLength(50)]
        public string PROCEDENCIA { get; set; }

        public int? ID_ORDEN { get; set; }
    }
}
