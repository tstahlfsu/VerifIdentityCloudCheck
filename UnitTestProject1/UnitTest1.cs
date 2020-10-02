using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string key = "lj5YozlG6cv7mm6c";
            string secret = "Ur7znqOTM1KuQw2gXBt0ShDqQcHVGsAq";
            string nonce = "1";
            string timestamp = "1353987581461";
            string data = "{\"details\":{\"address\":{\"suburb\":\"Hillsborough\",\"street\":\"27 Indira Lane\",\"postcode\":\"8022\",\"city\":\"Christchurch\"},\"name\":{\"given\":\"Cooper\",\"middle\":\"John\",\"family\":\"Down\"},\"dateofbirth\":\"1978-01-10\"},\"consent\":\"Yes\"}";
            // The API call path.
            string path = "/verify/";

            var sut = new VerifIdentityCloudCheck.Steps.VerifIdentityRequestSigniture().RequestSigniture(key, secret, nonce, timestamp, data, path);
            var checkcode = "53ccc8563d21393bbac5a5a693e0ba7cc408f83dfb04008122510eee9e80aa86";
            Assert.AreEqual(checkcode, sut);
        }
    }
}
