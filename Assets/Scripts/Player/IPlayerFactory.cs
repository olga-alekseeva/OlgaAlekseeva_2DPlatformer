using UnityEngine;

namespace Platformer_2D
{
    public interface IPlayerFactory
    {
        public IPlayer GetPlayer(Vector3 position, Quaternion rotation);
        public void Destroy(IPlayer playerTank);
    }
}