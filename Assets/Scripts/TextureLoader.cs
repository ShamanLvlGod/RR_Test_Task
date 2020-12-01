using UnityEngine;

public class TextureLoader : ITextureLoader
{
    private readonly ITextureDirectoryProvider directoryProvider;
    private readonly string name;

    public TextureLoader(ITextureDirectoryProvider directoryProvider, string name)
    {
        this.directoryProvider = directoryProvider;
        this.name = name;
    }

    public Texture2D LoadTexture()
    {
        byte[] bytes = System.IO.File.ReadAllBytes(
            TextureCacher.GenerateTexturePath(name, directoryProvider.GetTextureDirectory()));
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(bytes);
        return tex;
    }
}