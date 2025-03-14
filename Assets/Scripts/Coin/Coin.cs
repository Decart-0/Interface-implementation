public class Coin : Loot<int>, IPickupable 
{
    public void Accept(IPickupableVisitor visitor)
    {
        visitor.Visit(this);
    }
}