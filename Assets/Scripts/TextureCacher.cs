using System.IO;
using UnityEngine;

public class TextureCacher : ResourceCacher, ITextureCacher
{
    private const string FILE_EXTENSION = ".jpeg";
    private readonly Texture2D texture;
    private readonly string name;
    private readonly string dirPath;

    public TextureCacher(Texture2D texture, string name, string dirPath)
    {
        this.texture = texture;
        this.name = name;
        this.dirPath = dirPath;
    }

    public override void CacheTheResource()
    {
        CacheTheTexture();
    }

    private void CacheTheTexture()
    {
        byte[] bytes = texture.EncodeToJPG();
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        File.WriteAllBytes(GenerateTexturePath(name, dirPath), bytes);
        Debug.Log(bytes.Length / 1024 + "Kb was saved as: " + dirPath);
    }

    public static string GenerateTexturePath(string name, string dirPath)
    {
        return dirPath + "/" + name + FILE_EXTENSION;
    }
}