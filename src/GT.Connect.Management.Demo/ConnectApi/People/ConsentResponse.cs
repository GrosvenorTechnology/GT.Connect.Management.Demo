namespace GT.Connect.Management.Demo.ConnectApi.People;

public record ActivateConsentCommand(int NodeId, Guid ConsentAgreementId);

public record ActivateConsenttResponse(Guid TenantId, int NodeId, Guid Id, Guid ConsentAgreementId,
    string Description, Guid CredentialTypeId, int DurationFor, int StartWarningBeforeExpire,
    List<ConsentSummaryDetail> DonsentDetails,
    Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn);

public record DeactivateConsentCommand(int NodeId, Guid ConsentLinkId);

public record ConsentSummaryDetail(string ConsentText, string Language);

public record CreateConsentCommand(Guid TenantId, int NodeId, Guid CompanyId, string Description,
    Guid CredentialTypeId, int DurationFor, int StartWarningBeforeExpire, uint Version);

public record CreateConsentAgreementTextCommand(Guid TenantId, int NodeId, Guid ConsentAgreementId, 
    string Description, string Language, string ConsentText);


public record ConsentResponse(Guid TenantId, int NodeId, Guid CompanyId, Guid Id, string Description,
    Guid CredentialTypeId, int DurationFor, int StartWarningBeforeExpire, uint Version,
    List<ConsentAgreementText> ConsentAgreementsText,
    Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn);

public record ConsentAgreementText(Guid TenantId, Guid Id, Guid ConsentAgreementId, string Description,
    string Language, string ConsentText,
    Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn);