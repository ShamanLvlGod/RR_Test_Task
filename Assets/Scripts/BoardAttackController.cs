using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAttackController : MonoBehaviour
{
    [SerializeField] private AttackView attackView;

    public void Init(IBoardFightManager boardFightManager, IAttackCard attackCard)
    {
        attackView.Init(boardFightManager, attackCard);
    }
}