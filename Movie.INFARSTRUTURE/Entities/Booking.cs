using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfTicket { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymenntInfo { get; set; }
        public string TransactionID { get; set; }
        public int ToTalPrice { get; set; }
        public int ShowID { get; set; }
        public int SeatID { get; set; }
        public int FareID { get; set; }
        public string UserID { get; set; }
        public virtual Fare Fare { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
