using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class Employee : Grain, IEmployee
    {
        public Task<int> GetLevel()
        {
            return Task.FromResult(_level);
        }

        public Task Promote(int newLevel)
        {
            _level = newLevel;
            return TaskDone.Done;
        }

        public Task<IManager> GetManager()
        {
            return Task.FromResult(_manager);
        }

        public Task SetManager(IManager manager)
        {
            _manager = manager;
            return TaskDone.Done;
        }

        public Task Greeting(IEmployee from, string message)
        {
            Console.WriteLine("{0} said: {1}", from.GetPrimaryKey().ToString(), message);
            return TaskDone.Done;
        }

        Task Greeting(IEmployee from, string message);

        private int _level;
        private IManager _manager;
    }

    public class Manager : Grain, IManager
    {
        public override Task OnActivateAsync()
        {
            _me = this.GrainFactory.GetGrain<IEmployee>(this.GetPrimaryKey());
            return base.OnActivateAsync();
        }

        public Task<List<IEmployee>> GetDirectReports()
        {
            return Task.FromResult(_reports);
        }

        public Task AddDirectReport(IEmployee employee)
        {
            _reports.Add(employee);
            employee.SetManager(this);
            return TaskDone.Done;
        }

        public Task<IEmployee> AsEmployee()
        {
            return Task.FromResult(_me);
        }

        public async Task AddDirectReport(IEmployee employee)
        {
            _reports.Add(employee);
            await employee.SetManager(this);
            await employee.Greeting(_me, "Welcome to my team!");
        }

        private IEmployee _me;
        private List<IEmployee> _reports = new List<IEmployee>();
    }
}