using MyHome.Interfaces.Domain;

namespace MyHome
{
    public class BaseDomain : IBaseDomain
    {
        public long Id { get; set; }
        public long ClienteAppId { get; set; }
    }
}
