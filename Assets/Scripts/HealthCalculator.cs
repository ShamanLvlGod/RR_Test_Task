public class HealthCalculator : IHealthCalculator
{
    public int CalculateHealth(IHaveHealth health, IHaveAttack attack)
    {
        return health.Health - attack.Damage;
    }
}