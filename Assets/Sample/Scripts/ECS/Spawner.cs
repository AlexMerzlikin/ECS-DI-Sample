using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Sample.ECS
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Spawner : IComponent
    {
        public float Delay;
        public float LastTimeSpawned;
    }
}