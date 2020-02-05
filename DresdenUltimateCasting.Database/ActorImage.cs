namespace DresdenUltimateCasting.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActorImage
    {
        [Key]
        public int ImageId { get; set; }

        public int ActorId { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
