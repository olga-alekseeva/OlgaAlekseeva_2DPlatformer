using UnityEngine;

namespace Platformer_2D
{
    [CreateAssetMenu(fileName = "PlayerModelCfg", menuName = "Configs/ PlayerModel Cfg", order = 1)]
    public sealed class PlayerModel : ScriptableObject, IPlayerModel
    {
        [SerializeField, Range(0, 20)] private float _health;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _gravity;
        [SerializeField, Range(0, 10)] private float _fireForce;

        public float health { get => _health; }
        public float speed { get => _speed; }
        public float gravity { get => _gravity; }
        public float fireForce { get => _fireForce; }


    }
}