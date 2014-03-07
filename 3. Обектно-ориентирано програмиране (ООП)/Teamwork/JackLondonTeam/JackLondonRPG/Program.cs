using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
    class Program
    {
        static void Main()
        {
            GameEngine engine = new GameEngine("Tropico", "Johny");
            engine.Run();
        }
    }
}
