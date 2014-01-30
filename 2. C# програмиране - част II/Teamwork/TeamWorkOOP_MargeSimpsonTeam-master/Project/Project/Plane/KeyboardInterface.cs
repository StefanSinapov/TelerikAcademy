using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    
    public class KeyboardInterface : IUserInterface
    {    
        public void CheckForInput()
        {
            if (Console.KeyAvailable)
            {
                var KeyInfo = Console.ReadKey();

                if (KeyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (this.OnUpKeyPressed != null)
                    {
                        this.OnUpKeyPressed(this, new EventArgs());
                    }                    
                }

                if (KeyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (this.OnDownKeyPressed != null)
                    {
                        this.OnDownKeyPressed(this, new EventArgs());
                    }
                }

                if (KeyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnFireKeyPressed != null)
                    {
                        this.OnFireKeyPressed(this, new EventArgs());
                    }
                }

            }
        }

        public event EventHandler OnUpKeyPressed;

        public event EventHandler OnDownKeyPressed;

        public event EventHandler OnFireKeyPressed;

    }
}
