using Refit;

namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

[Headers("Authorization: Bearer")]
public interface IConnectApiApplicationPackage
{
    [Post("/api/tenants/{tenantId}/app-package/Storage/asset-url")]
    Task<GetUploadUrlResponse> GetUploadAssetUrl(Guid tenantId, [Body] GetUploadUrlCommand command);

    [Post("/api/tenants/{tenantId}/app-package/Storage/package-url")]
    Task<GetUploadUrlResponse> GetUploadPackageUrl(Guid tenantId, [Body] GetUploadUrlCommand command);

    [Get("/api/tenants/{tenantId}/app-package/Storage/status/{uploadId}")]
    Task<GetUploadStatusResponse> GetUploadStatus(Guid tenantId, Guid uploadId);

    [Get("/api/tenants/{tenantId}/app-package/assets")]
    Task<ApiResponse<List<GetAssetsResponse>>> GetAssets(Guid tenantId);

    [Get("/api/tenants/{tenantId}/app-package/packages")]
    Task<ApiResponse<List<GetPackagesResponse>>> GetPackages(Guid tenantId);

}

public record GetUploadUrlCommand
(
    Guid TenantId,
    Guid FileTypeId,
    string FileName,
    string DisplayName
);

public record GetUploadUrlResponse
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

public record GetPackagesResponse
(
    Guid TenantId,
    Guid PackageGroupId,
    string Version,
    string VersionCode,
    string Publisher,
    string DisplayName,
    Guid FileTypeId,
    string PackageType,
    string PackageName,
    string PackageState,
    string Metadata,
    string Icon,
    long FileSize,
    string SupportedDevices,
    int NodeId,
    Guid Id,
    Guid CreatedById,
    DateTimeOffset CreatedOn,
    Guid LastModifiedById,
    DateTimeOffset LastModifiedOn
);