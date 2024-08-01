using enesens_mobile.Services;

namespace enesens_mobile;

public partial class MainPage : ContentPage
{
    public string Email { get; set; } = "jrcowboy2";
    public string Password { get; set; } = "123456";

    private readonly HttpClient _httpClient;
    private readonly AuthService _authService;

    public MainPage(HttpService httpClient, AuthService authService)
    {
        InitializeComponent();
        BindingContext = this;

        _httpClient = httpClient;
        _authService = authService;
        SetLoadingState(false);
    }

    private async void HandleLogin(object? sender, EventArgs e)
    {
        SetLoadingState(true);
        await _authService.Login(Email, Password);
        await Shell.Current.GoToAsync("//Dashboard");
    }

    private void SetLoadingState(bool isLoading)
    {
        if (isLoading)
        {
            Indicator.IsVisible = true;
            LoginBtn.IsVisible = false;
            EmailEntry.IsEnabled = false;
            PasswordEntry.IsEnabled = false;
        }
        else
        {
            Indicator.IsVisible = false;
            LoginBtn.IsVisible = true;
            EmailEntry.IsEnabled = true;
            PasswordEntry.IsEnabled = true;
        }
    }
}