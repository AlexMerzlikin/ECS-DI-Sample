using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Sample
{
    public class UnitFactory : IFactory<Vector3, GameObject>
    {
        private readonly IObjectResolver _objectResolver;
        private readonly UnitConfig _unitConfig;

        public UnitFactory(IObjectResolver objectResolver, UnitConfig unitConfig)
        {
            _objectResolver = objectResolver;
            _unitConfig = unitConfig;
        }

        public GameObject Create(Vector3 position) => _objectResolver.Instantiate(_unitConfig.PlayerPrefab, position, Quaternion.identity);
    }
}