namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record AllocateDeviceCommand
(
    Guid Id, //This is deviceId!!
    Guid TenantId,
    int DestinationNodeId
);
