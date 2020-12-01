using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVisualiser : MonoBehaviour
{
    [SerializeField] private CardView cardView;
    [SerializeField] private Transform targetContainer;

    public void Init(IHand hand, ITextureDirectoryProvider directoryProvider)
    {
        IReadOnlyList<ICard> list = hand.GetCards();
        for (int i = 0; i < list.Count; i++)
        {
            ICard card = list[i];
            CardView currentCard = Instantiate(cardView, targetContainer);
            currentCard.Init(card, new TextureLoader(directoryProvider, i.ToString()));
        }
    }
}