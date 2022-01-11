using System.ComponentModel.DataAnnotations;

namespace WebMarmelad.Models.PropertyValueExpert
{
    public class PropertyExpertModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Стоимость (руб)")]
        public int CostIdValue { get; set; }

        [Display(Name = "Электроэнергия (квТч)")]
        public int PowerIdValue { get; set; }

        [Display(Name = "Мощность (ед)")]
        public int PowerCountIdValue { get; set; }

        [Display(Name = "Вода (куб)")]
        public int WaterIdValue { get; set; }

        [Display(Name = "Воздух (т)")]
        public int AirIdValue { get; set; }
    }
}
