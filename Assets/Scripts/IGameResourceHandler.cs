using System;
using System.Collections;

public interface IGameResourceHandler
{
    event Action OnResourcesLoaded;
    IEnumerator LoadResourceUnit(string resourceName);
    void LoadAllResources();
}