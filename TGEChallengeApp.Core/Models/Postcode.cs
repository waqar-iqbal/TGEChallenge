using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TGEChallengeApp.Core.Models
{
    public class Postcode
    {
        public Postcode(string postcode)
        {
            PostcodeData = postcode.Trim().Replace(" ", "");
        }

        public string PostcodeData { get; set; }

        /// <summary>
        /// Validate the postcode. 
        /// We are assuming that the postcode is valid if it is between 5 and 7 characters long with the space already removed.
        /// We also assume the last 2 characters of the postcode must be letters.
        /// </summary>
        /// <returns> A bool indicating whether the bool is valid or not.</returns>
        public bool IsValid()
        {
            var regex = new Regex(@"^[a-zA-Z]*$");
            
            if (string.IsNullOrWhiteSpace(PostcodeData) == false && PostcodeData.Length >= 5 && PostcodeData.Length <= 7 && regex.IsMatch(PostcodeData.Trim().Substring(PostcodeData.Length - 2, 2)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the district of the postcode. We're assuming we can find the district by removing the last 3 characters of the postcode.
        /// </summary>
        /// <returns> The district as a string.</returns>
        public string GetDistrict()
        {
            if (IsValid())
            {
                return PostcodeData.Trim().Substring(0, PostcodeData.Length - 3);
            }

            return string.Empty;
        }
    }
}
