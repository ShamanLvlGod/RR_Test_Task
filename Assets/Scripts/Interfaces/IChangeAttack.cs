using Utils;

namespace Interfaces
{
    public interface IChangeAttack
    {
        void ChangeDamage();
    }

    public interface IAttackCard : IHaveAttack, IChangeAttack
    {
        ObservableData<int> AttackDamage { get; }
    }
}