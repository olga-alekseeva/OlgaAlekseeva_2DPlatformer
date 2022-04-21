using System;

namespace Platformer_2D
{
    public class QuestController : IQuest
    {
        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; private set; }

        private QuestObjectView _questObjectView;
        private bool _active;
        private IQuestModel _model;


        public QuestController(QuestObjectView view, IQuestModel model)
        {
            _questObjectView = view;
            _model = model;
        }

        private void OnContact(LevelObjectView arg)
        {
            bool complete = _model.TryComplete(arg.gameObject);
            if (complete)
            {
                Complete();
            }
        }
        public void Complete()
        {
            if(!_active)
            {
                return;
            }
            _active = false;
            _questObjectView.OnLevelObjectContact -= OnContact;
            _questObjectView.ProcessComplete();
            Completed?.Invoke(this, this);
        }
        public void Reset()
        {
            if (_active)
            {
                return;
            }
            _active = true;
            _questObjectView.OnLevelObjectContact += OnContact;
            _questObjectView.ProcessActivate();
            
        }
        public void Dispose()
        {
            _questObjectView.OnLevelObjectContact -= OnContact;
        }

        
    }
}
