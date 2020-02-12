namespace DresdenUltimateCasting.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Character
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Character()
        {
            Actors = new HashSet<Actor>();
            //Tags = new HashSet<Tag>();
            CharacterTags = new HashSet<CharacterTag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterId { get; set; }

        [ForeignKey("Faction")]
        public int FactionId { get; set; }

        [Required]
        [StringLength(120)]
        public string CharacterName { get; set; }

        [StringLength(765)]
        public string CharacterDescription { get; set; }
        
        [StringLength(510)]
        public string CharacterNotes { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actor> Actors { get; set; }

        public virtual Faction Faction { get; set; }

        //[NotMapped]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Tag> Tags { get; set; }



        public virtual ICollection<CharacterTag> CharacterTags { get; set; }

    }
}
