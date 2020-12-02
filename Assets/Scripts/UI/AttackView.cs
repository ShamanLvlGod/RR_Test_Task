using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AttackView : MonoBehaviour
    {
        [SerializeField] private Button attackButton;
        [SerializeField] private TextMeshProUGUI damageAmount;

        public void Init(IBoardFightManager boardFightManager, IAttackCard attackCard)
        {
            attackCard.AttackDamage.Subscribe(data => damageAmount.text = data.ToString(), true);
            attackButton.onClick.AddListener(boardFightManager.ExecuteAttack);
        }
    }
}