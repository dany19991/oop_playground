using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace observer_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WheatherData weatherData = new WheatherData();

            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay();
            weatherData.RegisterObserver(currentConditionsDisplay);

            weatherData.SetMeasurements(10.5f, 10.6f, 10.7f);
        }
    }

    class WheatherData : Subject
    {
        float humidity, temperature, pressure;
        List<Observer> observerList;
        public WheatherData() { observerList= new List<Observer>(); }

        public void NotifyObservers()
        {
            foreach(Observer o in observerList)
            {
                o.Update(humidity,temperature,pressure);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float humidity, float temperature, float pressure)
        {
            this.humidity = humidity;
            this.temperature = temperature;
            this.pressure = pressure;
            MeasurementsChanged();
        }

        public void RegisterObserver(Observer o)
        {
            observerList.Add(o);
        }

        public void RemoveObserver(Observer o)
        {
            observerList.Remove(o);
        }
    }

    class CurrentConditionsDisplay : Observer, DisplayElement
    {
        private float humidity ,temperature, pressure;
        /*
        private Subject weatherData;
        public CurrentConditionsDisplay(Subject weatherData_)
        {
            weatherData = weatherData_;
            weatherData.RegisterObserver(this);
        }  */

        public void Display()
        {
            Console.WriteLine("Hum: "+humidity+" , Temp: "+temperature+" , Press: "+pressure); 
        }

        public void Update(float humidity, float temperature, float pressure)
        {
            this.humidity = humidity;
            this.temperature = temperature;
            this.pressure = pressure;
            Display();
        }
    }

    interface Subject
    {
        void RegisterObserver(Observer o);
        void RemoveObserver(Observer o);
        void NotifyObservers();
    }

    interface Observer
    {
        void Update(float humidity, float temperature, float pressure);
    }

    interface DisplayElement
    {
        void Display();
    }
}
