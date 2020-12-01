using UnityEngine;

public class DummyValueGenerator : ILoadCardValue
{
    public int GetCardValue()
    {
        return Random.Range(2, 11);
    }
}