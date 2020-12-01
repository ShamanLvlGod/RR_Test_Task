public class Player : IPlayer
{
    private readonly Hand playerHand;
    private readonly HandInstaller handInstaller;

    public Player(ICardGenerator cardGenerator)
    {
        playerHand = new Hand();
        handInstaller = new HandInstaller(playerHand, cardGenerator);
        handInstaller.InstallTheHand();
    }

    public IHand GetHand()
    {
        return playerHand;
    }
}

public interface IPlayer
{
    IHand GetHand();
}