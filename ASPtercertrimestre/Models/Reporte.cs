using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ASPtercertrimestre.Models
{
    public class Reporte
    {
        [Required]
        [StringLength(10)]
        public String nombreProveedor { get; set; }

        [Required]
        public String direccionProveedor { get; set; }

        [Required]
        public String telefonoProveedor { get; set; }

        [Required]
        [StringLength(10)]
        public String nombreProducto { get; set; }

        [Required]
        public int precioProducto { get; set; }


    }
}