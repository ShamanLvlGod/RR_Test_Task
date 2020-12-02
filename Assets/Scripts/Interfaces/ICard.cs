using Utils;

namespace Interfaces
{
    public interface ICard : IHaveAttack, IHaveMana, IHaveHealth, IHaveInfo, IHaveResource
    {
        ObservableData<string> Title { get; }
        ObservableData<string> Description { get; }
        ObservableData<int> AttackValue { get; }
        ObservableData<int> HealthValue { get; }
        ObservableData<int> ManaValue { get; }
    }
}