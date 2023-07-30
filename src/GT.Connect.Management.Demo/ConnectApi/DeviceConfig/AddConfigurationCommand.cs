namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record AddConfigurationCommand(Guid TenantId, int? nodeId, Guid? DeviceId, string Description, Guid FileTypeId, string Data);

public record UpdateConfigurationCommand(Guid TenantId, string Description, string Data);