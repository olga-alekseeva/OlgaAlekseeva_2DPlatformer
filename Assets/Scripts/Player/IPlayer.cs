namespace Platformer_2D
{
    public interface IPlayer
    {
        public IPlayerModel model { get; }
        public IPlayerView view { get; }
        public float health { get; set; }
        public float fireForce { get; set; }

    }
}