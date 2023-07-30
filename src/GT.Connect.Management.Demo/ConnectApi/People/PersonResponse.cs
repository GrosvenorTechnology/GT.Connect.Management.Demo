using GT.Connect.Management.Demo.ConnectApi.Core;

namespace GT.Connect.Management.Demo.ConnectApi.People;

public record PersonResponse (Guid CompanyId, Guid TenantId, int NodeId, Guid Id,
    string Firstname, string Surname, string ExternalId, string BadgeCode, string KeyPad, string PinCode,
    string Language, string Roles, string VerifyBy, bool IsDeleted, string ExternalRevisionId, string Token,
    Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn) 
    : BaseModifiyableObject (Id, CreatedById, CreatedOn, LastModifiedBy, LastModifiedOn);
