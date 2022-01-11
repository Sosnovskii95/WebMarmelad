namespace WebMarmelad.Models.PropertyValueExpert
{
    public static class PropertyExpertUtil
    {
        public static List<PropertyExpertModel> GetDefaultPropertyExpertList()
        {
            List<PropertyExpertModel> propertyExpertModels = new List<PropertyExpertModel>();
            int countList = 10;
            int count = 0;
            Random random = new Random();

            for (int i = 0; i < countList; i++)
            {
                PropertyExpertModel property = new PropertyExpertModel()
                {
                    Id = i + 1,
                    AirIdValue = random.Next(0, 17),
                    CostIdValue = random.Next(0, 17),
                    PowerCountIdValue = random.Next(0, 17),
                    PowerIdValue = random.Next(0, 17),
                    WaterIdValue = random.Next(0, 17)
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
