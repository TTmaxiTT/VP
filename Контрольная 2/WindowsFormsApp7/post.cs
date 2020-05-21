namespace WindowsFormsApp7
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.post")]
    public partial class post
    {
        [Key]
        public int id_post { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string donor { get; set; }

        [Required]
        public string recipient { get; set; }

        [Required]
        public string congratulation { get; set; }

        public int picture { get; set; }
    }
}
