namespace E_Commerce.Shared.DataTransferObjects.Basket;

public class CustomerBasketDTO
{
    public string Id { get; set; }
    public ICollection<BasketItemDTO> Items { get; set; }
}
