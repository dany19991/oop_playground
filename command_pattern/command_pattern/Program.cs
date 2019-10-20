using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace command_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Command command1 = new Command();
            command1.execute();
            Command command2 = new ACOn();
            command2.execute();
            Command command3 = new Command();
            try { ((ACOn)command3).execute(); }
            catch { }
            Console.WriteLine(((ACOn)command2).getACstate());
            Console.ReadKey();
        }
    }
    
    class Command
    {
        virtual public void execute() { }
    }

    class ACOn : Command
    {
        private string ACstate = "OFF";
        public override void execute()
        {
            Console.WriteLine("turning on AC");
            ACstate = "ON";
        }
        public void undo()
        {
            Console.WriteLine("turning off AC");
            ACstate = "OFF";
        }

        public String getACstate()
        {
            return ACstate;
        }
    }


}

