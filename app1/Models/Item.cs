using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace app1.Models
{
    public class Item
    {
        [MaxLength(10)]
        [Required]
        [Display(Name = "ID")]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        [Display(Name = "Name")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        

    }
}