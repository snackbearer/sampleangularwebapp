using System;
using Xunit;

namespace sampledatatest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var data = new sampledata.Data.Products();

            var products = data.GetProducts();

            Assert.NotEmpty(products);

        }
    }
}