using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProbablityOfWhiteBall
{
    public static class Helpers
    {
        public static List<List<int>> CreateBag()  //All bags are created. 
        {
            List<List<int>> allBags = new List<List<int>>();

            for (int i = 2; i < 102; i++)
            {
                List<int> singleBag = new List<int>();
                int counter = i;
                while (counter > 0)
                {
                    singleBag.Add(0);
                    singleBag.Add(1);
                    counter--;
                }
                Shuffle(singleBag);
                allBags.Add(singleBag);
            }
            return allBags;
        }

        public static void Shuffle<T>(this IList<T> list)  //The balls in the bag is mixed..
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
