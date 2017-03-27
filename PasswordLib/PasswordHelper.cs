namespace PasswordLib
{
    public class PasswordHelper
    {
        public static string GetHash(string input)
        {
            var result = Sodium.PasswordHash.ScryptHashString(input, Sodium.PasswordHash.Strength.Medium);
            return result;
        }

        public static bool MatchesHash(string hash, string input)
        {
            return Sodium.PasswordHash.ScryptHashStringVerify(hash, input);   
        }
    }
}