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
        public int roleId { get; set; }
        public Role? role { get; set; }
        public string? userName { get; set; }
        public string? passwordHash { get; set; }
    }
}