using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class BulletEmitterController
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;
        private int _index;
        private float _timeTillNextBull;

        private float _delay = 1;
        private float _startSpeed = 15;

        public BulletEmitterController(List<LevelObjectView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach(LevelObjectView BulletView in bulletViews)
            {
                _bullets.Add(new BulletController(BulletView));
            }
        }

    public void Update()
        {
            if(_timeTillNextBull>0)
            {
                _bullets[_index].Active(false);
                _timeTillNextBull -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBull = _delay;
                _bullets[_index].Throw(_transform.position, -_transform.up * _startSpeed);
                _index++;

                if (_index >= _bullets.Count)
                {
                    _index = 0;
                }
            }
        }
    }
}