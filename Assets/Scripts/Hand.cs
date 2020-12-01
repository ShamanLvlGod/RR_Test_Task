using System.Collections.Generic;

public class Hand : IHand
{
    private readonly List<ICard> cards = new List<ICard>();

    public void AddCard(ICard card)
    {
        cards.Add(card);
    }

    public IReadOnlyList<ICard> GetCards()
    {
        return cards;
    }
}