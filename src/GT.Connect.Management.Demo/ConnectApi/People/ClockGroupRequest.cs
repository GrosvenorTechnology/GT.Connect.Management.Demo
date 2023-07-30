namespace GT.Connect.Management.Demo.ConnectApi.People;

public record ClockGroupRequest(Guid TenantId, int NodeId, Guid CompanyId,
    string ExternalId, string Name, string Tags);
