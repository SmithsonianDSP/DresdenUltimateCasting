using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DresdenUltimateCasting.Database
{
    public class CharacterTag
    {
        public CharacterTag()
        {

        }

        [Required]
        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }


        public virtual Character Character { get; set; }


        [Required]
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }


        
        public virtual Tag Tag { get; set; }


    }
}
