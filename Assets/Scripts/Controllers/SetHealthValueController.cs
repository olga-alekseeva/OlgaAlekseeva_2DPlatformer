using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer_2D
{
    public class SetHealthValueController
    {
        private UIView _healhView;
        private CharacterObjectConfig _charObjectConfig;
        private RestartGame _restartGame;
        private PlayerObjectView _playerObjectView;
        public float currentHealth;

        public SetHealthValueController (UIView healhView, CharacterObjectConfig charObjectConfig, 
            PlayerObjectView playerObjectView)
        {
            _healhView = healhView;
            _charObjectConfig = charObjectConfig;
            _restartGame = new RestartGame ();
            _playerObjectView = playerObjectView;
        }
      
        public void Update()
        {
            currentHealth = _charObjectConfig.health;
          
            if (_healhView._healthValueSlider.value <= 0)
            {
                _restartGame.RestartLevel();
            }
        }
        public void SetMaxHealth(CharacterObjectConfig characterObjectConfig)
        {
            _healhView._healthValueSlider.maxValue = characterObjectConfig.maxHealth;
            _healhView._healthValueSlider.value = currentHealth;

        }

        public void SetHealth( )
        {
            _healhView._healthValueSlider.value = currentHealth;
        }
        public void Damage(float damage)
        {
            _healhView._healthValueSlider.value -= damage;
        }
    }
}