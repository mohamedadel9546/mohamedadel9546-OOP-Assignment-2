namespace Maximum_Number_Of_Vowel
{
    internal class Program
    {
        public int MaxVowels(string s, int k)
        {
            int count = 0;
            for(int i = 0; i < k; i++)
            {
                if (isvowel(s[i])) count++; 
            }
            int MaxVowel = count;
            for (int end = k; end < s.Length; end++) {
                if (isvowel(s[end - k]))
                    count--;
                if (isvowel(s[end]))
                    count++;
                MaxVowel = Math.Max(MaxVowel, count);
                if (MaxVowel == k)
                    return MaxVowel;
            }
            return MaxVowel;
        }
        bool isvowel(char c)
        {
            return c switch
            {
                'a' or 'e' or 'i' or 'o' or 'u' or
                 'A' or 'E' or 'I' or 'O' or 'U'
                 => true,
                _ => false
            };
        }
        static void Main(string[] args)
        {
            string s = "abciiidef";
            int k = 3;
        }
    }
}
