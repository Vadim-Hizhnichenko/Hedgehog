
public class Program
{
    public static void Main()
    {
         int[] population = new int[] { 4, 1, 4}; 
         int desiredColor = 1; 

        var min = MinimumMeetings(desiredColor, population);

        Console.WriteLine(min);


    }
    public static int MinimumMeetings(int desiredColor, int[] population)
    {
        int currentColor = -1;
        int meetingCount = 0;

        while (true)
        {
            // colors flags
            bool allDesiredColor = true;
            for (int i = 0; i < population.Length; i++)
            {
                if (i != desiredColor && population[i] > 0)
                {
                    allDesiredColor = false;
                    break;
                }
            }

            if (allDesiredColor) { return meetingCount; }

            int max1 = -1, max2 = -1;

            for (int i = 0; i < population.Length; i++)
            {
                if (i == currentColor || i == desiredColor)
                {
                    continue;
                }

                if (population[i] >= max1)
                {
                    max2 = max1;
                    max1 = population[i];
                }
                else if (population[i] > max2)
                {
                    max2 = population[i];
                }
            }

            // if change color is imposible
            if (max1 == 0 && max2 == 0) { return -1; }

            int max = (max1 > 0) ? max1 : max2;

            int maxColor = -1;
            for (int i = 0; i < population.Length; i++)
            {
                if (i == currentColor || i == desiredColor)
                {
                    continue;
                }

                if (population[i] == max)
                {
                    maxColor = i;
                    break;
                }
            }

            // change two colors hedgehog
            population[maxColor]--;
            population[desiredColor]++;
            meetingCount++;

            // save color
            currentColor = maxColor;
        }
    }









}






