namespace GT.Connect.Management.Demo.ConnectApi.People;

public record CompanyResponse(int NodeId, Guid TenantId, Guid Id, string Name,
    Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn);
