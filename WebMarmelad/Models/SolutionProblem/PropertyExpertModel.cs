﻿using System.ComponentModel.DataAnnotations;

namespace WebMarmelad.Models.SolutionProblem
{
    public class PropertyExpertModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Цена")]
        public int BoxCostIdConst { get; set; }

        [Display(Name = "Электроэнергия")]
        public int BoxElectricityIdConst { get; set; }

        [Display(Name = "Кол-во")]
        public int BoxPowerIdConst { get; set; }

        [Display(Name = "Вода")]
        public int BoxWaterIdConst { get; set; }

        [Display(Name = "Воздух")]
        public int BoxAirIdConst { get; set; }
    }
}
