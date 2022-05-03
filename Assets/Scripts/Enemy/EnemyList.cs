using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class EnemyList : IEnemyList
    {
        public List<IEnemy> enemies { get; }
        public IEnemy current { get;  set; }

        public EnemyList()
        {
            enemies = new List<IEnemy>();   
            current = null;
        }
        public void Remove(IEnemy enemy)
        {
            enemies.Remove(enemy);
            if(current == enemy) current = null;    
        }
    }
}