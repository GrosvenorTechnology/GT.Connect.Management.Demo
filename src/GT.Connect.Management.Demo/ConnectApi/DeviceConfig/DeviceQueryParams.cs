
using GT.Connect.Management.Demo.ConnectApi.Core;

namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public class DeviceQueryParams : SieveQueryParams
{
    [AliasAs("getChildren")]
    public bool? GetChildren { get; set; }

    public DeviceQueryParams() : base()
    {

    }

    public DeviceQueryParams(Filter filter) : base(filter)
    {
    }

}

