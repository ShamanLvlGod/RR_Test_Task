using System;
using System.Collections;

namespace Interfaces
{
    public interface IGameResourceHandler
    {
        event Action OnResourcesLoaded;
        IEnumerator LoadResourceUnit(string resourceName);
        void LoadAllResources();
    }
}