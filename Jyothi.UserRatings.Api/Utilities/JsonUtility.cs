using System;
using System.IO;

namespace Jyothi.UserRatings.Api.Utilities
{
    /// <summary>
    /// Utility to read and write Json files provided location and file name
    /// </summary>
    public class JsonUtility : IJsonUtility
    {
        /// <summary>
        /// Reads Json File
        /// </summary>
        /// <param name="fileName">Json file name</param>
        /// <param name="location">folder path</param>
        /// <returns>content from Json</returns>
        public string Read(string fileName, string location)
        {
            string result;
            try
            {
                var databaseJsonPath = System.Web.HttpContext.Current.Server.MapPath(@"~/" + location +"/" + fileName);
                using (StreamReader streamReader = new StreamReader(databaseJsonPath))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Writes to Json file
        /// </summary>
        /// <param name="fileName">Json file name</param>
        /// <param name="location">folder path</param>
        /// <param name="data">Json string</param>
        public void Write(string fileName, string location, string data)
        {
            var databaseJsonPath = System.Web.HttpContext.Current.Server.MapPath(@"~/" + location + "/" + fileName);

            using (var streamWriter = File.CreateText(databaseJsonPath))
            {
                streamWriter.Write(data);
            }
        }
    }
}