using UnityEngine;

namespace Interfaces
{
    public interface ICardDropVerifier
    {
        bool IsCardDropped(Transform draggable);
        ICard GetLastVerifiedCard();
    }
}