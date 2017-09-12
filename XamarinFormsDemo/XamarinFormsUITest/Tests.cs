using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinFormsUITest
{
    /// <summary>
    /// Tests class for UI test cases
    /// </summary>
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)] Don't have mac machine so commented iOS
    public class Tests
    {
        IApp app;
        Platform platform;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tests"/> class.
        /// </summary>
        /// <param name="platform">The platform.</param>
        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        /// <summary>
        /// Invokes before the each test.
        /// </summary>
        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        /// <summary>
        /// Positive test case for addition.
        /// </summary>
        [Test]
        public void AdditionPositiveTestCase()
        {
            app.Screenshot("First screen.");
            //var query = app.Query("txtParam1");
            app.EnterText(marked: "txtParam1", text: "10");
            app.EnterText(marked: "txtParam2", text: "20");
            app.Tap(marked: "btnCalculate");
            var appEntryFieldQuery = app.Query(marked: "lblResult");
            var value = appEntryFieldQuery?.FirstOrDefault()?.Text ?? string.Empty;
            Console.Write("Output: " + value);
            Assert.AreEqual("30", value);
        }

        /// <summary>
        /// Negative test case for addition.
        /// </summary>
        [Test]
        public void AdditionNegativeTestCase()
        {
            app.EnterText(marked: "txtParam1", text: "");
            app.EnterText(marked: "txtParam2", text: "-20");
            app.Tap(marked: "btnCalculate");
            var appEntryFieldQuery = app.Query(marked: "lblResult");
            var value = appEntryFieldQuery?.FirstOrDefault()?.Text ?? string.Empty;
            Console.Write("Output: " + value);
            Assert.AreEqual("Invalid input.", value);
        }
    }
}

