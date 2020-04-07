using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factory_method_try1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logistics myLogistics = new Logistics("terestrial");
            Logistics mySeaLogistics = new Logistics("maritim");
            
            int[] payload1 = { 1 };int[] payload2 = { 2};

            myLogistics.CreateTransport("start1", "dest1", payload1);
            myLogistics.CreateTransport("start2", "dest2", payload2);
            mySeaLogistics.CreateTransport("start3", "dest3", payload2);

            myLogistics.DisplayTransports();
            mySeaLogistics.DisplayTransports();
        }

        class Logistics
        {
            private string mLogisticsType= "none";

            List<Truck> trucks = new List<Truck>();
            List<Boat> boats = new List<Boat>();

            public Logistics ( string logisticsType)
            {
                mLogisticsType = logisticsType;
            }

            public void CreateTransport (string start, string dest, int[] payload)
            {
                if (mLogisticsType == "terestrial" || mLogisticsType == "none")
                {
                    Truck truck = new Truck(start, dest, payload);
                    trucks.Add(truck);
                } else if (mLogisticsType == "maritim")
                {
                    Boat boat = new Boat(start, dest, payload);
                    boats.Add(boat);
                }
            }

            public void DisplayTransports()
            {
                for (int i = 0; i < trucks.Count; i++)
                {
                    trucks[i].displayTruck();
                }
                for (int i = 0; i < boats.Count; i++)
                {
                    boats[i].displayTruck();
                }
            }
        }

        class Truck
        {
            protected string mDestination="none";
            protected string mStartLocation = "none";
            protected int[] mPayload = { 0 };

            public Truck (string start , string dest, int[] payload)
            {
                mDestination = dest;
                mStartLocation = start;
                mPayload = payload;
            }
            
            public void setDestination ( string dest)
            { mDestination = dest; }

            public void setStartLocation (string start)
            { mStartLocation = start; }

            public void setPayload(int []payload)
            { mPayload = payload; }
            public virtual void displayTruck()
            { Console.WriteLine("Truck: Start:" + mStartLocation + " , Dest:" + mDestination + " , Payload:" + mPayload.ToString());
            }

            public virtual void deliver()
            { Console.WriteLine("Truck delivering from:" + mStartLocation + " to: " + mDestination + " the following: " + mPayload);
            }
        }

        class Boat : Truck
        {
            public Boat(string start, string dest, int[] payload) : base(start, dest, payload)
            {
            }
            public virtual void displayBoat()
            {
                Console.WriteLine("Boat: Start:" + mStartLocation + " , Dest:" + mDestination + " , Payload:" + mPayload.ToString());
            }

            override
            public void deliver()
            {
                Console.WriteLine("boat delivering from:" + mStartLocation + " to: " + mDestination + " the following: " + mPayload);
            }
        }

    }
}
