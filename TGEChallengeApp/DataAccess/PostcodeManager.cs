using System.Linq;
using TGEChallengeApp.Core.Models;
using TGEChallengeApp.DataAccess.API;
using TGEChallengeApp.Interfaces;

namespace TGEChallengeApp.DataAccess
{
    public class PostcodeManager : IPostcodeManager
    {
        private readonly DummyTGEChallengeAPI _api;
        private static string _postcodeFilePathToSaveCSV  = @"../../../../DataSource/postcode_data_to_save.csv";

        public PostcodeManager(DummyTGEChallengeAPI api)
        {
            _api = api;
            _postcodeFilePathToSaveCSV = @"../../../../DataSource/postcode_data_to_save.csv";
        }

        public IEnumerable<string> GetAllPostcodes()
        {
            List<string> allPostcodes = new List<string>();
            var response = _api.Get();
            return response.PostcodeData;
        }

        /// <summary>
        /// Gets the postcode districts and their number of occurrences and saves it to a CSV file.
        /// </summary>
        /// <returns></returns>
        public bool GetDistrictSummary()
        {
            try
            {
                var postcodeData = GetAllPostcodes();
                var postcodeDistricts = postcodeData.Select(p => new Postcode(p))
                    .Where(x => x.IsValid())
                    .Select(y => y.GetDistrict());
                var groupedDistricts = postcodeDistricts.GroupBy(p => p).Select(x => new { district = x.Key, count = x.Count() });

                using (var file = File.CreateText(_postcodeFilePathToSaveCSV))
                {
                    file.WriteLine(string.Join(",", "Postcode District", "Count"));

                    foreach (var district in groupedDistricts)
                    {
                        file.WriteLine(string.Join(",", district.district, district.count));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;   
            }
        }

        /// <summary>
        /// Removes invalid postcodes from the CSV file and saves the valid postcodes to a new CSV file
        /// </summary>
        /// <returns>A bool indicating whether the method succeded or not.</returns>
        public bool ValidatePostcodes()
        {
            var postcodeData = GetAllPostcodes();
            var validPostcodes = postcodeData.Select(p => new Postcode(p))
                .Where(x => x.IsValid());

            return SavePostcodesToNewFile(validPostcodes.Select(p => p.PostcodeData));
        }

        public bool AddNewPostcodes(IEnumerable<string> newPostcodes)
        {
            var postcodeData = GetAllPostcodes().ToList();
            var validPostcodes = newPostcodes.Select(p => new Postcode(p))
                .Where(x => x.IsValid())
                .Select(y => y.PostcodeData);
            postcodeData.AddRange(validPostcodes);

            return SavePostcodesToNewFile(postcodeData);
        }

        public bool DeletePostcode(string postcodeToDelete)
        {
            var postcodeData = GetAllPostcodes().ToList();
            postcodeData.Remove(postcodeToDelete);

            return SavePostcodesToNewFile(postcodeData);
        }

        /// <summary>
        /// Saves a list of postcodes to a CSV file
        /// </summary>
        /// <param name="postcodesToSave"></param>
        /// <returns>A bool indicating if the file was saved successfully.</returns>
        public bool SavePostcodesToNewFile(IEnumerable<string> postcodesToSave)
        {
            try
            {
                using (var file = File.CreateText(_postcodeFilePathToSaveCSV))
                {
                    foreach (var postcode in postcodesToSave)
                    {
                        file.WriteLine(string.Join(",", postcode));
                    }
                }
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
