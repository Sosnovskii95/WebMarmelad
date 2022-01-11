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
        [Required(ErrorMessage ="Название")]
        public string Name { get; set; }

        [Display(Name = "Стоимость (руб)")]
        [Required(ErrorMessage ="Стоимость (руб)")]
        [Range(0, int.MaxValue, ErrorMessage ="Введите корректное значение")]
        public int Cost { get; set; }

        [Display(Name = "Электроэнергия (квТч)")]
        [Required(ErrorMessage = "Электроэнергия (квТч)")]
        [Range(0, int.MaxValue, ErrorMessage = "Введите корректное значение")]
        public int Power { get; set; }

        [Display(Name = "Вода (куб)")]
        [Required(ErrorMessage = "Вода (куб)")]
        [Range(0, int.MaxValue, ErrorMessage = "Введите корректное значение")]
        public int Water { get; set; }

        [Display(Name = "Воздух (т)")]
        [Required(ErrorMessage = "Воздух (т)")]
        [Range(0, int.MaxValue, ErrorMessage = "Введите корректное значение")]
        public bool Air { get; set; }

        [Display(Name = "Мощность (ед)")]
        [Required(ErrorMessage = "Мощность (ед)")]
        [Range(0, int.MaxValue, ErrorMessage = "Введите корректное значение")]
        public int PowerCount { get; set; }

        [Display(Name = "Затраты времени (ч)")]
        [Required(ErrorMessage = "Затраты времени (ч)")]
        [Range(0, int.MaxValue, ErrorMessage = "Введите корректное значение")]
        public int PowerTime { get; set; }

        [Display(Name = "Вес в %")]
        public int? Weight { get; set; }
    }
}
