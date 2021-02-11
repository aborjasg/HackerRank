using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HackerRank
{
    class Program
    {
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
        
        static void Main(string[] args)
        {
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
        }
    }
}
