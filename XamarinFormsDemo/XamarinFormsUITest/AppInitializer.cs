using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinFormsUITest
{
    /// <summary>
    /// class AppInitializer
    /// </summary>
    public class AppInitializer
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="platform">The platform.</param>
        /// <returns></returns>
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                FileInfo fi = new FileInfo(currentFile);
                string dir = fi.Directory.Parent.Parent.Parent.FullName;
                Console.Write("DIR: " + dir);
                var pathToAPK = Path.Combine(dir, "XamarinFormsDemo", "XamarinFormsDemo.Android", "bin", "Release", "XamarinFormsDemo.Android.apk");
                Console.Write("PathToAPK: " + pathToAPK);
                return ConfigureApp
                    .Android.ApkFile(pathToAPK)
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

