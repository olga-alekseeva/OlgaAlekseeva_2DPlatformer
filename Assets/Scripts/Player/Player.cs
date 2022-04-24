using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class Player : IPlayer
    {
        public IPlayerModel model { get; }
        public IPlayerView view { get; }
        public float health { get; set; }
        public float fireForce { get; set; }

        public Player (IPlayerModel model, IPlayerView view)
        {
            this.model = model; 
            this.view = view;
            health = model.health;
            fireForce = model.fireForce;
        }
    }
}