public class PickupVisitor : IPickupableVisitor
{
    private readonly Health _healthPlayer;
    private readonly Wallet _wallet;
    public PickupVisitor(Health healthPlayer, Wallet wallet)
    {
        _healthPlayer = healthPlayer;
        _wallet = wallet;
    }

    public void Visit(FirstAidKit firstAidKit)
    {
        if (_healthPlayer.MaxValue - _healthPlayer.Value > 0)
        {
            _healthPlayer.Restore(firstAidKit.Value);
            firstAidKit.Delete();
        }
    }

    public void Visit(Coin coin)
    {
        _wallet.AddCoins(coin.Value);
        coin.Delete();
    }
}