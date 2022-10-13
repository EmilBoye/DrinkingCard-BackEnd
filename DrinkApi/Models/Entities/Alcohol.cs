using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkApi.Models.Entities
{
    public enum AlcoholType
    {
        Vodka,
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
    public class Alcohol
    {
        [Key]
        public int AlcoId { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Strength { get; set; }
        public string? Ingredients { get; set; }
        public AlcoholType alcoholType { get; set; }
        public bool Visible { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}