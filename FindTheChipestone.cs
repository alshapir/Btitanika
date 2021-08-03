using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shufersal
{
    public class FindTheChipestone
    {
        public List<string> FindChipestItem(Dictionary<int, List<string>> data)
        {
            float currentprice = 0;
            float nextprice = 0;
            List<string> lowestprice = new List<string>();

            for (int i = 0; i < data.Count; i++)
            {
                int key = data.Keys.ElementAt(i);
                List<string> value = data[key];
                string parsPrice = value[2];
                if (i == 0)
                {  
                    bool IsParsable = float.TryParse(parsPrice.Trim(), out currentprice);
                    lowestprice = value;
                }
                else
                {
                    float.TryParse(parsPrice.Trim(), out nextprice);
                }
                if(currentprice > nextprice)
                {
                    lowestprice = value;
                    float.TryParse(lowestprice[2].Trim(), out currentprice);
                }
                
            }
            return lowestprice;
        }
    }
}
