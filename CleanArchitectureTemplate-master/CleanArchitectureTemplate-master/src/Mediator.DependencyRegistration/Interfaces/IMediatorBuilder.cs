

namespace Mediator.DependencyRegistration.Interfaces
{
    public interface IMediatorBuilder
    {
        // Here you can define what types of behaviors you will implement for cross-cutting concerns 
        // They act as filters

        IMediatorBuilder WithPersistableBehavior();
    }
}
