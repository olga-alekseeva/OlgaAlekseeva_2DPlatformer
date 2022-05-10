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
        public float currentHealth;

        public SetHealthValueController (UIView healhView, CharacterObjectConfig charObjectConfig)
        {
            _healhView = healhView;
            _charObjectConfig = charObjectConfig;
            currentHealth = _charObjectConfig.maxHealth;
        }
      
        public void Update()
        {
          
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Damage(5);
            }
            if (_healhView._healthValueSlider.value <= 0)
            {
                Debug.Log("You died");
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
        void Damage(float damage)
        {
            _healhView._healthValueSlider.value -= damage;
        }
    }
}