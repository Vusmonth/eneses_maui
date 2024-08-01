namespace enesens_mobile.Models;

public class CompanyMetric
{
    public int uid { get; set; }
    public int companyId { get; set; }
    public string companyName { get; set; }
    public string unitName { get; set; }
    public string areaName { get; set; }
    public string companyDeviceName { get; set; }
    public string deviceType { get; set; }
    public string deviceSymbol { get; set; }
    public string deviceDescription { get; set; }
    public int positionId { get; set; }
    public float? lastValue { get; set; } = null;
    public string alarmType { get; set; }
    public long lastUpdate { get; set; }
    public string arrayValues { get; set; }
    public string gasName { get; set; }
    public string unitMeterDescription { get; set; }
    public string unitMeterSymbol { get; set; }
    public object positionHistoricViewDto { get; set; }
}