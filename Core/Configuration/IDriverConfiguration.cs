namespace Core.Configuration
{
    public interface IDriverConfiguration
    {
        string HubUrl { get; set; }
        int TimeOutSearch { get; set; }
        bool UseGrid { get; set; }
    }
}