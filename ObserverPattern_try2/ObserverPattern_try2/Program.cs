using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern_try2
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();
            CurrentConditions currentConditionsObserver = new CurrentConditions();
            CurrentTemperature currentTemperatureObserver = new CurrentTemperature();
            
            weatherStation.registerObserver(currentConditionsObserver);
            weatherStation.SetData(100, 100);
            weatherStation.registerObserver(currentTemperatureObserver);
            weatherStation.SetData(110, 100);
            weatherStation.removeObserver(currentConditionsObserver);
            weatherStation.SetData(120, 110);
            weatherStation.removeObserver(currentTemperatureObserver);
            weatherStation.SetData(199, 199);

        }        
    }

    interface Subject //sau Observable
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void updateObservers();
    }
    interface Observer //sau subscriber
    {
        void update(int temp, int humi);
    } 
    interface Display
    {
        void DisplayData();
    }
    class WeatherStation : Subject
    {
        //data :
        private int mTemperature;
        private int mHumidity;

        List<Observer> observers = new List<Observer>();
        
        public void registerObserver(Observer observer)
        {
            if (observers.Contains(observer)) { return; } // do not re-add it 
            observers.Add(observer);
        }

        public void removeObserver(Observer observer)
        {
            if (observers.Count > 0)
            {
                if (observers.Contains(observer))
                {
                    observers.Remove(observer);
                }
            }else 
            { Console.WriteLine("no observers registred"); }
        }

        public void updateObservers()
        {
           foreach(Observer obs in observers)
           {
              obs.update(getTemperature(),getHumidity());
           }
        }

        public int getTemperature() { return mTemperature; } 
        public int getHumidity() { return mHumidity; }

        public void SetData(int temp, int humi)
        {
            mTemperature = temp;
            mHumidity = humi;
            updateObservers();
        }
    }

    class CurrentConditions : Observer, Display
    {
        private int temperature = 999;private int humidity = 999;

        public void DisplayData()
        {
            Console.Write("Current temp: " + temperature + " and current humi: " + humidity+"\n");    
        }

        public void update(int temp, int humi)
        {
            temperature = temp;
            humidity = humi;
            DisplayData();
        }
    }

    class CurrentTemperature : Observer, Display
    {
        private int temperature = 999;

        public void DisplayData()
        {
            Console.Write("Current temperature is: " + temperature+"\n");
        }

        public void update(int temp, int humi)
        {
            temperature = temp;
            DisplayData();
        }
    }

}
