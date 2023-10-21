
namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record SynchroniseSelectedCommand(Guid TenantId, int? NodeId, Guid? DeviceId, int TTL = 6000, 
    Guid[]? Assets = null, Guid[]? Firmwares = null, Guid[]? Applications = null,
    Guid[]? Configs = null, Guid[]? Consents = null);