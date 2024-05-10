using AvtoSalon.Domain.Enums;
using AvtoSalon.Service.DTOs;
using AvtoSalon.Service.Exceptions;
using AvtoSalon.Service.Interfaces;
using AvtoSalon.Service.Services;

namespace AvtoSalon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();
            try
            {
                carService.Create(new CarForCreationDto()
                {
                    Name = "Damas",
                    Model="Chevrolet",
                    Price=150000,
                    ColourType=ColourType.Green

                });
            }catch (AvtoSalonException ex)
            {
                Console.WriteLine($"{ex.statusCode},{ex.Message}");
            }
        }
    }
}
