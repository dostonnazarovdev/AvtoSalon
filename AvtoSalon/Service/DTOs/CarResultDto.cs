using AvtoSalon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoSalon.Service.DTOs
{
    public class CarResultDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public long Price { get; set; }
        public ColourType ColourType { get; set; }
    }
}
