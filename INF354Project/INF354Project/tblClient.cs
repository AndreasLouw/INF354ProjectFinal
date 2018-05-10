namespace INF354Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblClient")]
    public partial class tblClient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClient()
        {
            tblClientFurnitures = new HashSet<tblClientFurniture>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        public int titleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClientFurniture> tblClientFurnitures { get; set; }

        public virtual tblTitle tblTitle { get; set; }
    }
}
