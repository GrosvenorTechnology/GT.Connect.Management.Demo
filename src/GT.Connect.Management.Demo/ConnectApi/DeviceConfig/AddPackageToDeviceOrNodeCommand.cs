
namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record AddPackageToDeviceOrNodeCommand
(
    Guid TenantId,
    Guid StorageReference,
    int? NodeId,
    Guid? DeviceId,
    string Description,
    Guid FileTypeId
);
