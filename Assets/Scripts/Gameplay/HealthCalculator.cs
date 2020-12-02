using Interfaces;

namespace Gameplay
{
    public class HealthCalculator : IHealthCalculator
    {
        public int CalculateHealth(IHaveHealth health, IHaveAttack attack)
        {
            return health.Health - attack.Damage;
        }

        public bool IsAlive(IHaveHealth health)
        {
            return health.Health > 0;
        }
    }
}