namespace Platformer_2D
{
    public interface IPlayerModel
    {
        public float health { get; }
        public float speed { get; }
        public float gravity { get; }

        public float fireForce { get; }
    }
    
}