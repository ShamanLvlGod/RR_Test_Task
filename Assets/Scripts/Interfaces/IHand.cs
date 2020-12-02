using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IHand
    {
        event Action<ICard> OnCardRemoved;
        event Action<ICard> OnCardDied;
        void AddCard(ICard card);
        void RemoveCard(ICard card);
        void KillCard(ICard card);
        IReadOnlyList<ICard> GetCards();
    }
}