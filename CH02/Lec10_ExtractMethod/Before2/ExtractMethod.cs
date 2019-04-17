using System;
using System.Collections.Generic;

namespace ExtractMethod
{
    class TextUtils
    {
        string[] FindEqualWords(string firstText, string secondText)
        {
            List<string> firstWordsList = GetWordList(firstText);
            List<string> secondWordsList = GetWordList(secondText);

            return GetContainingWordArray(firstWordsList, secondWordsList);
        }

        private List<string> GetWordList(string text)
        {
            List<string> firstWordsList = new List<string>();
            string activeWord = string.Empty;
            
            IterateText(text, ch =>
            {
                if (Char.IsLetter(ch))
                    activeWord += ch;
                else if (!string.IsNullOrEmpty(activeWord))
                {
                    firstWordsList.Add(activeWord);
                    activeWord = string.Empty;
                }
            });

            return firstWordsList;
        }

        private void IterateText(string text, Action<char> action)
        {
            int textLength = text.Length;
            int idx = 0;
            while (idx < textLength)
            {
                char ch = text[idx];
                action(ch);
            }
        }

        private string[] GetContainingWordArray(List<string> firstWordsList, List<string> secondWordsList)
        {
            List<string> result = new List<string>();
            foreach (string word in firstWordsList)
                if (secondWordsList.Contains(word))
                    result.Add(word);
            return result.ToArray();
        }
    }
}
