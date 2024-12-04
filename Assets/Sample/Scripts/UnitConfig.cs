using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(menuName = "Sample/UnitConfig")]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;

        public GameObject PlayerPrefab => _playerPrefab;
    }
}