namespace MyHome.Interfaces.Domain
{
    public interface IBaseDomain
    {
        long Id { get; set; }
        long ClienteAppId { get; set; }
    }
}
