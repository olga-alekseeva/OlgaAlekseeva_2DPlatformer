using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class BulletController
    {
        private Vector3 _velocity;
        private LevelObjectView _view;
        private SetVelocity _setVelocity;

        public BulletController(LevelObjectView view)
        {
            _view = view;
            Active(false);
        }
        public void Active(bool val)
        {
            _view.gameObject.SetActive(val);
        }
        
        public void Throw(Vector3 position,Vector3 velocity)
        {
            Active(true);
            _velocity = velocity;
            SetVelocity setVelocity = new SetVelocity(velocity, _view._transform);
            _view._transform.position = position;
            _view._rb.velocity = Vector2.zero;
            _view._rb.angularVelocity = 0;

            _view._rb.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}