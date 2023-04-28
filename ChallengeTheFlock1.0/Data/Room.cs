using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeTheFlock1._0.Data
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRoom { get; set; }

        [Required]
        public int IdHotel { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int MaxGuests { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
