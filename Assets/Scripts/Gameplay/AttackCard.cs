using Interfaces;
using UnityEngine;
using Utils;

namespace Gameplay
{
    class AttackCard : IAttackCard
    {
        private const int MIN_DAMAGE_CONFIG = -2;
        private const int MAX_DAMAGE_CONFIG = 9;

        public int Damage => AttackDamage.Data;
        public ObservableData<int> AttackDamage { get; }


        public AttackCard()
        {
            AttackDamage = new ObservableData<int>();
            ChangeDamage();
        }

        public void ChangeDamage()
        {
            AttackDamage.Data = Random.Range(MIN_DAMAGE_CONFIG, MAX_DAMAGE_CONFIG + 1);
        }
    }
}