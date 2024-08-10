namespace WitchVillagerApi.Village.Services
{
    public class VillagerService : IVillagerService
    {
        public double CalculateAverageKilled(int ageOfDeathA, int yearOfDeathA, int ageOfDeathB, int yearOfDeathB)
        {
            if (ageOfDeathA < 0 || ageOfDeathB < 0)
            {
                return -1;
            }

            int yearOfBirthA = yearOfDeathA - ageOfDeathA;
            int yearOfBirthB = yearOfDeathB - ageOfDeathB;

            if (yearOfBirthA < 1 || yearOfBirthB < 1)
            {
                return -1;
            }

            int killedInYearA = CalculateVillagersKilled(yearOfBirthA);
            int killedInYearB = CalculateVillagersKilled(yearOfBirthB);

            double averageKilled = (killedInYearA + killedInYearB) / 2.0;

            return averageKilled;
        }

        private int CalculateVillagersKilled(int year)
        {
            int villagersKilled = 0;
            int previous = 0;
            int current = 1;

            for (int i = 1; i <= year; i++)
            {
                villagersKilled += current;
                int next = previous + current;
                previous = current;
                current = next;
            }

            return villagersKilled;
        }
    }
}
