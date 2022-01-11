using WebMarmelad.Models.PropertyValueExpert;
using WebMarmelad.Models.Alternativ;
namespace WebMarmelad.Models.Weight
{
    public class WeightAlternativ : FindAlternativ
    {
        private List<PropertyExpertModel> _propertyExpertModelList = new List<PropertyExpertModel>();
        private ValueExpertUtil valueExpertUtil = new ValueExpertUtil();

        private double[] massAlternativ;
        private int indexBestAlternativ;

        public WeightAlternativ(List<PropertyExpertModel> propertyExpertModelList)
        {
            _propertyExpertModelList = propertyExpertModelList;
            if (_propertyExpertModelList.Count > 0)
            {
                GetBestWeight();
            }
        }

        public int GetIndexBestAlternativ()
        {
            return indexBestAlternativ;
        }

        public double[] GetMassAlternativ()
        {
            double[] mainAltemp = new double[massAlternativ.Length];
            for (int i = 0; i < massAlternativ.Length; i++)
            {
                mainAltemp[i] = Math.Round(massAlternativ[i], 2);
            }

            return mainAltemp;
        }

        private void GetBestWeight()
        {
            double[] priceAl1 = GetPriceAlternative(valueExpertUtil.GetMatrixFromList(_propertyExpertModelList.Take(5).ToList()));
            double[] priceAl2 = GetPriceAlternative(valueExpertUtil.GetMatrixFromList(_propertyExpertModelList.Skip(5).ToList()));

            double sumAl1 = GetSummaPriceAlternative(priceAl1);
            double sumAl2 = GetSummaPriceAlternative(priceAl2);

            double[] weightAl1 = GetWeight(priceAl1, sumAl1);
            double[] weightAl2 = GetWeight(priceAl2, sumAl2);

            massAlternativ = GetMainAlternative(weightAl1, weightAl2);

            indexBestAlternativ = GetIndexBestWeigth(massAlternativ);
        }
    }
}
