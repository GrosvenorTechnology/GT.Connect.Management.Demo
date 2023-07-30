
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
    Task<ApiResponse<AddAssetToDeviceOrNodeResponse>> AddAssetToDeviceOrNode(Guid tenantId, [Body] AddAssetToDeviceOrNodeCommand command);


    [Post("/api/tenants/{tenantId}/device-config/Command/syncSelected")]
    Task<ApiResponse<AddAssetToDeviceOrNodeResponse>> SynchroniseSelectedOnDeviceOrNode (Guid tenantId, 
        [Body] SynchroniseSelectedCommand command);

}


public record SynchroniseSelectedCommand(Guid TenantId, int? NodeId, Guid? DeviceId, int TTL = 6000, 
    Guid[]? Assets = null, Guid[]? Firmwares = null, Guid[]? Applications = null,
    Guid[]? Configs = null, Guid[]? Consents = null);