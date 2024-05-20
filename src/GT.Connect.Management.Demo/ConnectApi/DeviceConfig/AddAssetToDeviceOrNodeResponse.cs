namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record AddAssetToDeviceOrNodeResponse
(
    Guid Id,
    Guid TenantId,
    Guid StorageReference,
    Guid? DeviceId,
    int? NodeId,
    string Description,
    string FileAssignmentType,
    Guid CreatedById, 
    DateTimeOffset CreatedOn, 
    Guid LastModifiedById, 
    DateTimeOffset LastModifiedOn
);
