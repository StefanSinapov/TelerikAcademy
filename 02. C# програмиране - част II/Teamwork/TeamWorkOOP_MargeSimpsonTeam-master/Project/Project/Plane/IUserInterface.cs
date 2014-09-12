using System;

namespace Plane
{
    public interface IUserInterface
    {
        event EventHandler OnUpKeyPressed;

        event EventHandler OnDownKeyPressed;

        event EventHandler OnFireKeyPressed;

        void CheckForInput();

        

    }
}
