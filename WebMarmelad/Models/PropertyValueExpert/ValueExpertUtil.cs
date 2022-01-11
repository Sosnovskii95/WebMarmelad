namespace WebMarmelad.Models.PropertyValueExpert
{
    public class ValueExpertUtil
    {
        private List<ValueExpertModel> _values;

        public ValueExpertUtil()
        {
            _values = new List<ValueExpertModel>();

            int id = 0;
            for (int i = 1; i < 2; i++)
            {
                for (int j = 9; j > 0; j--)
                {
                    ValueExpertModel valueExpertModel = new ValueExpertModel()
                    {
                        Id = id,
                        Value = (double)i / j
                    };

                    if (i == j)
                    {
                        valueExpertModel.NameValue = i.ToString();
                    }
                    else
                    {
                        valueExpertModel.NameValue = i + "/" + j;
                    }

                    _values.Add(valueExpertModel);
                    id++;
                }
            }

            for (int i = 2; i < 10; i++)
            {
                _values.Add(new ValueExpertModel
                {
                    Id = id,
                    NameValue = i.ToString(),
                    Value = (double)i
                });
                id++;
            }
        }

        public double[,] GetMatrixFromList(List<PropertyExpertModel> propertyExpertModelList)
        {
            PropertyExpertModel[] massValue = propertyExpertModelList.ToArray();

            double[,] matrixValue = new double[massValue.Length, massValue.Length];

            for (int i = 0; i < massValue.Length; i++)
            {
                for (int j = 0; j < massValue.Length; j++)
                {
                    switch (j)
                    {
                        case 0:
                            matrixValue[i, j] = GetValueById(massValue[i].CostIdValue);
                            break;
                        case 1:
                            matrixValue[i, j] = GetValueById(massValue[i].PowerIdValue);
                            break;
                        case 2:
                            matrixValue[i, j] = GetValueById(massValue[i].PowerCountIdValue);
                            break;
                        case 3:
                            matrixValue[i, j] = GetValueById(massValue[i].WaterIdValue);
                            break;
                        case 4:
                            matrixValue[i, j] = GetValueById(massValue[i].AirIdValue);
                            break;
                        default: break;
                    }
                }
            }

            return matrixValue;
        }

        public List<ValueExpertModel> GetValueExperts()
        {
            return _values;
        }

        public double GetValueById(int idValue)
        {
            return _values.FirstOrDefault(i => i.Id == idValue).Value;
        }
    }
}
