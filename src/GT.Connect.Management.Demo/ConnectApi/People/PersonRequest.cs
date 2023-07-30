namespace GT.Connect.Management.Demo.ConnectApi.People;

public record PersonRequest(int NodeId, Guid CompanyId,
    string Firstname, string Surname, string ExternalId, string BadgeCode, string KeyPad, string PinCode,
    string Language, string Roles, string VerifyBy, string DisplayItems, string ExternalRevisionId, string Token);

