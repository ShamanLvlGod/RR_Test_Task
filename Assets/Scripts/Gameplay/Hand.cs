using System;
using System.Collections.Generic;
using Interfaces;

namespace Gameplay
{
    public class Hand : IHand
    {
        private readonly List<ICard> cards = new List<ICard>();

        public event Action<ICard> OnCardRemoved;
        public event Action<ICard> OnCardDied;

        public void AddCard(ICard card)
        {
            cards.Add(card);
        }

        public void RemoveCard(ICard card)
        {
            cards.Remove(card);
            OnCardRemoved?.Invoke(card);
        }

        public void KillCard(ICard card)
        {
            RemoveCard(card);
            OnCardDied?.Invoke(card);
        }

        public IReadOnlyList<ICard> GetCards()
        {
            return cards;
        }
    }
}