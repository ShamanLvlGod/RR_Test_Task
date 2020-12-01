using System.Collections;
using System.Collections.Generic;

public interface IHand
{
    void AddCard(ICard card);
    IReadOnlyList<ICard> GetCards();
}