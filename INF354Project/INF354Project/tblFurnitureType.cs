namespace INF354Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFurnitureType")]
    public partial class tblFurnitureType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFurnitureType()
        {
            tblFurnitures = new HashSet<tblFurniture>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFurniture> tblFurnitures { get; set; }
    }
}
