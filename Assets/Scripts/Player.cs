using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class Player : ICharacterConfig
    {
      
        public float health { get; set; }

        public float speed { get; set; }

        public float maxHealth { get; set; }

        public float minHealth { get; set; }

        public float fireForce { get; set; }

        

        public float jumpSpeed { get; set; }

        public float movingTresh { get; set; }

        public float jumpTresh { get; set; }

    public Player(ICharacterConfig config)
    {
        this.health = config.health;
        this.speed = config.speed;  
        this.maxHealth = config.maxHealth;  
        this.minHealth = config.minHealth;
        this.fireForce = config.fireForce;
        
        this.jumpSpeed = config.jumpSpeed;
        this.movingTresh = config.movingTresh;
        this.jumpTresh = config.jumpTresh;
                
    }


    }
}