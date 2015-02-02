using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace app1.Models
{
    public class Purchase
    {
        [MaxLength(10)]
        [Required]
        [Display(Name = "ID")]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "Customer Name")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "Address")]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }
    }
}