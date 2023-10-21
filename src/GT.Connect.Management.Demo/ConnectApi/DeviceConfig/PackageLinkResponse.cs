
namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record PackageLinkResponse
(
    Guid TenantId,
    Guid StorageReference,
    Guid FileTypeId,
    Guid? DeviceId,
    int? NodeId,
    string Description,
    string FileAssignmentType,
    Guid Id,
    Guid CreatedById,
    DateTimeOffset CreatedOn,
    Guid LastModifiedById,
    DateTimeOffset LastModifiedOn
);
