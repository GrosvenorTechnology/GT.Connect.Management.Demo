using Refit;

namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

[Headers("Authorization: Bearer")]
public interface IConnectApiApplicationPackage
{
    //[Get("/api/tenants/{tenantId}/device-config/devices/node/{nodeId}")]
    //Task<ApiResponse<List<Device>>> GetDevices(Guid tenantId, int nodeId, [Query] SeiveQueryParams? qparams = null);

    //[Get("/api/tenants/{tenantId}/device-config/devices/{deviceId}")]
    //Task<Device> GetDevice(Guid tenantId, Guid deviceId);

    //[Post("/api/tenants/{command.TenantId}/device-config/devices")]
    //Task<Device> AddDevice([Body] AddDeviceCommand command);

    //[Put("/api/tenants/{command.TenantId}/device-config/devices/{command.Id}")]
    //Task<Device> UpdateDevice([Body] UpdateDeviceCommand command);

    //[Delete("/api/tenants/{tenantId}/device-config/devices/{deviceId}")]
    //Task RemoveDevice(Guid tenantId, Guid deviceId);


    //[Get("/api/tenants/{tenantId}/device-config/configuration/node/{nodeId}")]
    //Task<ApiResponse<List<DeviceConfiguration>>> GetConfigurationOnNode(Guid tenantId, int nodeId);

    [Post("/api/tenants/{tenantId}/app-package/Storage/asset-url")]
    Task<GetAssetUploadUrlResponse> GetUploadAssetUrl(Guid tenantId, [Body] GetAssetUploadUrlCommand command);

    [Get("/api/tenants/{tenantId}/app-package/Storage/status/{uploadId}")]
    Task<GetUploadStatusResponse> GetUploadStatus(Guid tenantId, Guid uploadId);

    [Get("/api/tenants/{tenantId}/app-package/assets")]
    Task<ApiResponse<List<GetAssetsResponse>>> GetAssets(Guid tenantId);
}

public record GetAssetUploadUrlCommand
(
    Guid TenantId,
    Guid FileTypeId,
    string FileName,
    string DisplayName
);

public record GetAssetUploadUrlResponse
(
    Guid Id,
    string Url
);

public record GetUploadStatusResponse 
(   
    Guid TenantId, 
    string FileName,
    string State,
    string FaultSummary,
    Guid FileTypeId, 
    Guid Id, 
    Guid CreatedById, 
    DateTimeOffset CreatedOn, 
    Guid LastModifiedById, 
    DateTimeOffset LastModifiedOn
);

public record GetAssetsResponse
(
    Guid TenantId,
    string DisplayName,
    string CustomFilename,
    Guid FileTypeId,
    string AssetState,
    long FileSize,
    Guid Id,
    Guid CreatedById,
    DateTimeOffset CreatedOn,
    Guid LastModifiedById,
    DateTimeOffset LastModifiedOn
);