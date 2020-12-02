namespace Interfaces
{
    public interface IHealthCalculator
    {
        int CalculateHealth(IHaveHealth health, IHaveAttack attack);
        bool IsAlive(IHaveHealth health);
    }
}