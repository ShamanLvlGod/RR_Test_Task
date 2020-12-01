public class BoardFightManager : IBoardFightManager
{
    private readonly IHand hand;
    private readonly IAttackCard attackCard;
    private int currentTargetIndex = 0;

    public BoardFightManager(IHand hand, IAttackCard attackCard)
    {
        this.hand = hand;
        this.attackCard = attackCard;
    }

    public void ExecuteAttack()
    {
        hand.GetCards()[currentTargetIndex].TakeDamage(attackCard);
        attackCard.ChangeDamage();

        currentTargetIndex++;
        if (currentTargetIndex >= hand.GetCards().Count)
        {
            currentTargetIndex = 0;
        }
    }
}