using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace command_pattern_try1
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleRemoteControl simpleRemote = new SimpleRemoteControl(); //clientul
            
            GardenLight gardenLight = new GardenLight(); //obiectul cu actiunile / de controlat

            GardenLightOnCommand gardenLightOnCommand = new GardenLightOnCommand(gardenLight); // obiectul care putem sa-l folosim pentru a controla 

            simpleRemote.setCommand(gardenLightOnCommand); // 
            simpleRemote.buttonPress(); //comanda efectiva
        }
    }

    class SimpleRemoteControl
    {
        Command slot;

        public void setCommand (Command command)
        { slot = command; }

        public void buttonPress()
        { slot.execute(); }
    }

    //clase/obiecte care au actiuni de facut, si pe care vrem sa le declupam de clasa care le va executa
    class GardenLight 
    {
        public void turnOnGardenLight() { Console.WriteLine("turn on the garden light"); }
        public void turnOffGardenLight() { Console.WriteLine("turn off the garden light"); }
    }

    class HouseLight
    {
        public void turnOnHouseLight() { Console.WriteLine("turn on the house light"); }
        public void turnOffHouseLight() { Console.WriteLine("turn off the house light"); }
    }

    class Thermostate 
    {
        public void setThermostateTemperature(int temp) { Console.WriteLine("setting thermostate temperature" + temp); }
        public void enableThermostateEcoMode() { Console.WriteLine("enabled thermostate eco mode"); }
        public void disableThermostateEcoMode() { Console.WriteLine("disable thermostate eco mode"); }
    }

    class CeilingFan 
    {
        public void turnOnCeilingFan() { Console.WriteLine("turn on the ceiling fan"); }
        public void turnOffCeilingFan() { Console.WriteLine("turn off the ceiling fan"); }
    }

    interface Command 
    {
        void execute();
        void unExecute();
    }

    class GardenLightOnCommand : Command
    {
        GardenLight gardenLight_;
        public GardenLightOnCommand(GardenLight gardenLigt)
        {
            gardenLight_ = gardenLigt;
        }

        public void execute()
        {
            gardenLight_.turnOnGardenLight();
        }

        public void unExecute()
        {
            gardenLight_.turnOffGardenLight();
        }
    }

    class GardenLightOffCommand : Command
    {
        GardenLight gardenLight_;
        public GardenLightOffCommand(GardenLight gardenLigt)
        {
            gardenLight_ = gardenLigt;
        }

        public void execute()
        {
            gardenLight_.turnOffGardenLight();
        }

        public void unExecute()
        {
            gardenLight_.turnOnGardenLight();
        }
    }
}

