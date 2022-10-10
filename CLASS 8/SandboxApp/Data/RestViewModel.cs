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

        [RelayCommand]
        private async Task GetById()
        {
            var result = await _restClientService.GetAsync("posts/1");

            MainThread.BeginInvokeOnMainThread(() =>
            {
                ResultLabel = result;
            });
        }

        [RelayCommand]
        private async Task Post()
        {
            var post = new Post
            {
                UserId = 10,
                Id = 101,
                Title = "My new post",
                Body  = "My new post body"
            };

            var result = await _restClientService.PostAsync("posts", post);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                ResultLabel = result;
            });
        }

        [RelayCommand]
        private async Task Patch()
        {
            var post = new Post
            {
                UserId = 10,
                Id = 1,
                Title = "My updated post",
                Body = "My updated post body"
            };

            var result = await _restClientService.PatchAsync("posts/1", post);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                ResultLabel = result;
            });
        }

        [RelayCommand]
        private async Task Delete()
        {
            var result = await _restClientService.DeleteAsync("posts/2");

            MainThread.BeginInvokeOnMainThread(() =>
            {
                ResultLabel = result;
            });
        }
    }
}
