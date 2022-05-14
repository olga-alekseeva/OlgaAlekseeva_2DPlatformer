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
        public float currentHealth;

        public SetHealthValueController (UIView healhView, CharacterObjectConfig charObjectConfig)
        {
            _healhView = healhView;
            _charObjectConfig = charObjectConfig;
            _restartGame = new RestartGame ();
        }
      
        public void Update()
        {
            currentHealth = _charObjectConfig.health;
          if(Input.GetKeyDown (KeyCode.F))
            {
                Damage(5);
            }
           
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