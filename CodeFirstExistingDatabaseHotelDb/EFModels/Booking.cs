using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstExistingDatabaseHotelDb.EFModels
{
    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int HotelNo { get; set; }

        public int GuestNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTo { get; set; }

        public int RoomNo { get; set; }

        public virtual Room Room { get; set; }

        public virtual Guest Guest { get; set; }
        public override string ToString()
        {
            return $"BookingId: {BookingId}, DateTo : {DateTo} , DateFrom: {DateFrom}";
        }
    }
}
