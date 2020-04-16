namespace WindowsFormsApp6
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.s_students")]
    public partial class s_students
    {
        public int id { get; set; }

        [StringLength(30)]
        public string surname { get; set; }

        [StringLength(30)]
        public string name { get; set; }

        [StringLength(30)]
        public string middlename { get; set; }

        public int? id_group { get; set; }

        public virtual s_in_group s_in_group { get; set; }
    }
}
