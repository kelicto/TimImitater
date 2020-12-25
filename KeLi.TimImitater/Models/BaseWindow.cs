using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace KeLi.TimImitater.Models
{
    public class BaseWindow : Window
    {
        public BaseWindow()
        {
            SetupUnhandledExceptionHandling();
        }

        private void SetupUnhandledExceptionHandling()
        {
            // Catchs exceptions from all threads in the AppDomain.
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                ShowUnhandledException(args.ExceptionObject as Exception, "AppDomain.CurrentDomain.UnhandledException", false);

            // Catchs exceptions from each AppDomain that uses a task scheduler for async operations.
            TaskScheduler.UnobservedTaskException += (sender, args) =>
                ShowUnhandledException(args.Exception, "TaskScheduler.UnobservedTaskException", false);

            // Catchs exceptions from a single specific UI dispatcher thread.
            Dispatcher.UnhandledException += (sender, args) =>
            {
                // If we are debugging, let Visual Studio handle the exception and take us to the code that threw it.
                if (!Debugger.IsAttached)
                    return;

                args.Handled = true;
                ShowUnhandledException(args.Exception, "Dispatcher.UnhandledException", true);
            };

            var application = Application.Current;

            if (application != null)
            {
                // Catchs exceptions from the main UI dispatcher thread.
                // Typically we only need to catch this OR the Dispatcher.UnhandledException.
                // Handling both can result in the exception getting handled twice.
                application.DispatcherUnhandledException += (sender, args) =>
                {
                    // If we are debugging, let Visual Studio handle the exception and take us to the code that threw it.
                    if (!Debugger.IsAttached)
                        return;

                    args.Handled = true;
                    ShowUnhandledException(args.Exception, "Application.Current.DispatcherUnhandledException", true);
                };
            }
        }

        private void ShowUnhandledException(Exception exception, string exceptionType, bool promptUserForShutdown)
        {
            var title = $"Unexpected Error Occurred: {exceptionType}";
            var message = $"The following exception occurred:\n\n{exception}";
            var buttons = MessageBoxButton.OK;

            if (promptUserForShutdown)
            {
                message += "\n\nNormally the app would die now. Should we let it die?";
                buttons = MessageBoxButton.YesNo;
            }

            // Let the user decide if the app should die or not (if applicable).
            if (MessageBox.Show(message, title, buttons) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
