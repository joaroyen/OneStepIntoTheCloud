using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using JoarOyen.OneStepIntoTheCloud.Core.Service.MovieService;


namespace JoarOyen.OneStepIntotheCloud.SmartClient
{
    public partial class MainWindow
    {
        private const string EndpointConfigurationName = "MovieService";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonRetrieveMoviesClick(object sender, RoutedEventArgs e)
        {
            var movieServiceClient = new MovieServiceClient(EndpointConfigurationName);
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var list1001MoviesToWatchBeforeYouDie = movieServiceClient.List1001MoviesToWatchBeforeYouDie();
                stopwatch.Stop();

                DataContext = list1001MoviesToWatchBeforeYouDie;
                labelDuration.Content = string.Format("Duration: {0} ms", stopwatch.ElapsedMilliseconds);

                movieServiceClient.Close();
            }
            catch (Exception ex)
            {
                movieServiceClient.Abort();
                MessageBox.Show(ex.Message);
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            labelUrl.Content = new MovieServiceClient(EndpointConfigurationName).Endpoint.Address.Uri.ToString();

            Task.Factory.StartNew(ListenToSubscription);
        }

        private static void ListenToSubscription()
        {
            var movieSuggestions = new OneStepIntoTheCloud.Core.ServiceBus.Topic.MovieSuggestions();

            while (true)
            {
                var movie = movieSuggestions.All.Receive();
                if (movie != null)
                {
                    MessageBox.Show(string.Format("{0} ({1})", movie.Title, movie.Year), "New suggestion");
                }
            }
// ReSharper disable FunctionNeverReturns
        }
// ReSharper restore FunctionNeverReturns
    }
}
