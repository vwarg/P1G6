using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordLib
{
    public class PasswordHelper
    {
        public static string GetHash(string input)
        {
            var result = "";
            result = Sodium.PasswordHash.ScryptHashString(input, Sodium.PasswordHash.Strength.Medium);
            return result;
        }

        public static bool MatchesHash(string input, string hash)
        {
            return Sodium.PasswordHash.ScryptHashStringVerify(hash, input);   
        }



        private static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        private static byte[] StringToByteArray(string str)
        {
            byte[] ret = new byte[str.Length / 2];
            for(var i = 0; i < ret.Length; i++)
            {
                ret[i] = Convert.ToByte(str.Substring(i*2, 2), 16);
            }
            return ret;
        }
    }
}
