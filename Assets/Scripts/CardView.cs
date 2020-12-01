using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class CardView : MonoBehaviour
{
    private ICard card;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private Image sprite;

    public void Init(ICard card, ITextureLoader textureLoader)
    {
        this.card = card;
        card.Title.Subscribe(data => titleText.text = data, true);
        card.Description.Subscribe(data => descriptionText.text = data, true);
        card.AttackValue.Subscribe(data => attackText.text = data.ToString(), true);
        card.HealthValue.Subscribe(data => healthText.text = data.ToString(), true);
        card.ManaValue.Subscribe(data => manaText.text = data.ToString(), true);
        Texture2D texture = textureLoader.LoadTexture();
        sprite.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}