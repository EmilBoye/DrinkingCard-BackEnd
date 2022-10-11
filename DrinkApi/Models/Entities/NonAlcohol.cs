using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkApi.Models.Entities
{
    public class NonAlcohol
    {
        [Key]
        public int NonAlcoId { get; set; }
        public string Title { get; set; }
        public string Strength { get; set; }
        public string Ingredients { get; set; }
        public string NonAlcoholType { get; set; }
    }
}