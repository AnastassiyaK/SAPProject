namespace Core.Configuration
{
    public interface IDriverConfiguration
    {
        int DissapearTime { get; set; }
        string HubUrl { get; set; }
        int TimeOutPageLoad { get; set; }
        int TimeOutSearch { get; set; }
        bool UseGrid { get; set; }
    }
}