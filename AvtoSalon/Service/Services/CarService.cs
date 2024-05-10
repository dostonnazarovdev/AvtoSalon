using AvtoSalon.Service.DTOs;
using AvtoSalon.Data.Repositories;
using AvtoSalon.Data.IRepositories;
using AvtoSalon.Service.Exceptions;
using AvtoSalon.Service.Interfaces;
using AvtoSalon.Domain.Entities;

namespace AvtoSalon.Service.Services
{
    public class CarService : ICarService
    {
        // private readonly ICarRepository _carRepository = new CarRepository();
        private readonly CarRepository _carRepository;
        private long carId = 0;
        public CarService( )
        {
            _carRepository = new CarRepository();
        }
        public CarResultDto Create(CarForCreationDto dto)
        {
            var car = _carRepository.GetAll().FirstOrDefault(x =>
            x.Name.ToLower() == dto.Name.ToLower() &&
            x.Model.ToLower() == dto.Model.ToLower());
            if (car is null)
            {
                throw new AvtoSalonException(404, "User does not exist!");
            }
            Car mapperCar = new Car()
            {
                Id = carId,
                Name = dto.Name,
                Model = dto.Model,
                Price = dto.Price,
                ColourType = dto.ColourType,
                CreatedAt = DateTime.Now
            };
            _carRepository.Create(mapperCar);

            CarResultDto carResbonseDto = new CarResultDto()
            {
                Id = carId++,
                Name = dto.Name,
                Model = dto.Model,
                Price = dto.Price,
                ColourType = dto.ColourType
            };
            return carResbonseDto;
        }
        public bool Delete(int id)
        {
            var car = _carRepository.GetById(id);

            if (car is null)
            {
                throw new AvtoSalonException(404, "Car does not found!");
            }

            bool result = _carRepository.Delete(id);
            return result;
        }
        public List<CarResultDto> GetAll()
        {
            var cars = _carRepository.GetAll();
            List<CarResultDto> list = new List<CarResultDto>();
            if (cars != null)
            {
                throw new AvtoSalonException(404, "Car is not found!");
            }
            foreach (var car in cars)
            {
                CarResultDto resultCar = new CarResultDto()
                {
                    Id = car.Id,
                    Name = car.Name,
                    Model = car.Model,
                    Price = car.Price,
                    ColourType = car.ColourType
                };
                list.Add(resultCar);
            }
            return list;
        }
        public CarResultDto GetById(int id)
        {
            var car = _carRepository.GetById(id);
            if (car is null)
            {
                throw new AvtoSalonException(404, "Car is not found!");
            }
            CarResultDto carResult = new CarResultDto()
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                Price = car.Price,
                ColourType = car.ColourType
            };
            return carResult;
        }
        public CarResultDto Update(int id, CarForCreationDto dto)
        {
            var car = _carRepository.GetById(id);
            if (car == null)
            {
                throw new AvtoSalonException(404, "Car is not found");
            }
            car.Id=id;
            car.Name=dto.Name;
            car.Model=dto.Model;
            car.Price=dto.Price;
            car.ColourType=dto.ColourType;
            car.UpatedAt=DateTime.Now;
            _carRepository.Update(car);

            CarResultDto resultDto = new CarResultDto()
            {
                Id = car.Id,
                Name = dto.Name,
                Model = dto.Model,
                Price = dto.Price,
                ColourType = dto.ColourType
            };
            return resultDto;
            
        }
    }
}
