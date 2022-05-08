using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_2D
{
    public class QuestStoryController : IQuestStory

    {
        private List<IQuest> _questCollection = new List<IQuest>();
        public bool IsDone => _questCollection.All(value => value.IsCompleted);

        public QuestStoryController(List<IQuest> questCollection)
        {
            _questCollection = questCollection;

        }

        public void Dispose()
        {
            
        }
    }
}