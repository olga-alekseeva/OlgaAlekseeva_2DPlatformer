using UnityEngine;

namespace Platformer_2D
{
    public sealed class PlayerSpawner : IPlayerSpawn
    {
        private IPlayerFactory _playerFactory;
        private ISpawnPosition _spawnPosition;
        public PlayerSpawner(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _spawnPosition = new SpawnPosition();
        }

        public IPlayer Spawn()
        {
            Vector2 position = _spawnPosition.GetSpawnPosition();
            if (position == Vector2.zero) return null;

            IPlayer player = _playerFactory.GetPlayer(position, Quaternion.identity);
            player.view.transform.position = position;

            return player;
        }
    }
}