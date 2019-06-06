using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public interface IHello : Orleans.IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }

    public interface IEmployee : IGrainWithGuidKey
    {
        Task<int> GetLevel();
        Task Promote(int newLevel);

        Task<IManager> GetManager();
        Task SetManager(IManager manager);
    }

    public interface IManager : IGrainWithGuidKey
    {
        Task<IEmployee> AsEmployee();
        Task<List<IEmployee>> GetDirectReports();
        Task AddDirectReport(IEmployee employee);
    }

}

