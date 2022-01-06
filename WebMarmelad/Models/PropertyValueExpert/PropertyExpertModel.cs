using System.ComponentModel.DataAnnotations;

namespace WebMarmelad.Models.PropertyValueExpert
{
    public class PropertyExpertModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Цена")]
        public int CostIdValue { get; set; }

        [Display(Name = "Электроэнергия")]
        public int PowerIdValue { get; set; }

        [Display(Name = "Кол-во")]
        public int PowerCountIdValue { get; set; }

        [Display(Name = "Вода")]
        public int WaterIdValue { get; set; }

        [Display(Name = "Воздух")]
        public int AirIdValue { get; set; }
    }
}
