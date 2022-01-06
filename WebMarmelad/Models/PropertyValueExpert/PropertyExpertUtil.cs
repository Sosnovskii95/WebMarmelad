namespace WebMarmelad.Models.PropertyValueExpert
{
    public static class PropertyExpertUtil
    {
        public static List<PropertyExpertModel> GetDefaultPropertyExpertList()
        {
            List<PropertyExpertModel> propertyExpertModels = new List<PropertyExpertModel>();
            int countList = 10;
            int count = 0;

            for (int i = 0; i < countList; i++)
            {
                PropertyExpertModel property = new PropertyExpertModel()
                {
                    Id = i + 1,
                    AirIdValue = i,
                    CostIdValue = i,
                    PowerCountIdValue = i,
                    PowerIdValue = i,
                    WaterIdValue = i
                };

                switch (count)
                {
                    case 0:
                        property.CostIdValue = 8;
                        break;
                    case 1:
                        property.PowerIdValue = 8;
                        break;
                    case 2:
                        property.PowerCountIdValue = 8;
                        break;
                    case 3:
                        property.WaterIdValue = 8;
                        break;
                    case 4:
                        property.AirIdValue = 8;
                        break;
                }

                count++;
                if (count == 5)
                {
                    count = 0;
                }

                propertyExpertModels.Add(property);
            }
            return propertyExpertModels;
        }
    }
}
