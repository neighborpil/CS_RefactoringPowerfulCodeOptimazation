using System;
using System.Collections.Generic;

namespace ExtractMethod
{
    class TextUtils
    {
        string[] FindEqualWords(string firstText, string secondText)
        {
            List<string> firstLetterList = GetLetterList(firstText);
            List<string> secondLetterList = GetLetterList(firstText);

            return GetOverlapingLetters(firstLetterList, secondLetterList);
        }

        private List<string> GetLetterList(string text)
        {
            List<string> letterList = new List<string>();
            string activeWord = string.Empty;
            IterateLetters(text, (ch) =>
            {
                if (Char.IsLetter(ch))
                    activeWord += ch;
                else if (!string.IsNullOrEmpty(activeWord))
                {
                    letterList.Add(activeWord);
                    activeWord = string.Empty;
                }
            });

            return letterList;
        }

        public void IterateLetters(string text, Action<char> action)
        {
            int textLength = text.Length;
            int idx = 0;
            while (idx < textLength)
            {
                char ch = text[idx];
                action(ch);
            }
        }



        private string[] GetOverlapingLetters(List<string> firstLetterList, List<string> secondLetterList)
        {
            List<string> result = new List<string>();
            foreach (string letter in firstLetterList)
                if (secondLetterList.Contains(letter))
                    result.Add(letter);
            return result.ToArray();
        }
    }
}
