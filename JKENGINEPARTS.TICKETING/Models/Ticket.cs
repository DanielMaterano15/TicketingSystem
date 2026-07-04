using System;
using System.Collections.Generic;

namespace JKENGINEPARTS.TICKETING.Models
{
    public class Ticket
    {
        public Guid ID {get; set; } = Guid.NewGuid();
        public string TallerNombre { get; set; }
        public string VehiculoInfo { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Pendiente;
        public List<TicketItem> Items { get; set; } = new List<TicketItem>();
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}

