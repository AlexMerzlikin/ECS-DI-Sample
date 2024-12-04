using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using VContainer.Unity;

namespace Sample
{
    public class RootWorld : IInitializable, IDisposable
    {
        private readonly IEnumerable<ICleanupSystem> _cleanUpSystems;
        private readonly IEnumerable<IFixedSystem> _fixedUpdateSystems;
        private readonly IEnumerable<ISystem> _updateSystems;
        private readonly World _world;

        public RootWorld(
            World world,
            IEnumerable<ISystem> updateSystems,
            IEnumerable<IFixedSystem> fixedUpdateSystems,
            IEnumerable<ICleanupSystem> cleanUpSystems)
        {
            _world = world;

            _updateSystems = updateSystems;
            _fixedUpdateSystems = fixedUpdateSystems;
            _cleanUpSystems = cleanUpSystems;
        }

        public void Initialize()
        {
            var defaultGroup = _world.CreateSystemsGroup();
            foreach (var updateSystem in _updateSystems)
            {
                defaultGroup.AddSystem(updateSystem);
            }

            foreach (var fixedUpdateSystem in _fixedUpdateSystems)
            {
                defaultGroup.AddSystem(fixedUpdateSystem);
            }

            foreach (var cleanUpSystem in _cleanUpSystems)
            {
                defaultGroup.AddSystem(cleanUpSystem);
            }

            _world.AddSystemsGroup(0, defaultGroup);
        }

        public void Dispose()
        {
            _world?.Dispose();
        }
    }
}