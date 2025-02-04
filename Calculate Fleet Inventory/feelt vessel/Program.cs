using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace feelt_vessel
{
    public class Vessel
    {
        public string Name { get; set; }
        public string VesselNumber { get; set; }
        public int ShipCap { get; set; }
        public int CurrentLoad { get; set; }

        public Vessel(string name, string vesselNumber, int shipCap, int currentLoad)
        {
            Name = name;

            VesselNumber = vesselNumber;
            
            ShipCap = shipCap;
            
            CurrentLoad = currentLoad;
        }

        public void SetShipCap(int cap)
        {
            ShipCap = cap;
        }

        public void SetCurrentLoad(int load)
        {
            CurrentLoad = load;
        }

        public int CalcAvailCapacity()
        {
            return ShipCap - CurrentLoad;
        }
    }


    public class Fleet
    {
        public List<Vessel> vessels = new List<Vessel>();

        public void AddVessel(Vessel vessel)
        {
            vessels.Add(vessel);
        }

        public List<Vessel> Vessel()
        {
            return vessels;
        }

        public int CalcCapacity()
        {
            int totalCap = 0;

            foreach (var vessel in vessels)
            {
                totalCap += vessel.ShipCap;

            }
            return totalCap;

        }

        public int CalcTotalLoad()
        {
            int totalLoad = 0;

            foreach (var vessel in vessels)
            {
                totalLoad += vessel.CurrentLoad;

            }
            return totalLoad;

        }

        public int CalcNumVessels()
        {
            return vessels.Count;
        }
         
    }
        

namespace ShipCompany
    {
        class Program
        {
            static void Main(string[] args)
            {
                Fleet fleet = new Fleet();

                fleet.AddVessel(new Vessel("Vessel A", "1", 10000, 5000));

                fleet.AddVessel(new Vessel("Vessel B", "2", 15000, 7000)); //list

                Console.WriteLine($"Fleet Size: {fleet.CalcNumVessels()}");

                Console.WriteLine($"Total Shipping Capacity: {fleet.CalcCapacity()} tons"); //inputs into console
                
                Console.WriteLine($"Total Current Load: {fleet.CalcTotalLoad()} tons");
                
                foreach (var vessel in fleet.vessels)
                {
                    Console.WriteLine("Capacity available for vessel {0} ({1}): {2} tons",
                
                    vessel.Name, vessel.VesselNumber, vessel.CalcAvailCapacity()); //inserts the strings into the consolewrite line by order
                }

                Console.ReadLine();
            }
        }
    }

}
