namespace mancs_radar_server.Models
{
    public enum LocationStyle
    {
        Rooftop,
        Street,
        City,
        ManualPin
    }

    public enum DogSex
    {
        Male,
        Female,
        Unknown
    }

    public enum DogSize
    {
        Small,
        Medium,
        Large
    }

    public enum ReportType
    {
        Lost,
        Found
    }

    public enum ReportStatus
    {
        Active,
        Reunited,
        Closed
    }
}