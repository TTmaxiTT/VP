namespace WindowsFormsApp5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.deal")]
    public partial class deal
    {
        [Key]
        public int id_deal { get; set; }

        public int? id_client { get; set; }

        public int? id_user { get; set; }

        public int? id_realty { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_deal { get; set; }

        public int transaction { get; set; }

        public virtual client client { get; set; }

        public virtual realty realty { get; set; }

        public virtual users users { get; set; }
    }
}
