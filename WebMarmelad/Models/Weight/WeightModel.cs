using System.ComponentModel.DataAnnotations;

namespace WebMarmelad.Models.Weight
{
    public class WeightModel
    {
        [Display(Name = "Стоимость (руб)")]
        public double CostWeight { get; set; }

        [Display(Name = "Электроэнергия (квТч)")]
        public double PowerWeight { get; set; }

        [Display(Name = "Мощность (ед)")]
        public double PowerCountWeight { get; set; }

        [Display(Name = "Вода (куб)")]
        public double WaterWeight { get; set; }

        [Display(Name = "Воздух (т)")]
        public double AirWeignt { get; set; }

        [Display(Name = "Лучший кретерий")]
        public double BestCriteria { get; set; }

        public string? NameBestCriteria { get; set; }
    }
}
