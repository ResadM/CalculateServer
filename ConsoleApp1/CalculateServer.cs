using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CalculateServer
    {
        public (List<Server> requiredPhysicalServer, List<Server> requiredUpgradeServer) CalculateServerCapacity(List<Server> virtualMachines, Server PhsMachinse)
        {
            virtualMachines = virtualMachines.OrderByDescending(x => x.Cpu).ThenByDescending(x => x.Memory).ThenByDescending(x => x.Storage).ToList();

            List<Server> tempPhsicalMachines = new List<Server>();
            List<Server> tempVirtualMachines = new List<Server>();

            for (int i = 0; i < virtualMachines.Count; i++)
            {
                if (tempPhsicalMachines.Any())
                {
                    Server tempVirtual = virtualMachines[i];
                    foreach (var item in tempPhsicalMachines)
                    {
                        if (item.Cpu >= virtualMachines[i].Cpu && item.Memory >= virtualMachines[i].Memory && item.Storage >= virtualMachines[i].Storage)
                        {
                            item.Cpu = item.Cpu - virtualMachines[i].Cpu;
                            item.Memory = item.Memory - virtualMachines[i].Memory;
                            item.Storage = item.Storage - virtualMachines[i].Storage;
                            tempVirtual = null;
                            break;
                        }
                    }
                    if (tempVirtual != null)
                    {
                        if (PhsMachinse.Memory >= virtualMachines[i].Memory && PhsMachinse.Cpu >= virtualMachines[i].Cpu && PhsMachinse.Storage >= virtualMachines[i].Storage)
                        {
                            tempPhsicalMachines.Add(new Server() { Cpu = PhsMachinse.Cpu - virtualMachines[i].Cpu, Memory = PhsMachinse.Memory - virtualMachines[i].Memory, Storage = PhsMachinse.Storage - virtualMachines[i].Storage });
                        }
                        else
                        {
                            tempVirtualMachines.Add(virtualMachines[i]);
                        }
                    }
                }
                else
                {
                    if (PhsMachinse.Memory >= virtualMachines[i].Memory && PhsMachinse.Cpu >= virtualMachines[i].Cpu && PhsMachinse.Storage >= virtualMachines[i].Storage)
                    {
                        tempPhsicalMachines.Add(new Server() { Cpu = PhsMachinse.Cpu - virtualMachines[i].Cpu, Memory = PhsMachinse.Memory - virtualMachines[i].Memory, Storage = PhsMachinse.Storage - virtualMachines[i].Storage });
                    }
                    else
                    {
                        tempVirtualMachines.Add(virtualMachines[i]);
                    }
                }
            }
            return (tempPhsicalMachines, tempVirtualMachines);
        }
    }
}
