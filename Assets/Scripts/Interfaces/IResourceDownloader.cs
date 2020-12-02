using Utils;

namespace Interfaces
{
    public interface IResourceDownloader
    {
        YieldTask GetLoadingTask();
    }
}