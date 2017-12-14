namespace Comp2084_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class game
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Game")]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Manufacturer")]
        public string company { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Rating")]
        public string rating { get; set; }

        public int console_id { get; set; }

        public virtual console console { get; set; }
    }
}
