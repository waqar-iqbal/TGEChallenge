namespace TGEChallengeApp.Interfaces
{
    public interface IPostcodeManager
    {
        IEnumerable<string> GetAllPostcodes();
        bool AddNewPostcodes(IEnumerable<string> postcodes);
        bool DeletePostcode(string postcodeToDelete);
    }
}
