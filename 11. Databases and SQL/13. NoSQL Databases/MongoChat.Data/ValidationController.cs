namespace MongoChat.Data
{
    using System;
    using Contracts;
    using Models;

    public class ValidationController: IValidationController
    {
        private const int MinimumMessageTextLength = 2;

        public bool ValidateMessage(Message message)
        {
            return this.IsValidText(message) && this.IsValidUser(message.User);
        }

        private bool IsValidText(Message message)
        {
            if (string.IsNullOrEmpty(message.Text))
            {
                //throw new ArgumentException("Message text cannot be null or empty");
                return false;
            }

            /*if (message.Text.Length < MinimumMessageTextLength)
            {
               /* throw new ArgumentException(
                    string.Format("Message text must be at least {0} symbols", MinimumMessageTextLength));#1#
                return false;
            }*/

            return true;
        }

        private bool IsValidUser(User user)
        {
            return this.IsValidUsername(user.Username);
        }



        public bool IsValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                //                throw new ArgumentException("Username cannot be null or empty");
                return false;
            }
            return true;
        }
    }
}