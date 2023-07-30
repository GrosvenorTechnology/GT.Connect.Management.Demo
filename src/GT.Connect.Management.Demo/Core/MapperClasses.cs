using GT.Connect.Management.Demo.ConnectApi.DeviceConfig;
using Riok.Mapperly.Abstractions;

namespace GT.Connect.Management.Demo;

[Mapper]
public partial class MapperClasses
{

    [MapProperty(nameof(Device.AzIoTEnabled), nameof(UpdateDeviceCommand.IsIotEnabled))]
    public partial UpdateDeviceCommand Map(Device device);
    
}
