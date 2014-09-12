namespace Phonebook
{
    using System.Collections.Generic;

    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds new entry if user is not exist or merge it if name exists.
        /// </summary>
        /// <param name="name">Name of entry.</param>
        /// <param name="phoneNumbers">Phone numbers of given person.</param>
        /// <returns>True if new entry is created and false if it is merged.</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Changes all phone numbers which finds with new one ones.
        /// </summary>
        /// <param name="oldPhoneNumber">Number to be changed.</param>
        /// <param name="newPhoneNumber">New number to be changed with.</param>
        /// <returns>True if at least one phone number is changed and false if none.</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Give all entries from given index and count.
        /// </summary>
        /// <param name="startIndex">Index of witch list will start.</param>
        /// <param name="count">Number of entries to be included in the list.</param>
        /// <returns>Return array of Entries or throws error if start index or count are invalid.</returns>
        IEnumerable<PhoneEntry> ListEntries(int startIndex, int count);
    }
}
