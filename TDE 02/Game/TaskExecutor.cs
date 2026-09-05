using TDE_CS.Core;
using TDE_CS.Game.Tasks;

namespace TDE_CS.Game
{
    internal class TaskExecutor
    {
        private BaseTask? _task;
        private List<BaseTask> _taskList = new List<BaseTask>();
        private List<String> _taskNames = new List<String>();
        public BaseObject _host;
        public bool Executing => _task != null;

        public TaskExecutor(BaseObject host)
        {
            _host = host;
        }
        public void AddToTaskList(BaseTask task)
        {
            _taskList.Add(task);
            SetTaskName(task.GetType().Name);
        }
        public List<BaseTask> GetTaskList => _taskList;
        public List<String> GetTaskNames => _taskNames;
        public void SetTaskName(string taskName)
        {
            switch (taskName)
            {
                case "WalkTask":
                    _taskNames.Add("Caminhar");
                    break;
                case "DestroyTask":
                    _taskNames.Add("Destruir");
                    break;
                default:
                    _taskNames.Add("Desconhecida");
                    break;
            }
        }
        public void Execute()
        {
            if (Executing || _taskList.Count == 0) return;
            _task = _taskList[0];
        }

        public void Update(float delta)
        {
            if (_taskList.Count != 0 && !_taskList[0].TryExecute(_host, delta)) { 
                _taskList.RemoveAt(0);
                _taskNames.RemoveAt(0);
                Execute();
            }
        }
    }
}
