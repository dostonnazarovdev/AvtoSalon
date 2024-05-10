using AvtoSalon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.Data.IRepositories
{
    public interface ICarRepository
    {
        public Car Create(Car car);
        public bool Delete(int id);
        public Car GetById(int id);
        public Car Update(Car car);
        public IEnumerable<Car> GetAll();

    }
}
