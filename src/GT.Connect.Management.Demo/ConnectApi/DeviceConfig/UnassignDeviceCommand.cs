namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record UnassignDeviceCommand
(
    Guid DeviceId, 
    Guid TenantId
);