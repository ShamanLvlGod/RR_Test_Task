using Interfaces;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class CardDropVerifier : ICardDropVerifier
    {
        private CardView card = null;

        public bool IsCardDropped(Transform draggable)
        {
            card = draggable.GetComponent<CardView>();
            return card;
        }

        public ICard GetLastVerifiedCard()
        {
            return card.Card;
        }
    }
}