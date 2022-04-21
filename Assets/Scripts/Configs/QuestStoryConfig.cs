using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    [CreateAssetMenu(fileName = "QuestStoryCfg", menuName = "Configs/ Quest Story Cfg", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType type;
    }
    public enum QuestStoryType
    {
        Common,
        Resettable
    }
}