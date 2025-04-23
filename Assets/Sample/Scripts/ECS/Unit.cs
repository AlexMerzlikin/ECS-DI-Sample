using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Sample.ECS
{
    [Serializable]
    public struct Unit : IComponent
    {
        public Transform Transform;
    }
}