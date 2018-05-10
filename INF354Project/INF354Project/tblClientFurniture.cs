namespace INF354Project
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblClientFurniture")]
    public partial class tblClientFurniture
    {
        public int id { get; set; }

        public int clientId { get; set; }

        public int furnitureId { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public virtual tblClient tblClient { get; set; }

        public virtual tblFurniture tblFurniture { get; set; }
    }
}
