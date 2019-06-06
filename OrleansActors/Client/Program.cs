using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using System;
using System.Threading.Tasks;

namespace OrleansBasics
{
    public class Program
    {
        var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30000);
        GrainClient.Initialize(config);

var grainFactory = GrainClient.GrainFactory;
        var e0 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
        var e1 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
        var e2 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
        var e3 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());
        var e4 = grainFactory.GetGrain<IEmployee>(Guid.NewGuid());

        var m0 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
        var m1 = grainFactory.GetGrain<IManager>(Guid.NewGuid());
        var m0e = m0.AsEmployee().Result;
        var m1e = m1.AsEmployee().Result;

        m0e.Promote(10);
m1e.Promote(11);

m0.AddDirectReport(e0).Wait();
        m0.AddDirectReport(e1).Wait();
        m0.AddDirectReport(e2).Wait();

        m1.AddDirectReport(m0e).Wait();
        m1.AddDirectReport(e3).Wait();

        m1.AddDirectReport(e4).Wait();

        Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
Console.ReadLine();
    }
}