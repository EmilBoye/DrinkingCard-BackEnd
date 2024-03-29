﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkApi.Models.Entities
{
    #region AlcoholType
    public enum AlcoholType
    {
        Vodka = 1,
        Gin,
        Tequila,
        Pilsner,
        Classic,
        IPA,
        PALÈ,
        ALÉ,
        Mørk_Rom,
        Lys_Rom,
        Hvid_Rom,
        Whiskey,
        Rødvin,
        Hvidvin,
        Granvin,
        Portvin,
        Rosévin,
        Champagne,
    }
    #endregion
    #region Alcohol
    public class Alcohol
    {
        [Key]
        public int Id { get; set; }
        public string? Author { get; set; }
        public int? AuthorId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string? Strength { get; set; }
        public string? Ingredients { get; set; }
        public AlcoholType? AlcoholType { get; set; }
        public bool Visible { get; set; }
        #region FKUser
        //public User? User { get; set; }
        //public int UserId { get; set; }
        #endregion
        public DateTime? PublishDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    #endregion
}