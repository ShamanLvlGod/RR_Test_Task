using UnityEngine;

namespace Interfaces
{
    public interface ITextureAssetDownloader : IResourceDownloader
    {
        Texture2D Texture { get; }
    }
}