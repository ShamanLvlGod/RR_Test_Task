using System;
using Interfaces;
using Utils;

namespace Gameplay
{
    [Serializable]
    public class Card : ICard
    {
        private IHealthCalculator healthCalculator;
        public ObservableData<string> Title { get; }
        public ObservableData<string> Description { get; }
        public ObservableData<int> AttackValue { get; }
        public ObservableData<int> HealthValue { get; }
        public ObservableData<int> ManaValue { get; }
        private string texturePath;

        public Card(IHealthCalculator healthCalculator, string title, string description, string texturePath,
            int attackValue, int healthValue,
            int manaValue)
        {
            Title = new ObservableData<string>();
            Description = new ObservableData<string>();
            AttackValue = new ObservableData<int>();
            HealthValue = new ObservableData<int>();
            ManaValue = new ObservableData<int>();

            this.healthCalculator = healthCalculator;
            Title.Data = title;
            Description.Data = description;
            AttackValue.Data = attackValue;
            HealthValue.Data = healthValue;
            ManaValue.Data = manaValue;
            this.texturePath = texturePath;
        }


        public void TakeDamage(IHaveAttack attack)
        {
            HealthValue.Data = healthCalculator.CalculateHealth(this, attack);
        }


        public int Health => HealthValue.Data;
        public int Damage => AttackValue.Data;

        public int Mana => ManaValue.Data;

        public string GetTitle()
        {
            return Title.Data;
        }

        public string GetDescription()
        {
            return Description.Data;
        }

        public string GetResourcePath()
        {
            return texturePath;
        }
    }
}