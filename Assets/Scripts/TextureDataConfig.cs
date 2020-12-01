using UnityEngine;

public class TextureDataConfig : ITextureDirectoryProvider
{
    public readonly string imageConfig = "https://picsum.photos/512/512";
    public readonly string textureDirectory = Application.persistentDataPath + "/TextureImages";
    public readonly int MAX_IMAGE_COUNT = 6;

    public string GetTextureDirectory()
    {
        return textureDirectory;
    }
}

public interface ITextureDirectoryProvider
{
    string GetTextureDirectory();
}

public class DummyConfigData
{
    public readonly TextureDataConfig textureDataConfig = new TextureDataConfig();
    public readonly ILoadCardValue dummyCardValueLoader = new DummyValueGenerator();
}