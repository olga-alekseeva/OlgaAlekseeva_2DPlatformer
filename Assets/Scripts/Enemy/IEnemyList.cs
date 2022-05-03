using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public interface IEnemyList
    {
        public List<IEnemy> enemies { get; }
        public IEnemy current { get; set; }
        public void Remove(IEnemy enemy);
    }
}