namespace WebMarmelad.Models.FilterSortView
{
    public class SortModel
    {
        public SortAscDesc IdSort { get; private set; }
        public SortAscDesc NameSort { get; private set; }
        public SortAscDesc CostSort { get; private set; }
        public SortAscDesc PowerSort { get; private set; }
        public SortAscDesc WaterSort { get; private set; }
        public SortAscDesc AirSort { get; private set; }
        public SortAscDesc PowerCountSort { get; private set; }
        public SortAscDesc PowerTimeSort { get; private set; }
        public SortAscDesc WeightSort { get; private set; }
        public SortAscDesc Current { get; set; }

        public SortModel(SortAscDesc sort)
        {
            IdSort = sort == SortAscDesc.IdAsc? SortAscDesc.IdDesc : SortAscDesc.IdAsc;
            NameSort = sort == SortAscDesc.NameAsc?SortAscDesc.NameDesc:SortAscDesc.NameAsc;
            CostSort = sort == SortAscDesc.CostAsc?SortAscDesc.CostDesc:SortAscDesc.CostAsc;
            PowerSort = sort == SortAscDesc.PowerAsc ? SortAscDesc.PowerDesc : SortAscDesc.PowerAsc;
            WaterSort = sort == SortAscDesc.WaterAsc ? SortAscDesc.WaterDesc : SortAscDesc.WaterAsc;
            AirSort = sort == SortAscDesc.AirAsc ? SortAscDesc.AirDesc : SortAscDesc.AirAsc;
            PowerCountSort = sort == SortAscDesc.PowerCountAsc ? SortAscDesc.PowerCountDesc : SortAscDesc.PowerCountAsc;
            PowerTimeSort = sort == SortAscDesc.PowerTimeAsc ? SortAscDesc.PowerTimeDesc : SortAscDesc.PowerTimeAsc;
            WeightSort = sort == SortAscDesc.WeightAsc ? SortAscDesc.WeightDesc : SortAscDesc.WeightAsc;
            Current = sort;
        }
    }
}
