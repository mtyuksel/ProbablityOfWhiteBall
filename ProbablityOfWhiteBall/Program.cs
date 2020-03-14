using System;

namespace ProbablityOfWhiteBall
{
    class Program
    {
        static void Main(string[] args)   //In this project, 0 is accepted for black balls and 1 for white balls.
        {
            float allConditions = 100000; //Number of experiments carried out
            float whiteConditionsCounter = 0;  //Counter that counts when both cases A and B (A: first ball is white and B: last ball is white) are white. 
            
            for (int t = 0; t < allConditions; t++)   //The experiment is repeated as much as the value of variable allConditions (For now, 100k times).
            {
                var Bags = Helpers.CreateBag();    //Each time the experiment is repeated, the bags are created again with the helper method.
                int firstBall = 0;
                for (int i = 0; i < Bags.Count; i++)
                {
                    for (int j = 0; j < Bags.Count - 1; j++)   //The ball is selected from each bucket and thrown to the next.
                    {
                        var random = new Random();
                        int index = random.Next(Bags[j].Count);
                        int temp = Convert.ToInt32(Bags[j][index]);
                        Bags[j].RemoveAt(index);
                        Bags[j + 1].Add(temp);
                        if (j == 0 && temp == 1)
                        {
                            firstBall = 1;    //The first ball is checked to be white.
                        }
                    }

                    for (int k = Bags.Count - 1; k > 0; k--)   //The balls are thrown back to the next bag from 100.
                    {
                        var random = new Random();
                        int index = random.Next(Bags[k].Count);
                        int temp = Convert.ToInt32(Bags[k][index]);
                        Bags[k].RemoveAt(index);
                        Bags[k - 1].Add(temp);
                    }
                }
                var randomSelect = new Random();
                int lastIndex = randomSelect.Next(Bags[0].Count);
                int lastBall = Convert.ToInt32(Bags[0][lastIndex]);   //A random ball is selected from the first bag.

                if (lastBall == 1 && firstBall == 1)
                {
                    whiteConditionsCounter++;     //The first and last ball white cases are counted here.
                }
                Console.WriteLine("Current Experiment: {0}", t + 1);
            }
            float probablity = whiteConditionsCounter / allConditions;      //Probability is calculated by proportioning the cases where the first and last ball is white to the whole case..
            Console.WriteLine("*******************************Last probablity = {0} *********************************", probablity);
            Console.ReadKey();
        }
    }
}
