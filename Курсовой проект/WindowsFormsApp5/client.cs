namespace WindowsFormsApp5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.client")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            deal = new HashSet<deal>();
        }

        [Key]
        public int id_client { get; set; }

        [Required]
        public string surname { get; set; }

        [Required]
        public string name { get; set; }

        public string pathronymic { get; set; }

        [Required]
        [StringLength(11)]
        public string phone_number { get; set; }

        public string status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deal> deal { get; set; }
    }
}
