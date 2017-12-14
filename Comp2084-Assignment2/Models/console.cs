namespace Comp2084_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class console
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public console()
        {
            games = new HashSet<game>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Console")]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Company")]
        public string company { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Company Website")]
        public string bio_link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game> games { get; set; }
    }
}
