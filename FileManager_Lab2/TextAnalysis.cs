using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace FileManager_Lab2
{
    class TextAnalysis
    {
        public static String AddTwoText(String text1, String text2)
        {
            return text1 + "\n" + text2;
        }

        public static List<int> FindWordInText(String text, String Word)
        {
            List<int> lTextPos = new List<int>();

           // MatchCollection allIp = Regex.Matches(text, (string)Word);

            int StartPos;
            int Pos = -1;
            do 
            {
                StartPos = Pos + 1;
                Pos = text.IndexOf(Word, StartPos);
                if(Pos != -1)
                {
                    lTextPos.Add(Pos);
                }
            }while(Pos != -1);

            return lTextPos;
        }

        public static SortedDictionary<String, int> WordStatistic(String text)
        {
            SortedDictionary<String, int> dWord = new SortedDictionary<string,int>();

            String[] allWords = text.Split(new Char[] { ' '});

            foreach(String word in allWords)
            {
                if (dWord.ContainsKey(word))
                    dWord[word]++;
                else
                    dWord.Add(word, 1);
            }            

            return dWord;
        }

        public static List<String> GetImageFromText(String text)
        {
            List<String> lImages = new List<string>();
            String[] ext = new String[] { "jpg", "jpeg", "bmp", "png" };
            foreach(String extFile in ext)
            {
                List<String> lExtImage = GetImageFromText(text, extFile);

                lImages.AddRange(lExtImage);
            }

            return lImages;
        }

        public static List<String> GetImageFromText(String text, String fileExt)
        {
            List<String> lImages = new List<string>();

            int extStartPos;
            int extPos = -1;

            do
            {
                //find extensible
                extStartPos = extPos + 1;
                extPos = text.IndexOf(fileExt, extStartPos);
                if (extPos >= 0)
                {
                    //file path
                    int diskPos = text.LastIndexOf(":\\", extPos - 1) - 1;
                    if (diskPos < 0)
                        diskPos = text.LastIndexOf(":/", extPos - 1) - 1;
                    if (diskPos >= 0)
                    {
                        String path = text.Substring(diskPos, (extPos + fileExt.Length - 1) - diskPos + 1);
                        if (isImageExist(path))
                        {
                            lImages.Add(path);
                        }
                    }
                }

            }
            while (extPos != -1);

            return lImages;
        }
        private static bool isImageExist(String text)
        {
            return System.IO.File.Exists(text);
        }

    }
}
