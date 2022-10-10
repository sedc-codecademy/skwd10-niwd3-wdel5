using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SandboxApp.Data
{
    public partial class RestViewModel : ObservableObject
    {
        private readonly RestClientService _restClientService;

        [ObservableProperty]
        private string _resultLabel;

        public RestViewModel()
        {
            _restClientService = new RestClientService();
        }

        [RelayCommand]
        private async Task Get()
        {
            var result = await _restClientService.GetAsync("posts");

            MainThread.BeginInvokeOnMainThread(() =>
            {
                ResultLabel = result;
            });
        }
    }
}
