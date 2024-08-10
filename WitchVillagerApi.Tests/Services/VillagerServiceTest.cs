using WitchVillagerApi.Village.Services;
using Xunit;

namespace WitchVillagerApi.Tests
{
    public class VillagerServiceTests
    {
        private readonly IVillagerService _service;

        public VillagerServiceTests()
        {
            _service = new VillagerService();
        }

        [Fact]
        public void CalculateAverageKilled_ShouldReturnCorrectAverage()
        {
            int ageOfDeathA = 10;
            int yearOfDeathA = 12;
            int ageOfDeathB = 13;
            int yearOfDeathB = 17;

            double result = _service.CalculateAverageKilled(ageOfDeathA, yearOfDeathA, ageOfDeathB, yearOfDeathB);

            Assert.Equal(4.5, result);
        }

        [Fact]
        public void CalculateAverageKilled_ShouldReturnNegativeOneForInvalidData()
        {
            double result = _service.CalculateAverageKilled(-1, 12, 13, 17);
            Assert.Equal(-1, result);

            result = _service.CalculateAverageKilled(10, 5, 13, 17);
            Assert.Equal(-1, result);
        }
    }
}
