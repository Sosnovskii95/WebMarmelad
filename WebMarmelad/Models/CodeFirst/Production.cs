#nullable disable
using System.ComponentModel.DataAnnotations;

namespace WebMarmelad.Models.CodeFirst
{
    public class Production
    {
        [Key]
        [Display(Name = "Номер")]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Стоимость (руб)")]
        public int Cost { get; set; }

        [Display(Name = "Электроэнергия (квТч)")]
        public int Power { get; set; }

        [Display(Name = "Вода (куб)")]
        public int Water { get; set; }

        [Display(Name = "Воздух (т)")]
        public bool Air { get; set; }

        [Display(Name = "Мощность (ед)")]
        public int PowerCount { get; set; }

        [Display(Name = "Затраты времени")]
        public int PowerTime { get; set; }

        [Display(Name = "Вес в %")]
        public int? Weight { get; set; }
    }
}
