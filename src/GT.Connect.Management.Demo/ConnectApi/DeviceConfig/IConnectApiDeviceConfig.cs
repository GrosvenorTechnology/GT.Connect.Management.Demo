
namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

[Headers("Authorization: Bearer")]
public interface IConnectApiDeviceConfig
{
    [Get("/api/tenants/{tenantId}/device-config/devices/node/{nodeId}")]
    Task<ApiResponse<List<Device>>> GetDevices(Guid tenantId, int nodeId, [Query] DeviceQueryParams? qparams = null);

    [Get("/api/tenants/{tenantId}/device-config/devices/{deviceId}")]
    Task<Device> GetDevice(Guid tenantId, Guid deviceId);

    [Post("/api/tenants/{command.TenantId}/device-config/devices")]
    Task<Device> AddDevice([Body] AddDeviceCommand command);

    [Put("/api/tenants/{command.TenantId}/device-config/devices/{command.Id}")]
    Task<Device> UpdateDevice([Body] UpdateDeviceCommand command);

    [Delete("/api/tenants/{tenantId}/device-config/devices/{deviceId}")]
    Task RemoveDevice(Guid tenantId, Guid deviceId);

    [Put("/api/tenants/{tenantId}/device-config/devices/{deviceId}/assign")]
    Task<Device> AssignDevice(Guid tenantId, Guid deviceId, [Body] AllocateDeviceCommand command);

    [Put("/api/tenants/{tenantId}/device-config/devices/{deviceId}/unassign")]
    Task<Device> UnassignDevice(Guid tenantId, Guid deviceId, [Body] UnassignDeviceCommand command);

    [Put("/api/tenants/{tenantId}/device-config/devices/{deviceId}/pool")]
    Task<Device> AllocateUnassignedDevice(Guid tenantId, Guid deviceId, [Body] AllocateDeviceCommand command);

    [Get("/api/tenants/{tenantId}/device-config/configuration/node/{nodeId}")]
    Task<ApiResponse<List<DeviceConfiguration>>> GetConfigurationOnNode(Guid tenantId, int nodeId);

    [Get("/api/tenants/{tenantId}/device-config/configuration/device/{deviceId}")]
    Task<ApiResponse<List<DeviceConfiguration>>> GetConfigurationOnDevice(Guid tenantId, Guid deviceId);

    [Post("/api/tenants/{tenantId}/device-config/configuration")]
    Task<DeviceConfiguration> AddConfigurationToNodeOrDevice(Guid tenantId, [Body] AddConfigurationCommand command);

    [Put("/api/tenants/{tenantId}/device-config/configuration/{configurationId}")]
    Task<DeviceConfiguration> UpdateConfiguration(Guid tenantId, Guid configurationId, [Body] UpdateConfigurationCommand command);

    [Post("/api/tenants/{tenantId}/device-config/assetLink")]
    Task<AddAssetToDeviceOrNodeResponse> AddAssetToDeviceOrNode(Guid tenantId, [Body] AddAssetToDeviceOrNodeCommand command);

    [Post("/api/tenants/{tenantId}/device-config/Command/syncSelected")]
    Task<ApiResponse<string>> SynchroniseSelectedOnDeviceOrNode (Guid tenantId,
        [Body] SynchroniseSelectedCommand command);  //Not there is no response body of this command

    [Get("/api/tenants/{tenantId}/device-config/package/device/{deviceId}")]
    Task<List<PackageLinkResponse>> GetPackagesOnDevice(Guid tenantId, Guid deviceId);

    [Get("/api/tenants/{tenantId}/device-config/package/node/{nodeId}")]
    Task<List<PackageLinkResponse>> GetPackagesOnNode(Guid tenantId, int nodeId);

    [Post("/api/tenants/{tenantId}/device-config/package")]
    Task<PackageLinkResponse> AddPackageToDeviceOrNode(Guid tenantId, [Body] AddPackageToDeviceOrNodeCommand command);
    
    [Delete("/api/tenants/{tenantId}/device-config/package/{packageId}")]
    Task<List<PackageLinkResponse>> DeletePackageLink(Guid tenantId, Guid packageId);

    [Post("/api/tenants/{tenantId}/device-config/Command/structuredFirmwareCommand/{deviceId}")]
    Task<ApiResponse<bool>> SendStructuredFirmwareCommand(Guid tenantId, Guid deviceId,
        [Body] StructuredCommand command);



}



public class StructuredCommand
{
    public Guid MessageId { get; } = Guid.NewGuid();
    public Guid CorrelationId { get; init; } = Guid.NewGuid();
    public Guid? PreviousMessageId { get; init; } 
    public DateTimeOffset TimeStamp { get; init; } = DateTimeOffset.UtcNow;
    public TimeSpan Ttl { get; init; } = TimeSpan.FromMinutes(5);
    public required string Entity { get; init; }
    public required string CommandName { get; init; }
    public Dictionary<string, string> Parameters { get; init; } = new Dictionary<string, string>();
    public string RequestingEntity { get; init; } = "GtConnect:1";
    public string PermissionedEntity { get; init; } = "";
}