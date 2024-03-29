﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkApi.Models.Entities
{
    public class NonAlcohol
    {
        [Key]
        public int Id { get; set; }
        public string? Author { get; set; }
        public int? AuthorId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string? Ingredients { get; set; }
        public string? NonAlcoholType { get; set; }
        public bool Visible { get; set; }
        #region FKUser
        //public User? User { get; set; }
        //public int UserId { get; set; }
        #endregion
        public DateTime? PublishDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}