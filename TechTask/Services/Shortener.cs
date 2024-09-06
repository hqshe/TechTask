using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TechTask.Data;

namespace TechTask.Services
{
    public class Shortener
    {
        private const int NumberOfChars = 8;
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly Random random = new Random();
        public string CreateCode(string str)
        {

                char[] chars = new char[NumberOfChars];
                int random_index;
                for (int i = 0; i < NumberOfChars; i++)
                {
                    random_index = random.Next(Alphabet.Length - 1);
                    chars[i] = Alphabet[random_index];
                }
                var code = new string(chars);
            return code;
        }
    }
}
