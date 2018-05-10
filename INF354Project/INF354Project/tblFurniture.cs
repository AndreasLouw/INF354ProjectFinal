namespace INF354Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFurniture")]
    public partial class tblFurniture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFurniture()
        {
            tblClientFurnitures = new HashSet<tblClientFurniture>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int typeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClientFurniture> tblClientFurnitures { get; set; }

        public virtual tblFurnitureType tblFurnitureType { get; set; }
    }
}
