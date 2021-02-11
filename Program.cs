﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HackerRank
{
    class Program
    {
        #region "Functions"

        static int minimumSwaps(int[] arr) {
            int swaps=0; 
            List<int> a = arr.ToList();

            Console.WriteLine("Start: {0}", string.Join( ",", arr.ToArray()) );
            
            for (int p=0; p < a.Count-1; p++) {

                if (a[p] != p + 1) {

                    int temp = a[p];
                    int target = a.FindIndex(p+1, x => x == p+1);
                    a[p] = a[target];                                                                   
                    a[target] = temp;
                    swaps++;   
                    Console.WriteLine("[{0}] -> [{1}] => ({2})", p, target, string.Join( ",", a.ToArray()) );        
                }                                   
            }
            return swaps;
        }

        static long arrayManipulation(int n, int[][] queries) {
            var res = new List<int>(new int[n]);
            
            Console.WriteLine("Array: {0}", string.Join(",", res.ToArray()));

            for (int p=0; p < queries.Length; p++) {
                Console.WriteLine("[{0}]-[{1}] / Add: {2}", queries[p][0], queries[p][1], queries[p][2]);

                for (int q=queries[p][0]-1; q<queries[p][1]; q++) {
                    res[q] += queries[p][2];
                }
                Console.WriteLine("queries: {0}", string.Join(",", res.ToArray()));
            }
            
            return res.Max();
        }

        static int missingInteger (int[] A)
        {
            int res = 0;
            int max = 0;
            for (int k=0; k < A.Length; k++) {
                int ind = Array.FindIndex(A, x => x == k+1);
                Console.WriteLine("ind={0}", ind);
                if (ind == -1) {
                    res = k+1;
                    break;
                }
                else {
                    res = k+2;
                }
                    
                if (max < A[k])
                    max = A[k];
                
            }
            if (max ==0)
                    res = 1;
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            return res;
        }

        static int sherlockAndAnagrams(string s) {
            int res = 0;
            if (s.Length > 1 && s.Length <= 100) {
                
                Console.WriteLine("s={0}", s);
                for(int p=1; p < s.Length; p++) {
                    for(int q = 0; q < s.Length - p; q++) {                        
                        var str1 = new string(s.Substring(q, p).OrderBy(x => x).ToArray());                        
                        string s1 = s.Substring(q+1);
                        /*
                        for (int k=0; k < s1.Length - p + 1; k++) {
                            var str2 = s1.Substring(k, p).OrderBy(x => x);                            

                            if (str1.SequenceEqual(str2)) {                                                                          
                                res++;
                                //Console.WriteLine("str1={0} / s1={1} / str2={2} / k={3}", s.Substring(q, p), s1, s1.Substring(k, p), k); 
                            }   
                        }*/
                        var list = new List<string>();
                     
                        for (int k=0; k < s1.Length - p + 1; k++) {
                            var str2 = new string(s1.Substring(k, p).OrderBy(x => x).ToArray());   
                            //Console.WriteLine("str2={0}", s1.Substring(k, p)); 
                            list.Add(str2);
                            //Console.WriteLine("str1={0} / s1={1} / str2={2} / list={3}", s.Substring(q, p), s1, s1.Substring(k, p), list.Count);  
                        }                    
                        res += list.Count(x => x == str1);
                        //Console.WriteLine("count={0}", list.Count(x => x == str1));
                    }                
                }
            }
            return res;
        }

        static string isValid(string s) {
            string res="NO";
            var dict = new Dictionary<char, int>();
            
            for(int k = 0; k < s.Length; k++) {
                if (!dict.ContainsKey(s[k])) {
                    dict.Add(s[k], 1);
                }
                else {
                    dict[s[k]]++;
                }
            }
            
            foreach(KeyValuePair<char, int> item in dict) {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            } 
            
            var diffChar = dict.Keys.Distinct();
            int maxNumber = dict.Values.Max();
            int maxCount = dict.Count(x => x.Value == maxNumber);
            int minNumber = dict.Values.Min();
            int minCount = dict.Count(x => x.Value == minNumber);
            
            Console.WriteLine("diff_Char={0} / maxNumber={1} / maxCount={2} / maxNumber={3} / minCount={4}", diffChar.Count(), maxNumber, maxCount, minNumber, minCount);

            if ( diffChar.Count() - maxCount < 2 || ((maxCount == 1 || minCount == 1 ) && (maxNumber - minNumber <= 1)) ){
                res = "YES";
            }

            return res;
        }

        static long substrCount(int n, string s) {
            int res = n;
            
            for (int p=2; p <= 3; p++) {
                for (int q=0; q < s.Length - p + 1; q++) {
                    string str = s.Substring(q, p);
                                    
                    if (str.PadLeft(str.Length/2).ToList().SequenceEqual(str.PadRight(str.Length/2).Reverse())) {
                        res++;
                        //Console.WriteLine("str={0}", str);
                    }
                }
            }
            return res;
        }

        static long repeatedString(string s, long n) {
            long l = Convert.ToInt32(n / s.Length);
            string s1 = string.Empty;
            for(long k=0; k < l; k++) {
                s1 += s;
            }
            long d = n - s1.Length;
            Console.WriteLine("s1={0} / d={1}", s1, d);

            for (int k=0; k < d; k++) {
                s1 += s[k];
            }
            Console.WriteLine("s1={0}", s1);

            //s1 = s1.Remove(Convert.ToInt32(n), Convert.ToInt32(s1.Length - l));
            
            long r = s1.Count(x => (x == 'a'));

            Console.WriteLine("s={0} / s.Count={1} / #a={2}", s1, s1.Length, r);

            return r;
        }

        static void virusIndices(string p, string v) {
        /*
         * Print the answer for this test case in a single line
         */
         int l = v.Length;
         var res = new List<int>();
         //Console.WriteLine("vo={0}", string.Concat(vo));
         
            for(int k=0; k < p.Length - l +1; k++) {
                bool match = false;
                int n = 0;
                var str = p.Substring(k, l);
                //Console.WriteLine("v={0} / str={1}", v, str);
                
                for (int i=0; i<l; i++) {
                    if (l == 1) {
                        match = true;
                    } 
                    else if (p.Length >= l && str == v) {
                        match = true;
                    }
                    else {
                        if (v[i] == str[i] && str[i] >= 'a' && str[i] <= 'z') {
                            n++;
                            if (n == l - 1) {
                                match = true;
                                break;
                            }
                        }
                    }
                }
                if (match)
                    res.Add(k);
                
            }
            
            if (res.Count > 0)
                Console.WriteLine("{0}", string.Join(" ", res));
            else
                Console.WriteLine("No Match!");            
        }

        static void miniMaxSum(int[] arr) {
            List<long> n = arr.Select(x => (long)x).ToList();
            n = n.OrderBy(x => x).Where(x => x > 0 && x <= 1000000000).ToList();
            long min = (long)(n.Sum() - n.Max());
            long max = n.Sum() - n.Min();
            Console.WriteLine("{0} {1}", min, max);
        }

        static string caesarCipher(string s, int k) {
            var res = new StringBuilder();
            if (s.Length > 0 && s.Length <= 100 && k >= 0 && k <= 100)
            {           
            if (k > 26) 
                    k = k % 26;
                    
                Console.WriteLine("k={0}", k);

                foreach(char chr in s) {     
                    char temp = chr;
                    int i = (int)temp;   
                    if (i >= 65 && i <= 90) {
                        if (i + k > 90) {
                            temp = (char)(i + k - 26);    
                        }
                        else {
                            temp = (char)(i + k);   
                        }
                    }
                    else if (i >= 97 && i <= 122) {
                        if (i + k > 122){
                            temp = (char)(i + k - 26);
                        }
                        else {
                            temp = (char)(i + k);   
                        }
                    }
                    Console.WriteLine("i={0} / chr={1} -> {2}", i, chr, temp);
                                        
                    res.Append(temp);
                }
            }
            return res.ToString();
        }
        
        #endregion
        
        static void Main(string[] args)
        {
            #region "Previous calls"
            /*
            string s="aba";
            long n = 10;
            long r = repeatedString(s, n);            

            Console.WriteLine("string: {0}, n={1} -> Result={2}", s, n, r);
            */
            /*
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\ABorjas\Documents\HackerRank-C#\Source.txt");  
            string p = file.ReadLine();
            //string p = "bababa";
            string v = file.ReadLine();
            virusIndices(p, v);
            */
            /*
            int[] arr = {256741038, 623958417, 467905213, 714532089, 938071625};
            miniMaxSum(arr);
            */
            /*
            string str = "!m-rB`-oN!.W`cLAcVbN/CqSoolII!SImji.!w/`Xu`uZa1TWPRq`uRBtok`xPT`lL-zPTc.BSRIhu..-!.!tcl!-U";
            //string str = "www.abc.xy"; // OOK
            int k = 62;
            Console.WriteLine("{0}", caesarCipher(str, k));
            */
            #endregion

            
        }
    }
}
