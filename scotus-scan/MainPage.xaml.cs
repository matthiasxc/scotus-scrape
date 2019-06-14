using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using scotus_scan.ViewModel;

namespace scotus_scan
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

            Loaded += (s, e) =>
            {
                Vm.RunClock();
            };
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Vm.StopClock();
            base.OnNavigatingFrom(e);
        }

        private void MinJusticeList_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            Vm.SelectedMinJustices.Clear();
            foreach (object o in MinJusticeList.SelectedItems)
            {
                if (o is int)
                {
                    // add to list
                    Vm.SelectedMinJustices.Add((int)o);
                }
            }

            // update list
            Vm.FilterScotusCases.Execute(null);
        }

        private void MajJusticeList_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            Vm.SelectedMajJustices.Clear();
            foreach (object o in MajJusticeList.SelectedItems)
            {
                if (o is int)
                {
                    // add to list
                    Vm.SelectedMajJustices.Add((int)o);
                }
            }

            // update list
            Vm.FilterScotusCases.Execute(null);
        }

        private void SliderChangeCompleted(Windows.UI.Xaml.UIElement sender, Windows.UI.Xaml.DropCompletedEventArgs args)
        {
            // update list
            Vm.FilterScotusCases.Execute(null);
        }

        private void SliderValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            // update list
            Vm.FilterScotusCases.Execute(null);
        }
    }
}
