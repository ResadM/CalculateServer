using ConsoleApp1;

List<Server> dummyVirtual = new List<Server>();
dummyVirtual.Add(new Server() { Cpu = 2, Memory = 2, Storage = 80 });
dummyVirtual.Add(new Server() { Cpu = 2, Memory = 6, Storage = 80 });
dummyVirtual.Add(new Server() { Cpu = 2, Memory = 6, Storage = 80 });
dummyVirtual.Add(new Server() { Cpu = 4, Memory = 8, Storage = 80 });

Server dummyPhsServer = new Server() { Cpu = 8, Memory = 6, Storage = 160 };

CalculateServer calc = new CalculateServer();

var calcResult = calc.CalculateServerCapacity(dummyVirtual, dummyPhsServer);

if (calcResult.requiredPhysicalServer.Count > 0)
{
    Console.WriteLine($"User need {calcResult.requiredPhysicalServer.Count.ToString()} phsical servers.");
}
if (calcResult.requiredUpgradeServer.Count > 0)
{
    Console.WriteLine($"User need to upgrade {calcResult.requiredUpgradeServer.Count.ToString()} servers.");
}
