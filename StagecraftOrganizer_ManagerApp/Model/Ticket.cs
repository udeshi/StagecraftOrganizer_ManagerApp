//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StagecraftOrganizer_ManagerApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int Id { get; set; }
        public int TicketNo { get; set; }
        public int TicketType_TicketTypeId { get; set; }
        public Nullable<int> Booking_BookingId { get; set; }
        public string ReservationStatus { get; set; }
    
        public virtual Booking Booking { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
