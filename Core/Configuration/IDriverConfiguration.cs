namespace Core.Configuration
{
    public interface IDriverConfiguration
    {
        string HubUrl { get; set; }
        int TimeOutSearch { get; set; }
        int DissapearTime { get; set; }
        int TimeOutPageLoad { get; set; }
        bool UseGrid { get; set; }
    }
}