namespace JKENGINEPARTS.TICKETING.Models{

    public class TicketItem
    {
        public int ID { get; set; }
        public string RepuestoSolicitado {get; set;}
        public string DescripcionOfrecida { get; set; }
        public string Marca { get; set; }
        public decimal PrecioMayor {get; set;}
        public bool IsApproved { get; set; }
    }
}