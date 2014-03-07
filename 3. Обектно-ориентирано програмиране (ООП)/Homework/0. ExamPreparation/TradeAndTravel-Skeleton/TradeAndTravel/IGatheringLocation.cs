using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public interface IGatheringLocation
    {
        ItemType GatheredType
        {
            get;
        }

        ItemType RequiredItem
        {
            get;
        }


        Item ProduceItem(string name);
    }
}
