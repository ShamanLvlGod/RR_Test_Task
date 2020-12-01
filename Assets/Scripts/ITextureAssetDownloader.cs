using UnityEngine;

public interface ITextureAssetDownloader : IResourceDownloader
{
    Texture2D Texture { get; }
}