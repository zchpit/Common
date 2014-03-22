using System.IO;

using Zch.Common.Helpers;

using Xunit;

namespace CommonIntTest.Helpers
{
    public class HelperTest
    {
        string filePath = @"c:\dev\response.xml";
        public HelperTest()
        {
            File.Delete(filePath); //we have sure, that this file not exeist
        }
        [Fact]
        public void SerializeToXmlFile_CheckThatFileExists_FileExist()
        {
            File.Delete(filePath); //we have sure, that this file not exeist
            string response = "test response";
            Helper.SerializeToXmlFile(response, filePath);
            Assert.True(File.Exists(filePath));
        }
        [Fact]
        public void SerializeToXmlFile_CheckThatFileContainsText_ContainsText()
        {
            File.Delete(filePath); //we have sure, that this file not exeist
            string response = "test response";
            Helper.SerializeToXmlFile(response, filePath);
            string textInFile = File.ReadAllText(filePath);

            Assert.Contains(response, textInFile);
            Assert.Contains("xml", textInFile);
        }
    }
}
