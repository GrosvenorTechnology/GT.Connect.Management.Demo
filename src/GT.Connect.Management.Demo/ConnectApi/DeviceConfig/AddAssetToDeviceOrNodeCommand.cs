namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record AddAssetToDeviceOrNodeCommand
(
    Guid TenantId,
    Guid StorageReference,
    int? nodeId,
    Guid? DeviceId
);
