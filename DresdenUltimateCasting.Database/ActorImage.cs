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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        [Required]
        [ForeignKey("Actor")]
        public int ActorId { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public short DisplayOrder { get; set; }

        public virtual Actor Actor { get; set; }
    }
}
