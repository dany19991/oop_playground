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
            Logistics myLogistics = new Logistics();
            int[] payload1 = { 1 };int[] payload2 = { 2};

            myLogistics.CreataTransport("start1", "dest1", payload1);
            myLogistics.CreataTransport("start2", "dest2", payload2);

            myLogistics.DisplayTransports();
        }

        class Logistics
        {
            List<Truck> trucks = new List<Truck>();

            public void CreataTransport (string start, string dest, int[] payload)
            {
                Truck truck = new Truck(start, dest, payload);
                trucks.Add(truck);
            }

            public void DisplayTransports()
            {
                for (int i = 0; i < trucks.Count; i++)
                {
                    trucks[i].displayTruck();
                }
            }
        }

        class Truck
        {
            private string mDestination="none";
            private string mStartLocation = "none";
            private int[] mPayload = { 0 };

            public Truck (string start , string dest, int[] payload)
            {
                mDestination = dest;
                mStartLocation = start;
                mPayload = payload;
            }
            
            public void setDestination ( string dest)
            {
                mDestination = dest;
            }

            public void setStartLocation (string start)
            {
                mStartLocation = start;
            }

            public void setPayload(int []payload)
            {
                mPayload = payload;
            }
            public void displayTruck()
            {
                Console.WriteLine("Start:" + mStartLocation + " , Dest:" + mDestination + " , Payload:" + mPayload.ToString());
            }
        }
    }
}
