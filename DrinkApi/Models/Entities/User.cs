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
        public Guid UserId { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Maximum 64 Chars")]
        public string userEmail { get; set; }

        [Required]
        [StringLength(35, ErrorMessage = "Maximum 35 Chars")]
        public string userName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maximum 20 Chars")]
        public string passwordHash { get; set; }
        public bool Visible { get; set; }
        public List<User> user { get; set; }
    }
}