namespace enesens_mobile.Models;

public class DefaultResponse<T>
{
    public string message { get; set; }
    public string systemMessage { get; set; }
    public long serverDate { get; set; }
    public bool isError { get; set; }
    public List<T> list { get; set; }
    public object t { get; set; }
    public string resultType { get; set; }
}