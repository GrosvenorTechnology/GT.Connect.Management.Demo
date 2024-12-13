using GT.Connect.Management.Demo.ConnectApi.DeviceConfig;
using GT.Connect.Management.Demo.ConnectApi.Organisation;
using Riok.Mapperly.Abstractions;

namespace GT.Connect.Management.Demo;

[Mapper]
public partial class MapperClasses
{

    [MapProperty(nameof(Device.AzIoTEnabled), nameof(UpdateDeviceCommand.IsIotEnabled))]
    [MapperIgnoreSource(nameof(Device.NodeId))]
    [MapperIgnoreSource(nameof(Device.NodeType))]
    [MapperIgnoreSource(nameof(Device.DeviceType))]
    [MapperIgnoreSource(nameof(Device.DeviceFamily))]
    [MapperIgnoreSource(nameof(Device.PartNumber))]
    [MapperIgnoreSource(nameof(Device.SerialNumber))]
    [MapperIgnoreSource(nameof(Device.IsSubscription))]
    [MapperIgnoreSource(nameof(Device.DeviceLifecycleState))]
    [MapperIgnoreSource(nameof(Device.Features))]
    [MapperIgnoreSource(nameof(Device.PartnerNodeId))]
    [MapperIgnoreSource(nameof(Device.ChannelPartnerNodeId))]
    [MapperIgnoreSource(nameof(Device.CompanyNodeId))]
    [MapperIgnoreSource(nameof(Device.StructuralNodeId))]
    [MapperIgnoreSource(nameof(Device.PurchaseDate))]
    [MapperIgnoreSource(nameof(Device.ValidTo))]
    public partial UpdateDeviceCommand Map(Device device);


    [MapperIgnoreSource(nameof(NodeResponse.CreatedById))]
    [MapperIgnoreSource(nameof(NodeResponse.CreatedOn))]
    [MapperIgnoreSource(nameof(NodeResponse.LastModifiedById))]
    [MapperIgnoreSource(nameof(NodeResponse.LastModifiedOn))]
    public partial UpdateNodeCommmand Map(NodeResponse device);
}
