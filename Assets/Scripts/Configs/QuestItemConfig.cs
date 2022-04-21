using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    [CreateAssetMenu(fileName = "QuestItemCfg", menuName = "Configs/ Quest Item Cfg", order = 1)]
    public class QuestItemConfig : ScriptableObject
    {
        public int questID;
        public List<int> questItemCollection;
    }
}