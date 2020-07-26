namespace Jyothi.UserRatings.Api.Utilities
{
    /// <summary>
    /// Utility to read and write Json files provided location and file name
    /// </summary>
    public interface IJsonUtility
    {
        /// <summary>
        /// Reads Json File
        /// </summary>
        /// <param name="fileName">Json file name</param>
        /// <param name="location">folder path</param>
        /// <returns>content from Json</returns>
        string Read(string fileName, string location);

        /// <summary>
        /// Writes to Json file
        /// </summary>
        /// <param name="fileName">Json file name</param>
        /// <param name="location">folder path</param>
        /// <param name="data">Json string</param>
        void Write(string fileName, string location, string data);
    }
}