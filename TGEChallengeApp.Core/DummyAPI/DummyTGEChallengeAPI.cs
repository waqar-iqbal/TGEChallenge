using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using TGEChallengeApp.Core.Models.API;

namespace TGEChallengeApp.DataAccess.API
{
    public class DummyTGEChallengeAPI
    {
        private readonly string _postcodeFilePathCSV = @"../../../../DataSource/postcode_data.csv";

        public APIResponse Get()
        {
            var postcodeData = File.ReadAllLines(_postcodeFilePathCSV).Select(line => line.Split(',')[0]);

            return new APIResponse
            {
                PostcodeData = postcodeData,
                IsSuccess = true,
            };
        }
    }
}
