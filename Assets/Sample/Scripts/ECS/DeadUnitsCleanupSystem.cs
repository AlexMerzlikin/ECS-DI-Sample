using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Sample.ECS
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class DeadUnitsCleanupSystem : ICleanupSystem
    {
        private Filter _deadFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _deadFilter = World.Filter.With<IsDead>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _deadFilter)
            {
                Object.Destroy(entity.GetComponent<Unit>().Transform.gameObject);
                World.RemoveEntity(entity);
            }
        }

        public void Dispose()
        {
        }
    }
}