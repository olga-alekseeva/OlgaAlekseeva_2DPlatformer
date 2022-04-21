using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class CoinQuestModel : IQuestModel
    {
        private const string Tag = "Player";

        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(Tag);
    }
    }
}