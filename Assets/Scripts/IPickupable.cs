public interface IPickupable 
{
    public void Accept(IPickupableVisitor visitor);
}