using System.Collections;
using Interfaces;
using Utils;

namespace Gameplay
{
    public abstract class ResourceDownloader : IResourceDownloader
    {

        public virtual YieldTask GetLoadingTask()
        {
            YieldTask loadTask = new YieldTask(StartDownloadingTheResource());
            return loadTask;
        }

        protected abstract IEnumerator StartDownloadingTheResource();
    }
}