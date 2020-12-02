using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Gameplay
{
    public class BoardFightManager : IBoardFightManager
    {
        private readonly IHand hand;
        private readonly IAttackCard attackCard;
        private int currentTargetIndex = 0;
        private List<ICard> lastUpdatedHand;

        public BoardFightManager(IHand hand, IAttackCard attackCard)
        {
            this.hand = hand;
            this.attackCard = attackCard;
            lastUpdatedHand = hand.GetCards().ToList();
            this.hand.OnCardRemoved += CardRemoved;
        }

        private void CardRemoved(ICard card)
        {
            int removedCardIndex = lastUpdatedHand.FindIndex(c => card == c);
            if (currentTargetIndex > 0 && removedCardIndex - 1 <= currentTargetIndex)
            {
                currentTargetIndex--;
            }
        }

        public void ExecuteAttack()
        {
            lastUpdatedHand = hand.GetCards().ToList();
            if (hand.GetCards().Count > 0)
            {
                if (currentTargetIndex >= lastUpdatedHand.Count)
                {
                    currentTargetIndex = 0;
                }

                lastUpdatedHand[currentTargetIndex].TakeDamage(attackCard);
                attackCard.ChangeDamage();
                currentTargetIndex++;
            }
        }
    }
}