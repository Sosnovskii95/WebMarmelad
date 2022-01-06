#nullable disable
using WebMarmelad.Models.PropertyValueExpert;

namespace WebMarmelad.Models.Weight
{
    public class WeightViewModel
    {
        public WeightModel WeightModel { get; set; }

        public IEnumerable<PropertyExpertModel> PropertyExpertOne { get; set; }

        public IEnumerable<PropertyExpertModel> PropertyExpertTwo { get; set; } 
    }
}
