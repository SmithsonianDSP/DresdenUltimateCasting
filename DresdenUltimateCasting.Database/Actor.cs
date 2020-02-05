namespace DresdenUltimateCasting.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Actor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actor()
        {
            ActorImages = new HashSet<ActorImage>();
        }

        public int ActorId { get; set; }

        public int CharacterId { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [StringLength(255)]
        public string AlsoKnownFor { get; set; }

        [StringLength(510)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActorImage> ActorImages { get; set; }

        public virtual Character Character { get; set; }
    }
}
