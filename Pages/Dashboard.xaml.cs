using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enesens_mobile.Models;
using enesens_mobile.Services;

namespace enesens_mobile.Pages;

public partial class Dashboard : ContentPage
{
    private readonly DashboardService _dashboard;
    public ObservableCollection<CompanyMetric> Metrics { get; set; } = new();
    
    public Dashboard(DashboardService dashboardService)
    {
        InitializeComponent();
        BindingContext = this;
        _dashboard = dashboardService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var x = await _dashboard.GetMetrics();
            Metrics = new ObservableCollection<CompanyMetric>(x);
            Collection.ItemsSource = Metrics;
        });
    }
}