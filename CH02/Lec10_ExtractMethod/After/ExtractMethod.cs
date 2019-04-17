using System;
using System.Collections.Generic;

namespace ExtractMethod
{
    class TextUtils
    {
        void IterateText(string text, Action<char> action)
        {
            int textLength = text.Length;
            int idx = 0;
            while (idx < textLength)
            {
                char ch = text[idx];
                action(ch);
            }
        }

        List<string> GetWordsFromText(string text)
        {
            List<string> resultList = new List<string>();
            string activeWord = string.Empty;
            IterateText(text, ch =>
            {
                if (Char.IsLetter(ch))
                    activeWord += ch;
                else if (!string.IsNullOrEmpty(activeWord))
                {
                    resultList.Add(activeWord);
                    activeWord = string.Empty;
                }
            });
            return resultList;
        }

        string[] FindEqualWords(List<string> firstWordsList, List<string> secondWordsList)
        {
            List<string> result = new List<string>();
            foreach (string word in firstWordsList)
                if (secondWordsList.Contains(word))
                    result.Add(word);
            return result.ToArray();
        }

        string[] FindEqualWords(string firstText, string secondText)
        {
            List<string> firstWordsList = GetWordsFromText(firstText);
            List<string> secondWordsList = GetWordsFromText(secondText);
            return FindEqualWords(firstWordsList, secondWordsList);
        }
    }
}
