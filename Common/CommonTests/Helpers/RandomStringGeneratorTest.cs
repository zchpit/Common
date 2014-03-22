using Zch.Common.Helpers;

using Xunit;

namespace Zch.CommonTests.Helpers
{
    public class RandomStringGeneratorTest
    {
        [Fact]
        public void GetRandomString_Get2RandomStrings_ThereAreDiferent()
        {
            string randomA = RandomStringGenerator.GetRandomString();
            string randomB = RandomStringGenerator.GetRandomString();
            Assert.NotEqual(randomA, randomB);
        }
    }
}
