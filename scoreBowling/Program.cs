namespace scoreBowling
{
    internal class Program
    {
        public static int specialScore(int throwFirst, int throwSecond)
        {
            if (throwFirst == 10)
            {
                return 12;
            }
            else if (throwFirst + throwSecond == 10)
            {
                return 11;
            }
            else
            {
                return throwFirst + throwSecond;
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();

            bool strike = false;
            bool spare = false;

            int finalScore = 0;
            List<int> score = new List<int>();
            List<int> temporaryScore = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"##### JET N°{i} #####");
                int throwFirst = random.Next(0,11);
                Console.WriteLine($"Jet un : {throwFirst}");
                int throwSecond = random.Next(0,(11-throwFirst));
                Console.WriteLine($"Jet deux : {throwSecond}");


                if (strike)
                {
                    if (throwFirst != 10)
                    {
                        strike = false;
                        temporaryScore[i - 1] += throwFirst + throwSecond;
                    }
                    else
                    {
                        temporaryScore[i - 1] += throwFirst;
                    }
                    if (i >= 2 && score[i -2] == -2 && score[i-1]==-2)
                    {
                        temporaryScore[i - 2] += throwFirst;
                    }
                    
                }
                if (spare)
                {
                    temporaryScore[i - 1] += throwFirst;
                    spare = false;
                }

                if (specialScore(throwFirst, throwSecond) == 12)
                {
                    strike = true;
                    temporaryScore.Add(10);
                    score.Add(-2);
                }
                else if (specialScore(throwFirst, throwSecond) == 11)
                {
                    spare = true;
                    temporaryScore.Add(10);
                    score.Add(-1);
                }
                else
                {
                    temporaryScore.Add(00);
                    score.Add(specialScore(throwFirst, throwSecond));
                }
                if (i==9 && specialScore(throwFirst, throwSecond) > 10)
                {
                    int throwThird = random.Next(0, 11);
                    Console.WriteLine($"TROISIEME JET = {throwThird}");
                    //temporaryScore[i] = throwThird;
                    if (throwThird == 10 && specialScore(throwFirst,throwSecond) == 12)
                    {
                        temporaryScore[i] = 30;
                    }
                    else if (specialScore(throwFirst,throwSecond) == 11)
                    {
                        temporaryScore[i] += throwThird;
                    }
                    else 
                    { 
                        temporaryScore[i] = throwThird; 
                    }
                    if (score[i - 2] == -2 && score[i - 1] == -2)
                    {
                        temporaryScore[i-1] += 10;
                    }
                }
                Console.WriteLine(score[i]);
                if (score[i] >= 0)
                {
                    finalScore += score[i];
                    Console.WriteLine($"%%%%{finalScore}%%%%");
                } 
                else
                {
                    Console.WriteLine("////");
                }
            }
            ////AFFICHAGE DEBUG
            foreach (int point in score)
            {
                Console.Write(point + " # ");
            }
            Console.WriteLine();

            for (int i = 0; i < score.Count; i++)
            {
                if (score[i] < 0)
                {
                    score[i] = temporaryScore[i];
                }
                finalScore += score[i];
                Console.Write(score[i] + " - ");

            }
            Console.WriteLine();
            foreach (int i in temporaryScore)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
            Console.WriteLine(finalScore);
        }
    }
}
