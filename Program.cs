using System;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            // 변수 선언
            Random rand = new Random();       // 랜덤 객체
            int count = 1000000;              // 전체 시행 횟수
            double percent = 0.01;            // 아이템 확률
            int[] elements = new int[count];  // 아이템을 뽑는 데 필요한 횟수
            double average = 0;               // 평균
            double variance = 0;              // 분산
            double stdDeviation;              // 표준편차
            double min = 0;                   // 최솟값
            double minCount = 0;              // 최솟값이 나온 횟수
            double max = 0;                   // 최댓값
            double maxCount = 0;              // 최댓값이 나온 횟수

            // 시행 반복 및 집계
            for (int i = 0; i < count; i++)
            {
                int trials = 0;
                while (true)
                {
                    trials++;
                    if (rand.NextDouble() <= percent)
                        break;
                }

                elements[i] = trials;
                average += trials;

                if (min == 0 || min > trials)
                {
                    min = trials;
                    minCount = 1;
                }
                else if (min == trials)
                    minCount++;

                if (max == 0 || max < trials)
                {
                    max = trials;
                    maxCount = 1;
                }
                else if (max == trials)
                    maxCount++;
            }

            average /= count;
            for (int i = 0; i < count; i++)
                variance += Math.Pow(elements[i] - average, 2);
            variance /= count;
            stdDeviation = Math.Sqrt(variance);

            // 결과 출력
            Console.WriteLine("시행 횟수: " + count);
            Console.WriteLine("평균: " + average);
            Console.WriteLine("분산: " + variance);
            Console.WriteLine("표준 편차: " + stdDeviation);
            Console.WriteLine("최솟값: " + min + " (" + minCount + ")");
            Console.WriteLine("최댓값: " + max + " (" + maxCount + ")");
            Console.WriteLine();
            Console.WriteLine("구간별 분포:");

            int sum;
            for (int i = 0; i < 4; i++)
            {
                sum = 0;
                for (int j = 0; j < count; j++)
                    if (elements[j] >= 1 + i * 50 && elements[j] <= (i + 1) * 50)
                        sum++;
                Console.WriteLine(1 + i * 50 + " ~ " + (i + 1) * 50 + " : " + (100d * sum / count) + "% (" + sum + ")");
            }
            sum = 0;
            for (int j = 0; j < count; j++)
                if (elements[j] >= 201)
                    sum++;
            Console.WriteLine("201 ~ : " + (100d * sum / count) + "% (" + sum + ")");
        }
    }
}
