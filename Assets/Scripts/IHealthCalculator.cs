public interface IHealthCalculator
{
    int CalculateHealth(IHaveHealth health, IHaveAttack attack);
}