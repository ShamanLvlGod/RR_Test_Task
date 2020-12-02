using Interfaces;

namespace Gameplay
{
    public class BoardDropManager : IBoardDropManager
    {
        private readonly IHand hand;

        public BoardDropManager(IHand hand)
        {
            this.hand = hand;
        }

        public void OnCardDropped(ICard card)
        {
            hand.RemoveCard(card);
        }
    }
}