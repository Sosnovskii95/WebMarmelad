#nullable disable
using WebMarmelad.Models.CodeFirst;
namespace WebMarmelad.Models.FilterSortView
{
    public class FilterSortViewModel
    {
        public IEnumerable<Production> Productions { get; set; }

        public SortModel SortModel { get; set; }

        public FilterModel FilterModel { get; set; }
    }
}
