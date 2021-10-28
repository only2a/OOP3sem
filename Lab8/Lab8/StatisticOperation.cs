﻿using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab8
{
    static class StatisticOperation
    {
        public static int Sum(this LinkedList<string> list)
        {
            int sum = 0;
            string test = list.ToString();
            var strArr = test.Split(" ");
            for (int i = 0; i < strArr.Count(); i++)
            {
                int len = strArr[i].Length;
                sum = sum + len;
            }

            return sum;
        }

        public static char LastNumb(this LinkedList<string> list)
        {
            char numb = '\0';
            string test = list.ToString();
            var strArr = test.Split(" ");
            for (int i = 0; i < strArr.Count(); i++)
            {
                var strArr2 = strArr[i];
                for (int j = 0; j < strArr2.Count(); j++)
                {
                    if (strArr2[j] >= '0' && strArr2[j] <= '9') numb = strArr2[j];
                }
            }

            return numb;
        }

        public static int Difference(this LinkedList<string> list)
        {
            string test = list.ToString();
            string[] strArr = test.Split(" ");
            string[] strArr2 = new string[strArr.Length - 1];
            Array.Copy(strArr, strArr2, strArr.Length - 1);


            var max = strArr2[0]; var min = strArr2[0];
            for (int i = 0; i < strArr2.Length; i++)
            {
                if (min.Length > strArr2[i].Length) min = strArr2[i];
                if (max.Length < strArr2[i].Length) max = strArr2[i];

            }

            return max.Length - min.Length;
        }


        //public static LinkedList<string> Reverse(this LinkedList<string> list)
        //{

        //    string test = list.ToString();
        //    var strArr = test.Split(" ");
        //    string[] strArr2 = new string[strArr.Length - 1];
        //    Array.Copy(strArr, strArr2, strArr.Length - 1);
        //    LinkedList<string> list0 = new LinkedList<string>();
        //    for (int i = strArr2.Length-1;  i >-1; i--)
        //    {

        //        var temp = strArr2[i];
        //        //strArr2[i] = null;
        //        list0.AddBack(temp) ;
        //    }



        //    return list0;
        //} 

        public static int CountOfS(this LinkedList<string> list)
        {
            string test = list.ToString();
            var strArr = test.Split(" ");
            return strArr.Count() - 1;
        }
        //public static string CutStr(this string str, int len)
        //{
        //    str.Substring(len);
        //    return str;
        //}

    }
}
