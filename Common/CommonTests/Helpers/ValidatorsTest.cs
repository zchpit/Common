using Zch.Common.Helpers;

using Xunit;
using Xunit.Extensions;

namespace Zch.CommonTests.Helpers
{
    public class ValidatorsTest
    {
        Validators validators = null;
        public ValidatorsTest()
        {
            this.validators = new Validators();
        }
        [Fact]
        public void ValidateNip_PositiveNip_True()
        {
            string posotiveNip = "5110258937";
            bool decision = validators.ValidateNip(posotiveNip);
            Assert.Equal(true, decision);
        }
        [Theory]
        [InlineData("51102589")]
        [InlineData("5110258931")]
        [InlineData("51102589372")]
        public void ValidateNip_NegativeNip_False(string negativeNip)
        {
            bool decision = validators.ValidateNip(negativeNip);
            Assert.Equal(false, decision);
        }
        [Fact]
        public void ValidateNip_EmptyNip_False()
        {
            string negativeNip = "";
            bool decision = validators.ValidateNip(negativeNip);
            Assert.Equal(false, decision);
        }
        [Fact]
        public void ValidateDO_PositiveDO_True()
        {
            string positiveDo = "ATS717721";
            bool decision = validators.ValidateDO(ref positiveDo, true);
            Assert.Equal(true, decision);
        }
        [Fact]
        public void ValidateDO_NegativeDO_False()
        {
            string positiveDo = "ATS717727";
            bool decision = validators.ValidateDO(ref positiveDo, true);
            Assert.Equal(false, decision);
        }
        [Fact]
        public void ValidateDO_EmptyDO_False()
        {
            string positiveDo = "";
            bool decision = validators.ValidateDO(ref positiveDo, true);
            Assert.Equal(false, decision);
        }
        [Theory]
        [InlineData("85073115891")]
        [InlineData("01210421917")]
        public void ValidatePesel_PositivePesel_True(string positivePesel)
        {
            bool decision = validators.ValidatePesel(ref positivePesel);
            Assert.Equal(true, decision);
        }
        [Theory]
        [InlineData("850731158911")]
        [InlineData("8507311589")]
        [InlineData("08242015892")]
        public void ValidatePesel_NegativePesel_False(string positivePesel)
        {
            bool decision = validators.ValidatePesel(ref positivePesel);
            Assert.Equal(false, decision);
        }
        [Fact]
        public void ValidatePesel_EmptyPesel_False()
        {
            string positivePesel = "";
            bool decision = validators.ValidatePesel(ref positivePesel);
            Assert.Equal(false, decision);
        }
        [Theory]
        [InlineData("PL46106014195470")]
        [InlineData("PL501060549140253596757294451827")]
        public void IsIbanChecksumValid_PositiveIBAN_True(string positiveIBAN)
        {
            bool decision = validators.IsIbanChecksumValid(positiveIBAN);
            Assert.Equal(true, decision);
        }
        [Fact]
        public void IsIbanChecksumValid_EmptyIBAN_False()
        {
            string positiveIBAN = "";
            bool decision = validators.IsIbanChecksumValid(positiveIBAN);
            Assert.Equal(false, decision);
        }
        [Theory]
        [InlineData("PL4610601419547")]
        [InlineData("PL461060141954701")]
        [InlineData("PL50106054914025359675729445182")]
        [InlineData("PL5010605491402535967572944518271")]
        public void IsIbanChecksumValid_NegativeIBAN_False(string negativeIBAN)
        {
            bool decision = validators.IsIbanChecksumValid(negativeIBAN);
            Assert.Equal(false, decision);
        }
        [Theory]
        [InlineData("618779019")]
        [InlineData("91441933214996")]
        public void ValidateRegon_PositiveRegon_True(string positiveRegon)
        {
            bool decision = validators.ValidateRegon(ref positiveRegon);
            Assert.Equal(true, decision);
        }
        [Fact]
        public void ValidateRegon_EmptyRegon_False()
        {
            string positiveRegon = "";
            bool decision = validators.ValidateRegon(ref positiveRegon);
            Assert.Equal(false, decision);
        }
        [Theory]
        [InlineData("618779018")]
        [InlineData("61877901")]
        [InlineData("6187790191")]
        [InlineData("91441933214997")]
        [InlineData("9144193321499")]
        [InlineData("914419332149962")]
        public void ValidateRegon_NegativeRegon_False(string positiveRegon)
        {
            bool decision = validators.ValidateRegon(ref positiveRegon);
            Assert.Equal(false, decision);
        }
    }
}
