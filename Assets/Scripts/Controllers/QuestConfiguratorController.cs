using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

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

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactory = new Dictionary<QuestType, Func<IQuestModel>>(1);
        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactory = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>(2);    

        public void Init()
        {
            _singleQuestController = new QuestController(_singleQuestView, _model);
            _singleQuestController.Reset();

            _questStoryFactory.Add(QuestStoryType.Common, questColection=> new QuestStoryController(questColection));

            _questFactory.Add(QuestType.Coins, () => new CoinQuestModel());

            _questStories = new List<IQuestStory>();
            foreach (QuestStoryConfig questStCfg in _questStoryConfig)
            {
                _questStories.Add(CreateQuestStory(questStCfg));
            }

        }

        private IQuest CreateQuest(QuestConfig config)
        {
            int questID = config.id;
            QuestObjectView questView = _questObjects.FirstOrDefault(value => value.Id == config.id);

            if(questView == null)
            {
                Debug.Log("No Views");
                    return null;
            }

            if (_questFactory.TryGetValue(config.questType, out var factory))
            {
                IQuestModel questModel = factory.Invoke();
                return new QuestController(questView, questModel);
                
            }
            Debug.Log("No model");
            return null;
        }
        private IQuestStory CreateQuestStory(QuestStoryConfig cfg)
        {
            List<IQuest> quests = new List<IQuest>();
            foreach(QuestConfig questCfg in cfg.quests)
            {
                IQuest quest = CreateQuest(questCfg);
                if (quest == null) continue;

                quests.Add(quest);
                Debug.Log("QuestAdded");
            }

            return _questStoryFactory[cfg.type].Invoke(quests);
        }
    }
}