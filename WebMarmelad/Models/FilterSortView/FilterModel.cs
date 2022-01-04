namespace WebMarmelad.Models.FilterSortView
{
    public class FilterModel
    {
        public int? SelectedCost { get; private set; }
        public int? SelectedPower { get; private set; }
        public int? SelectedPowerCount { get; private set; }
        public int? SelectedPowerTime { get; private set; }

        public FilterModel(int? filterCost, int? filterPower, int? filterPowerCount, int? filterPowerTime)
        {
            SelectedCost = filterCost;
            SelectedPower = filterPower;
            SelectedPowerCount = filterPowerCount;
            SelectedPowerTime = filterPowerTime;
        }
    }
}
