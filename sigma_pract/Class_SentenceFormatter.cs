using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigma_pract
{
    public static class SentenceFormatter
    {
        public static string[] Replace(string[] inputStrs)
        {
            if (inputStrs == null || inputStrs.Contains(null))
                throw new ArgumentNullException("Input array was null reference or it contained null reference.");

            var outputBuilders = new StringBuilder[inputStrs.Length];
            for (int i = 0; i < inputStrs.Length; i++)
                outputBuilders[i] = new StringBuilder(inputStrs[i]);

            var signsCoordinates = new List<(int stringIndex, int signIndex)>();

            for (int i = 0; i < inputStrs.Length; i++)
                for (int j = 0; j < inputStrs[i].Length; j++)
                    if (inputStrs[i][j] == '#')
                        signsCoordinates.Add((i, j));

            for (int i = 0; i < signsCoordinates.Count / 2; i++)
                outputBuilders[signsCoordinates[i].stringIndex][signsCoordinates[i].signIndex] = '<';
            for (int i = signsCoordinates.Count - 1; i >= signsCoordinates.Count / 2; i--)
                outputBuilders[signsCoordinates[i].stringIndex][signsCoordinates[i].signIndex] = '>';


            var outputStrs = new string[inputStrs.Length];
            for (int i = 0; i < outputStrs.Length; i++)
                outputStrs[i] = outputBuilders[i].ToString();

            return outputStrs;
        }


        /*          V E R S I O N   2           */

        //public static string[] Replace(string[] inputStrs)
        //{
        //    if (inputStrs == null || inputStrs.Contains(null))
        //        throw new ArgumentNullException("Input array was null reference or it contained null reference.");

        //    var outputBuilders = new StringBuilder[inputStrs.Length];
        //    for (int i = 0; i < inputStrs.Length; i++)
        //        outputBuilders[i] = new StringBuilder(inputStrs[i]);

        //    int sharpsCount = 0;
        //    foreach (var str in inputStrs)
        //        sharpsCount += str.Count(x => x == '#');

        //    for (int i = 0, count = 0; count < sharpsCount / 2; i++)
        //        for (int j = 0; j < inputStrs[i].Length; j++)
        //            if (inputStrs[i][j] == '#')
        //            {
        //                outputBuilders[i][j] = '<';
        //                ++count;
        //            }
        //    for (int i = inputStrs.Length - 1, count = 0; count < sharpsCount / 2; --i)
        //        for (int j = inputStrs[i].Length - 1; j >= 0; --j)
        //            if (inputStrs[i][j] == '#')
        //            {
        //                outputBuilders[i][j] = '>';
        //                ++count;
        //            }

        //    var outputStrs = new string[inputStrs.Length];
        //    for (int i = 0; i < outputStrs.Length; i++)
        //        outputStrs[i] = outputBuilders[i].ToString();

        //    return outputStrs;
        //}

        public static string FindName(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr) || string.IsNullOrWhiteSpace(inputStr))
                throw new ArgumentException("Input string is incorrect.");
            int pointIndex = inputStr.LastIndexOf('.');
            int lastSlashIndex = inputStr.LastIndexOf('\\');

            if (pointIndex < 0 || lastSlashIndex < 0)
                throw new FormatException("Input string has incorrect format.");

            return inputStr[(lastSlashIndex + 1)..pointIndex];
        }

        public static string FindRootDirectoryName(string inputStr)
        {
            if (string.IsNullOrEmpty(inputStr) || string.IsNullOrWhiteSpace(inputStr))
                throw new ArgumentException("Input string is incorrect.");

            int firstSlashIndex = inputStr.IndexOf('\\');

            if (firstSlashIndex < 0)
                throw new FormatException("Input string has incorrect format.");

            return inputStr[0..firstSlashIndex];
        }
    }
}

