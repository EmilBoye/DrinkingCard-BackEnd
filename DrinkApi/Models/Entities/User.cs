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
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public string? Username { get; set; }
        public int? AuthorId { get; set; }
        public Alcohol? Author { get; set; }
        public string? Passwordhash { get; set; }
    }
}