using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platformer_2D
{
    public class CoinsController: IDisposable
    {
        private float _animationSpeed = 10f;
        private SpriteAnimatorController _spriteAnimator;
        private LevelObjectView _playerView;
        private  List<LevelObjectView> _coinViews;

        public CoinsController(LevelObjectView playerView, List<LevelObjectView> coinViews, SpriteAnimatorController spriteAnimator)
        {
            _playerView = playerView;
            _coinViews = coinViews;
            _spriteAnimator = spriteAnimator;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;
            foreach (LevelObjectView coin in coinViews)
            {
                _spriteAnimator.StartAnimation(coin._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            }
        }
        
            private void OnLevelObjectContact(LevelObjectView contactView)

        {
            if(_coinViews.Contains(contactView))
            {
                _spriteAnimator?.StopAnimation(contactView._spriteRenderer);
               GameObject.Destroy(contactView.gameObject);
                _coinViews.Remove(contactView);
            }

        }
        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    
    }
}