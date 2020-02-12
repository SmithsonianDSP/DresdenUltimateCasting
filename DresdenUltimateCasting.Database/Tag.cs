namespace DresdenUltimateCasting.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tag()
        {
            //Characters = new HashSet<Character>();
            CharacterTags = new HashSet<CharacterTag>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }

        [Required]
        [StringLength(50)]
        public string TagName { get; set; }


        [StringLength(510)]
        public string TagDescription { get; set; }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Character> Characters { get; set; }

        public virtual ICollection<CharacterTag> CharacterTags { get; set; }

    }
}
