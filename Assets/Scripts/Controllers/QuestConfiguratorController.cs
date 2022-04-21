using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Platformer_2D
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestController _singleQuestController;
        private CoinQuestModel _model;

        private QuestStoryConfig[] _questStoryConfig;
        private QuestObjectView[] _questObjects;

        private List<IQuestStory> _questStories;

        public QuestConfiguratorController(QuestView view)
        {
            _singleQuestView = view._singleQuest;
            _model = new CoinQuestModel();

            _questStoryConfig = view._questStoryConfig;
            _questObjects = view._questObjects;

        }
            public void Init()
        {
            _singleQuestController = new QuestController(_singleQuestView, _model);
            _singleQuestController.Reset();

        }
    }
}