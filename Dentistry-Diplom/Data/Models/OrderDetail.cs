namespace Dentistry_Diplom.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int gameId { get; set; }
        public short price { get; set; }
        public virtual DentistryInfo dentistry { get; set; }
        public virtual Order order { get; set; }
    }
}