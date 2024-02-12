namespace server.Models;


public class PurchasedCardModel: Card
{
   public string DateOfPurchase { get; set; } = null!;
   
   public string TimeOfPurchase { get; set; } = null!;
   
   public decimal  PriceOfPurchase { get; set; }
}