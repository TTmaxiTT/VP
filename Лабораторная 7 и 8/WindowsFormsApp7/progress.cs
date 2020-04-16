namespace WindowsFormsApp7
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.progress")]
    public partial class progress
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code_stud { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code_subject { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code_lector { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime date_exam { get; set; }

        public int? estimate { get; set; }

        public virtual lectors lectors { get; set; }

        public virtual students students { get; set; }

        public virtual subjects subjects { get; set; }
    }
}
