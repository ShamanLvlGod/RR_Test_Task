using System;
using System.Collections;
using Utils;

public class GameResourceHandler : IGameResourceHandler
{
    private readonly TextureDataConfig textureDataConfig;


    public event Action OnResourcesLoaded;

    public GameResourceHandler(TextureDataConfig textureDataConfig)
    {
        this.textureDataConfig = textureDataConfig;
    }

    public void LoadAllResources()
    {
        YieldTask loadTask = new YieldTask(LoadResources());
        loadTask.OnComplete += OnResourcesLoaded;
        loadTask.Start();
    }

    private IEnumerator LoadResources()
    {
        int i = 0;
        while (i < textureDataConfig.MAX_IMAGE_COUNT)
        {
            if (!System.IO.File.Exists(
                TextureCacher.GenerateTexturePath(i.ToString(), textureDataConfig.textureDirectory)))
            {
                yield return LoadResourceUnit(i.ToString());
            }

            i++;
        }
    }

    public IEnumerator LoadResourceUnit(string resourceName)
    {
        ITextureAssetDownloader textureAssetDownloader = new TextureAssetDownloader(textureDataConfig.imageConfig);

        yield return textureAssetDownloader.GetLoadingTask().Start();
        IResourceCacher textureCacher =
            new TextureCacher(textureAssetDownloader.Texture, resourceName, textureDataConfig.textureDirectory);
        textureCacher.CacheTheResource();
    }
}