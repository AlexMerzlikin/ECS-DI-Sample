using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Sample.ECS
{
    [Serializable]
    public struct Spawner : IComponent
    {
        public float Delay;
        public float LastTimeSpawned;
    }
}