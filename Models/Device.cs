using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeAPI.Models
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
    }
}
