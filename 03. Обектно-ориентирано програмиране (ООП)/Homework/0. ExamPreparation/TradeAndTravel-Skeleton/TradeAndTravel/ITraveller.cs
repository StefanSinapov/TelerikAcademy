using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public interface ITraveller
    {
        void TravelTo(Location location);
        Location Location {get;}
    }
}
