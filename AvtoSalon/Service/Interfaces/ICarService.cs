 using AvtoSalon.Domain.Entities;
using AvtoSalon.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.Service.Interfaces
{
    public interface ICarService
    {
        public CarResultDto Create(CarForCreationDto dto);
        public CarResultDto Update(int id,CarForCreationDto dto);
        public bool Delete(int id);
        public CarResultDto GetById(int id);
        public List<CarResultDto> GetAll();


    }
}
