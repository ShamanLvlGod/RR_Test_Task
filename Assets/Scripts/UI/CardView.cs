using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CardView : MonoBehaviour
    {
        public ICard Card { get; private set; }
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private TextMeshProUGUI attackText;
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI manaText;
        [SerializeField] private Image sprite;
        [SerializeField] private Transform outline;
        [SerializeField] private Draggable draggable;

        public void Init(ICard card, ITextureLoader textureLoader)
        {
            Card = card;
            card.Title.Subscribe(data => titleText.text = data, true);
            card.Description.Subscribe(data => descriptionText.text = data, true);
            card.AttackValue.Subscribe(data => attackText.text = data.ToString(), true);
            card.HealthValue.Subscribe(data => healthText.text = data.ToString(), true);
            card.ManaValue.Subscribe(data => manaText.text = data.ToString(), true);
            Texture2D texture = textureLoader.LoadTexture();
            sprite.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));

            CardViewShineApplier();
        }

        private void CardViewShineApplier()
        {
            draggable.onDragged += () => { outline.gameObject.SetActive(true); };
            draggable.onDropped += () => { outline.gameObject.SetActive(false); };
        }
    }
}