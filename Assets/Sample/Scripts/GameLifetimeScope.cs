using Sample.ECS;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Sample
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private UnitConfig _unitConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<RootWorld>();
            builder.Register<IFactory<Vector3, GameObject>, UnitFactory>(Lifetime.Transient);
            builder.RegisterInstance(_unitConfig);
            builder.RegisterInstance(World.Default);
            RegisterSystems(builder);
        }

        private void RegisterSystems(IContainerBuilder builder)
        {
            builder.RegisterSystem<SpawnerSystem>();
            builder.RegisterCleanupSystem<DeadUnitsCleanupSystem>();
        }
    }
}