using System.Collections.Generic;

namespace Soul.Models
{
    public class BindingLists
    {
        //-----------------------------------------------------------------------------------------------
        public List<string> Cities { get; } = null;
        public List<string> Vehicles { get; } = null;
        private Dictionary<string, List<string>> capacityMap = null;
        //-----------------------------------------------------------------------------------------------
        public BindingLists()
        {
            Cities = new List<string>();
            FillCities(Cities);
            Vehicles = new List<string>();
            FillVechicles(Vehicles);
            capacityMap = new Dictionary<string, List<string>>();
            LoadCapacity(capacityMap, Vehicles);
        }
        //-----------------------------------------------------------------------------------------------
        private void FillCities(List<string> cities)
        {
            cities.Add("София");
            cities.Add("Бургас");
            cities.Add("Варна");
            cities.Add("Пловдив");
            cities.Add("Друг");
        }
        //-----------------------------------------------------------------------------------------------
        private void FillVechicles(List<string> vechicles)
        {
            vechicles.Add("Лек автомобил");                //0
            vechicles.Add("Товарен автомобил");            //1
            vechicles.Add("Седлов влекач");                //2
            vechicles.Add("Мотоциклет и АТБ");             //3
            vechicles.Add("Товарно ремарке");              //4
            vechicles.Add("Багажнно или къмпинг ремарке"); //5
            vechicles.Add("Автобус");                      //6
            vechicles.Add("Тролейбус трамвайна мотриса");  //7
            vechicles.Add("Земеделска и горска техника");  //8
            vechicles.Add("Строителна техника");           //9
        }
        //-----------------------------------------------------------------------------------------------
        private void LoadCapacity(Dictionary<string, List<string>> capacityMap, List<string> vehicles)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (i == 0)
                {
                    capacityMap.Add(vehicles[0], new List<string>
                    { "Лек автомобил до 1300 куб. см.",
                      "Лек автомобил до 1500 куб. см.",
                      "Лек автомобил до 1600 куб. см.",
                      "Лек автомобил до 1800 куб. см.",
                      "Лек автомобил до 2000 куб. см.",
                      "Лек автомобил до 2500 куб. см.",
                      "Лек автомобил над 2500 куб. см."
                    });
                }
                else if (i == 1)
                {
                    capacityMap.Add(vehicles[1], new List<string>
                    { "Товарен автомобил до 1,5 т.",
                      "Товарен автомобил до 3,5 т.",
                      "Товарен автомобил до 5 т.",
                      "Товарен автомобил до 10 т.",
                      "Товарен автомобил до 20 т.",
                      "Товарен автомобил над 20 т."
                    });
                }
                else if (i == 6)
                {
                    capacityMap.Add(vehicles[6], new List<string>
                    { "Автобус до 20 места",
                      "Автобус от 21 до 40 места",
                      "Автобус над 40 места"
                    });
                }
                else
                {
                    capacityMap.Add(vehicles[i], new List<string>{ "Станартен" });
                }
            }
        }
        //-----------------------------------------------------------------------------------------------
        public List<string> VehCapacity(string vehicle)
        {
            List<string> resp = null;
            if (capacityMap != null)
            {
                if (capacityMap.ContainsKey(vehicle))
                {
                    capacityMap.TryGetValue(vehicle, out resp);
                }
            }
            return resp;
        }
        //-----------------------------------------------------------------------------------------------
    }
}
