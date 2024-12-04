using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Sample.ECS
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class SpawnerSystem : ISystem
    {
        private readonly IFactory<Vector3, GameObject> _factory;
        private Filter _filter;

        public World World { get; set; }

        public SpawnerSystem(IFactory<Vector3, GameObject> factory)
        {
            _factory = factory;
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<Spawner>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var spawner = ref entity.GetComponent<Spawner>();
                if (spawner.LastTimeSpawned + spawner.Delay < Time.time)
                {
                    spawner.LastTimeSpawned = Time.time;
                    _factory.Create(new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)));
                }
            }
        }

        public void Dispose()
        {
        }
    }
}