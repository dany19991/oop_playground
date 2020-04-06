namespace observer_pattern_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {

        }
    }
    public class WeatherData
    {
        public float getHumidity()
        { return 0; }

        public float getPressure()
        { return 0; }

        public float getTemperature()
        { return 0; }

        public void measurementsChanged()
        {
            float temp = getTemperature();
            float humidity = getHumidity();
            float pressure = getPressure();

            //display1.update(temp, humidity, pressure);
            //display2.update(temp, humidity, pressure);
            //display3.update(temp, humidity, pressure);
        }
    }


}