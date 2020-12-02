using System.Collections.Generic;
using Gameplay;
using Interfaces;
using UnityEngine;

namespace UI
{
    public class HandVisualiser : MonoBehaviour
    {
        [SerializeField] private CardView cardView;
        [SerializeField] private ArcLayoutHandler targetContainer;
        [SerializeField] private DropZone dropZone;

        private readonly Dictionary<ICard, CardView> views = new Dictionary<ICard, CardView>();

        public void Init(IHand hand, ITextureDirectoryProvider directoryProvider)
        {
            IReadOnlyList<ICard> list = hand.GetCards();
            hand.OnCardDied += OnCardDied;
            hand.OnCardRemoved += OnCardRemoved;
            for (int i = 0; i < list.Count; ++i)
            {
                ICard card = list[i];
                CardView currentCard = Instantiate(cardView, targetContainer.transform);
                currentCard.Init(card, new TextureLoader(directoryProvider, i.ToString()));
                views.Add(card, currentCard);
            }

            targetContainer.ApplyArcContainers();
        }

        private void OnCardRemoved(ICard card)
        {
            targetContainer.UpdateArc();
        }

        private void OnCardDied(ICard card)
        {
            Destroy(views[card].gameObject);
            views.Remove(card);
        }
    }
}