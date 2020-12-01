using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TextureAssetDownloader : ResourceDownloader, ITextureAssetDownloader
{
    private readonly string mediaURL;
    private Texture2D texture;

    public Texture2D Texture => texture;

    public TextureAssetDownloader(string mediaURL)
    {
        this.mediaURL = mediaURL;
    }

    protected override IEnumerator StartDownloadingTheResource()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaURL);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
        }
    }
}