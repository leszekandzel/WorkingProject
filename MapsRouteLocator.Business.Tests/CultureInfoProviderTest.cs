using NUnit.Framework;
using MapsRouteLocator.Business;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TesCultureInfoProvider_ReturnsCurrentCulture()
        {
            var cultureInfoProvider = new CultureInfoProvider();
            var cultureInfo = cultureInfoProvider.GetCultureInfo();
            Assert.AreEqual(System.Globalization.CultureInfo.CurrentCulture, cultureInfo);
        }
    }
}