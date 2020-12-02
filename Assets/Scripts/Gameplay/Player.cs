using Interfaces;

namespace Gameplay
{
    public class Player : IPlayer, IHandObserver
    {
        private readonly IHealthCalculator healthCalculator;
        private readonly Hand playerHand;
        private readonly HandInstaller handInstaller;

        public Player(ICardGenerator cardGenerator, IHealthCalculator healthCalculator)
        {
            this.healthCalculator = healthCalculator;
            playerHand = new Hand();
            handInstaller = new HandInstaller(playerHand, cardGenerator, this);
            handInstaller.InstallTheHand();
        }

        public IHand GetHand()
        {
            return playerHand;
        }

        public void ObserveHand(ICard card)
        {
            if (!healthCalculator.IsAlive(card))
            {
                playerHand.KillCard(card);
            }
        }
    }

    public interface IHandObserver
    {
        void ObserveHand(ICard card);
    }

    public interface IPlayer
    {
        IHand GetHand();
    }
}