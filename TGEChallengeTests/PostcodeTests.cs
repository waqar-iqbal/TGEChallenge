using TGEChallengeApp.Core.Models;

namespace TGEChallengeTests
{
    public class PostcodeTests
    {
        [TestCase("ol41pt")]
        [TestCase("bl3 6bu")]
        [TestCase("bd16 2ap")]
        public void IsValid_ValidPostcode_ReturnsTrue(string testPostcode)
        {
            var postcode = new Postcode(testPostcode);

            var result = postcode.IsValid();

            Assert.IsTrue(result);
        }

        [TestCase("ol41pt2")]
        [TestCase("bl3 126bu")]
        [TestCase("bd162apaaa")]
        public void IsValid_InvalidPostcode_ReturnsFalse(string testPostcode)
        {
            var postcode = new Postcode(testPostcode);

            var result = postcode.IsValid();

            Assert.IsFalse(result);
        }

        [TestCase("ol41pt", "ol4")]
        [TestCase("bl3 6bu", "bl3")]
        [TestCase("bd161ap", "bd16")]

        public void GetDistrict_ValidPostcode_ReturnsDistrict(string testPostcode, string expectedDistrict)
        {
            var postcode = new Postcode(testPostcode);

            var result = postcode.GetDistrict();

            Assert.That(result, Is.EqualTo(expectedDistrict));
        }

        [TestCase("ol41pt2")]
        [TestCase("bl3 126bu")]
        [TestCase("bd162apaaa")]
        public void GetDistrict_InvalidPostcode_ReturnsEmptyString(string testPostcode)
        {
            var postcode = new Postcode(testPostcode);

            var result = postcode.GetDistrict();

            Assert.That(result, Is.Empty);
        }

        [TestCase("ol4 1pt")]
        [TestCase("bl3 6bu")]
        [TestCase("bd16  2ap")]
        public void Postcode_PoscodeWithSpaces_SpacesRemoved(string testPostcode)
        {
            var postcode = new Postcode(testPostcode);

            var result = postcode.PostcodeData;

            Assert.That(result, Is.Not.Contains(" "));
        }
    }
}