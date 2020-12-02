using Interfaces;
using UI;
using UnityEngine;

namespace Gameplay
{
    public class BoardActionsController : MonoBehaviour
    {
        [SerializeField] private AttackView attackView;
        [SerializeField] private DropZone dropZone;
        private ICardDropVerifier cardDropVerifier;
        private IBoardDropManager boardDropManager;
        public void Init(IBoardFightManager boardFightManager, IAttackCard attackCard, IBoardDropManager boardDropManager,
            ICardDropVerifier cardDropVerifier)
        {
            this.cardDropVerifier = cardDropVerifier;
            this.boardDropManager = boardDropManager;
            attackView.Init(boardFightManager, attackCard);
            dropZone.onDropped += OnDropped;
        }

        private void OnDropped(Transform obj)
        {
            if (cardDropVerifier.IsCardDropped(obj))
            {
                boardDropManager.OnCardDropped(cardDropVerifier.GetLastVerifiedCard());
            }
        }
    }
}