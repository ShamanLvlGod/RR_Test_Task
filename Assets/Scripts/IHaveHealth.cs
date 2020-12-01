public interface IHaveHealth
{
    void TakeDamage(IHaveAttack attack);
    int Health { get; }
}