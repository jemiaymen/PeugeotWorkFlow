
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeugeotWorkFlow.Models
{

    public class Fournisseur
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nom de fournisseur")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Nom_frn { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Adress_frn { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Mail")]
        public string Mail_frn { get; set; }

        [Required]
        [Display(Name = "Telephone")]
        [Phone]
        public string Tel_frn { get; set; }
        
    }

    public class Category
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Libeler Category")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Lbl { get; set; }

    }

    public class CategoryInFournisseur
    {
        [Key]
        [Column(Order = 0)]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [Key]
        [Column(Order = 1)]
        public int FournisseurID { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
    }
}