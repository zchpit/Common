using Zch.Common.Helpers;

using Xunit;
using Xunit.Extensions;

namespace Zch.CommonTests.Helpers
{
    public class HelperTest
    {
        Helper helper = null;
        public HelperTest()
        {
            this.helper = new Helper();
        }
        [Fact]
        public void Strip_StringWithJavascriptTag_StringWithoutJavascriptTag()
        {
            string  javascriptAlert = @"<script type='text/javascript'>
                                        alert('Hello\nHow are you?');
                                        </script>";
            string witoutJavasritp = Helper.Strip(javascriptAlert);
            Assert.DoesNotContain("<script type='text/javascript'>", witoutJavasritp);
        }
        [Fact]
        public void Strip_StringWithJavascriptTag_ContainsOtherStringWithNojavascript()
        {
            string javascriptAlert = @" Something we test
                                        <script type='text/javascript'>
                                        alert('Hello\nHow are you?');
                                        </script>
                                        ";
            string witoutJavasritp = Helper.Strip(javascriptAlert);
            Assert.Contains("Something we test", witoutJavasritp);
        }
        [Fact]
        public void Strip_StringWithJavascriptTag_ContainsOtherStringWithNojavascript2()
        {
            string javascriptAlert = @" 
                                        <script type='text/javascript'>
                                        alert('Hello\nHow are you?');
                                        </script>
                                        Other test string
                                        ";
            string witoutJavasritp = Helper.Strip(javascriptAlert);
            Assert.Contains("Other test string", witoutJavasritp);
        }
        [Theory]
        [InlineData("ds23sds")]
        [InlineData("511..025")]
        [InlineData("5110-372")]
        [InlineData("51,323")]
        [InlineData("51.312")]
        public void IsNumber_StringNN_NotNumber(string notNumber)
        {
            bool isNumber = Helper.IsNumber(notNumber);
            Assert.False(isNumber);
        }
        [Theory]
        [InlineData("5110")]
        [InlineData("0")]
        [InlineData("-3")]
        public void IsNumber_StringIN_IsNumber(string aNumber)
        {
            bool isNumber = Helper.IsNumber(aNumber);
            Assert.True(isNumber);
        }
    }
}
