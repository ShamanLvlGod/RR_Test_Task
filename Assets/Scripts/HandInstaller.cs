using UnityEngine;

public class HandInstaller : IHandInstaller
{
    private IHand hand;
    private ICardGenerator cardGenerator;

    public HandInstaller(IHand hand, ICardGenerator cardGenerator)
    {
        this.hand = hand;
        this.cardGenerator = cardGenerator;
    }

    public void InstallTheHand()
    {
        const int minCarsAmountInTheHand = 4;
        const int maxCarsAmountInTheHand = 6;
        for (int i = 0; i < Random.Range(minCarsAmountInTheHand, maxCarsAmountInTheHand); i++)
        {
            hand.AddCard(cardGenerator.GenerateCard());
        }
    }
}