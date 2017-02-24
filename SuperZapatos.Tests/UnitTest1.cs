using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SuperZapatos.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BasicAuthenticationTest()

        {

            string username = Convert.ToBase64String(Encoding.UTF8.GetBytes("joydip"));

            string password = Convert.ToBase64String(Encoding.UTF8.GetBytes("joydip123"));

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", username + ":" + password);

            var result = client.GetAsync(new Uri("http://localhost/IDG/api/default/")).Result;

            Assert.IsTrue(result.IsSuccessStatusCode);

        }
    }
}
