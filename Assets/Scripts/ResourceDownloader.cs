using System;
using System.Collections;
using UnityEngine;
using Utils;

public abstract class ResourceDownloader : IResourceDownloader
{

    public virtual YieldTask GetLoadingTask()
    {
        YieldTask loadTask = new YieldTask(StartDownloadingTheResource());
        return loadTask;
    }

    protected abstract IEnumerator StartDownloadingTheResource();
}