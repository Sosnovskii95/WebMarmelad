using WebMarmelad.Models.CodeFirst;
namespace WebMarmelad.Models.Alternativ
{
    public class Pareto
    {
        public List<Production> GetFindPareto(List<Production> productions)
        {
            return DeletElementsDown(DeleteElementsUp(productions));
        }

        private List<Production> DeletElementsDown(List<Production> productions)
        {
            for (int i = 0; i < productions.Count - 1; i++)
            {
                for (int j = i + 1; j < productions.Count; j++)
                {
                    if (productions[i].Cost <= productions[j].Cost)
                    {
                        if (productions[i].Power <= productions[j].Power)
                        {
                            if (productions[i].Water <= productions[j].Water)
                            {
                                if (productions[i].PowerCount >= productions[j].PowerCount)
                                {
                                    if (Convert.ToInt32(productions[i].Air) <= Convert.ToInt32(productions[j].Air))
                                    {
                                        if (productions[i].PowerTime <= productions[j].PowerTime)
                                        {
                                            productions.Remove(productions[j]);
                                            if (i != 0)
                                            {
                                                i--;
                                            }
                                            j--;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return productions;
        }

        private List<Production> DeleteElementsUp(List<Production> productions)
        {
            for (int i = 0; i < productions.Count - 1; i++)
            {
                for (int j = i + 1; j < productions.Count; j++)
                {
                    if (productions[i].Cost >= productions[j].Cost)
                    {
                        if (productions[i].Power >= productions[j].Power)
                        {
                            if (productions[i].Water >= productions[j].Water)
                            {
                                if (productions[i].PowerCount <= productions[j].Power)
                                {
                                    if (Convert.ToInt32(productions[i].Air) >= Convert.ToInt32(productions[j].Air))
                                    {
                                        if (productions[i].PowerTime >= productions[j].PowerTime)
                                        {
                                            productions.Remove(productions[j]);
                                            if (i != 0)
                                            {
                                                i--;
                                            }
                                            j--;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return productions;
        }
    }
}
