using System.ComponentModel;
using System.Globalization;
using MapsRouteLocator.Interfaces;
using Moq;
using NUnit.Framework;


namespace MapsRouteLocator.Business.Tests
{
    public class GoogleLanguageDetectorTest
    {
        [Test]
        public void CurrentCultureInfoNotEnNotDeNotPL_ReturnsCorrectGoogleLanguage()
        {
            Mock<IContainer> mockContainer = new Mock<IContainer>();
            var mockCultureInfoProvider = new Mock<ICultureInfoProvider>();
            var googleLanguageDetector = new GoogleLanguageDetector(mockCultureInfoProvider.Object);

            mockCultureInfoProvider.Setup(c => c.GetCultureInfo()).Returns(new CultureInfo("gd-GB"));
            var googleLanguageExpectedEn = googleLanguageDetector.GetGoogleLanguage();
            Assert.AreEqual(googleLanguageExpectedEn.Code, "en");
            Assert.AreEqual(googleLanguageExpectedEn.Name, "English");

            mockCultureInfoProvider.Setup(c => c.GetCultureInfo()).Returns(new CultureInfo("de-DE"));
            var googleLanguageExpectedDe = googleLanguageDetector.GetGoogleLanguage();
            Assert.AreEqual(googleLanguageExpectedDe.Code, "de");
            Assert.AreEqual(googleLanguageExpectedDe.Name, "German");

            mockCultureInfoProvider.Setup(c => c.GetCultureInfo()).Returns(new CultureInfo("fr-CH"));
            var googleLanguageExpectedFr = googleLanguageDetector.GetGoogleLanguage();
            Assert.AreEqual(googleLanguageExpectedFr.Code, "fr");
            Assert.AreEqual(googleLanguageExpectedFr.Name, "French");

            mockCultureInfoProvider.Setup(c => c.GetCultureInfo()).Returns(new CultureInfo("pl-PL"));
            var googleLanguageExpectedPl = googleLanguageDetector.GetGoogleLanguage();
            Assert.AreEqual(googleLanguageExpectedPl.Code, "pl");
            Assert.AreEqual(googleLanguageExpectedPl.Name, "Polish");

            mockCultureInfoProvider.Setup(c => c.GetCultureInfo()).Returns(new CultureInfo("es-UY"));
            var googleLanguageExpectedDefault = googleLanguageDetector.GetGoogleLanguage();
            Assert.AreEqual(googleLanguageExpectedDefault.Code, "en");
            Assert.AreEqual(googleLanguageExpectedDefault.Name, "English");
        }
    }
}
