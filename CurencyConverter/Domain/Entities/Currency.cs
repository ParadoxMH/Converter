
namespace ApplicationCore.Entities
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public decimal SaleRate { get; set; }
        public decimal PurchaseRate { get; set; }
        public string Abreviation { get; set; }

    }
}
