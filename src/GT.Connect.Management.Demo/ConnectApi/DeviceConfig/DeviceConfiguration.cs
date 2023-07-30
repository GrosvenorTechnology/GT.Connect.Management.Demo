namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record DeviceConfiguration (Guid TenantId, Guid Id, Guid FileTypeId, Guid? DeviceId, int? NodeId, string Description, 
    string ConfigurationType, string Data, Guid CreatedById, DateTimeOffset CreatedOn, 
    Guid LastModifiedById, DateTimeOffset LastModifiedOn);
