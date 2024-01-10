using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkApi.Models.Entities
{
    public class User
    {
        /// <summary>
        /// Key står for primary key
        /// </summary>
        [Key]
        public int Id { get; set; }
        public RoleType Role { get; set; }
        public string? Username { get; set; }
        public Alcohol? Alcohol { get; set; }
        public NonAlcohol? NonAlcohol { get; set; }
        public string? Passwordhash { get; set; }
    }
}