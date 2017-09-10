using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinFormsUITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)] Don't have mac machine so commented iOS
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AdditionPositiveTestCase()
        {
            app.Screenshot("First screen.");
            //var query = app.Query("txtParam1");
            app.EnterText(marked: "txtParam1", text: "10");
            app.EnterText(marked: "txtParam2", text: "20");
            app.Tap(marked: "btnCalculate");
            var appEntryFieldQuery = app.Query(marked: "txtResult");
            var value = appEntryFieldQuery?.FirstOrDefault()?.Text ?? string.Empty;
            Console.Write("Output: " + value);
            Assert.AreEqual("30", value);
        }
    }
}

