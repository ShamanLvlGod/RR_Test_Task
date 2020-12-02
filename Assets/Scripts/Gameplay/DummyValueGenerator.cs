using Interfaces;
using UnityEngine;

namespace Gameplay
{
    public class DummyValueGenerator : ILoadCardValue
    {
        public int GetCardValue()
        {
            return Random.Range(2, 11);
        }
    }
}