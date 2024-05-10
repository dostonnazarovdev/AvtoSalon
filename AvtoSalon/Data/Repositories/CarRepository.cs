using AvtoSalon.Domain.Entities;
using AvtoSalon.Domain.Configurations;
using AvtoSalon.Data.IRepositories;
using AvtoSalon.Domain.Enums;

namespace AvtoSalon.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly string path = DatabasePath.carDbPath;
        public Car Create(Car car)
        {
            string str = $"{car.Id}|{car.Name}|{car.Model}| {car.Price}|{car.ColourType}|{car.CreatedAt}|{car.UpatedAt}\n";
            File.AppendAllText(path, str);
            return car;
        }
        public bool Delete(int id)
        {
            var cars = GetAll();
            bool isAvailable = false;
            File.WriteAllText(path, "");
            foreach (var item in cars)
            {
                if (item.Id == id)
                {
                    isAvailable = true;
                     continue;
                }
                    Create(item);
            }
            return isAvailable;
        }
        public IEnumerable<Car> GetAll()
        {
            string[] cars = File.ReadAllLines(path);
            List<Car> list = new List<Car>();
            foreach (var car in cars)
            {
                Car mapped = new Car();
                string[] parts = car.Split('|');
                Car mappedCar = new Car()
                {
                    Id = long.Parse(parts[0]),
                    Name = parts[1],
                    Model= parts[2],
                    Price = long.Parse(parts[3]),
                    ColourType = (ColourType)Enum.Parse(typeof(ColourType),parts[4]),
                    CreatedAt = DateTime.Parse(parts[5]) 
                };
                list.Add(mappedCar);
            }
            return list;
        }
        public Car Update(Car car)
        {
            var cars = GetAll();
            File.WriteAllText(path,"");
            foreach (var item in cars)
            {
                if (item.Id == car.Id)
                {
                    Create(car);
                    continue;
                }
                Create(item);
            }
            return car;
        }
        public Car GetById(int id)
        {
          return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
