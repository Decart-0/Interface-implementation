public class FirstAidKit : Loot<float>, IPickupable 
{
    public void Accept(IPickupableVisitor visitor)
    {
        visitor.Visit(this);
    }
}