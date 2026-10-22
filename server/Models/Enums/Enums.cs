namespace mancs_radar_server.Models
{
    public enum Roles
    {
        User,
        Admin
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
    public enum BreedType
    {
        Purebred,
        Mixed,
        Unknown
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