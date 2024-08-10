namespace WitchVillagerApi.Village.Services
{
    public interface IVillagerService
    {
        double CalculateAverageKilled(int ageOfDeathA, int yearOfDeathA, int ageOfDeathB, int yearOfDeathB);
    }
}
