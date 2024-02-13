namespace RocketseatAuction.API.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Brand { get; set; }
        public int Condition { get; set; }
        public decimal BasePrice { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
    }
}
