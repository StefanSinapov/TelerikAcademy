namespace ComputersBuilding.ComputerComponents.Contracts
{
    /// <summary>
    /// Defines the default behavior and functionality of the motherboard
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Used for loading a value from the RAM, save values to the RAM and draw on the video card.
        /// </summary>
        /// <returns>Returns the value.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves a new value to the RAM by the provided argument 'value'.
        /// </summary>
        /// <param name="value">Int32 value that is saved in the RAM.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Sends a drawing request to the corresponding video card (GPU).
        /// </summary>
        /// <param name="data">A string data that is sent to the renderer (video card).</param>
        void DrawOnVideoCard(string data);
    }
}
