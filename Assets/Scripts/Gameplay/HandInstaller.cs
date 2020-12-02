using Interfaces;
using UnityEngine;

namespace Gameplay
{
    public class HandInstaller : IHandInstaller
    {
        private readonly IHand hand;
        private readonly ICardGenerator cardGenerator;
        private readonly IHandObserver handObserver;

        public HandInstaller(IHand hand, ICardGenerator cardGenerator, IHandObserver handObserver)
        {
            this.hand = hand;
            this.cardGenerator = cardGenerator;
            this.handObserver = handObserver;
        }

        public void InstallTheHand()
        {
            const int minCardsAmountInTheHand = 4;
            const int maxCardsAmountInTheHand = 6;
            for (int i = 0; i < Random.Range(minCardsAmountInTheHand, maxCardsAmountInTheHand + 1); ++i)
            {
                ICard card = cardGenerator.GenerateCard();
                card.HealthValue.Subscribe(data => handObserver.ObserveHand(card), true);
                hand.AddCard(card);
            }
        }
    }
}