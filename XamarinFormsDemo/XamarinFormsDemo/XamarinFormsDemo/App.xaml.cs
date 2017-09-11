
using Xamarin.Forms;

namespace XamarinFormsDemo
{
    /// <summary>
    /// class App
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new XamarinFormsDemo.MainPage();
        }

        /// <summary>
        /// Called when [start].
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Called when [sleep].
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Called when [resume].
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
