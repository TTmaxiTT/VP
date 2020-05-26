namespace WindowsFormsApp5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.realty")]
    public partial class realty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public realty()
        {
            deal = new HashSet<deal>();
        }

        [Key]
        public int id_realty { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string city { get; set; }

        public int priсe { get; set; }

        public decimal area { get; set; }

        public string type { get; set; }

        public string status { get; set; }

        [Required]
        [StringLength(11)]
        public string phone_number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deal> deal { get; set; }
    }
}
