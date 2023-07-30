using GT.Connect.Management.Demo.ConnectApi.DeviceConfig;
using GT.Connect.Management.Demo.ConnectApi.Organisation;
using GT.Connect.Management.Demo.ConnectApi.People;
using GT.Connect.Management.Demo.ConnectApi.Platform;

namespace GT.Connect.Management.Demo;

[Headers("Authorization: Bearer")]
public interface IConnectApi :
    IConnectApiPeople,
    IConnectApiOrganisation,
    IConnectApiPlatform,
    IConnectApiDeviceConfig,
    IConnectApiApplicationPackage
{

}
