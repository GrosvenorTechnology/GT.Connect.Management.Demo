using GT.Connect.Management.Demo.ConnectApi.Core;
using GT.Connect.Management.Demo.ConnectApi.People;

namespace GT.Connect.Management.Demo.ConnectApi.People;

[Headers("Authorization: Bearer")]
public interface IConnectApiPeople
{
    [Get("/api/tenants/{tenantId}/people/{nodeId}")]
    Task<ApiResponse<List<PersonResponse>>> GetPeople(Guid tenantId, int nodeId);

    [Get("/api/tenants/{tenantId}/people/{nodeId}/person/externalId/{externalId}")]
    Task<ApiResponse<PersonResponse>> GetPersonByExternalId(Guid tenantId, int nodeId, string externalId);

    [Get("/api/tenants/{tenantId}/people/{nodeId}/company")]
    Task<CompanyResponse> GetCompany(Guid tenantId, int nodeId);

    [Get("/api/tenants/{tenantId}/people/company/{companyId}")]
    Task<CompanyResponse> GetCompanyById(Guid tenantId, Guid companyId);
    
    [Get("/api/tenants/{tenantId}/people/{nodeId}/company")]
    Task<CompanyResponse> GetCompanyByNodeId(Guid tenantId, int nodeId);

    [Post("/api/tenants/{tenantId}/people/{nodeId}")]
    Task<PersonResponse> AddPerson(Guid tenantId, int nodeId, [Body] PersonRequest person);
    
    [Get("/api/tenants/{tenantId}/people/{nodeId}")]
    Task<ApiResponse<List<PersonResponse>>> GetPersons(Guid tenantId, int nodeId, [Query] PeopleSeiveQueryParams? qparams = null);

    [Get("/api/tenants/{tenantId}/people/{nodeId}/person/{personId}")]
    Task<PersonResponse> GetPerson(Guid tenantId, int nodeId, Guid personId);

    [Put("/api/tenants/{tenantId}/people/{nodeId}/{personId}")]
    Task<ApiResponse<PersonResponse>> UpdatePerson(Guid tenantId, int nodeId, Guid personId, [Body] PersonRequest person);

    [Delete("/api/tenants/{tenantId}/people/{nodeId}/{personId}")]
    Task<bool> DeletePerson(Guid tenantId, int nodeId, Guid personId);

    [Get("/api/tenants/{tenantId}/people/{nodeId}/clockGroups")]
    Task<ApiResponse<List<ClockGroupResponse>>> GetClockGroups(Guid tenantId, int nodeId);

    [Get("/api/tenants/{tenantId}/people/{nodeId}/clockGroups/externalId/{externalId}")]
    Task<ApiResponse<ClockGroupResponse>> GetClockGroupByExternalId(Guid tenantId, int nodeId, string externalId);

    [Post("/api/tenants/{tenantId}/people/{nodeId}/clockGroups")]
    Task<ClockGroupResponse> AddClockGroup(Guid tenantId, int nodeId, [Body] ClockGroupRequest clockGroup);

    [Post("/api/tenants/{tenantId}/people/{nodeId}/clockGroup/{clockGroupId}/members/{personId}")]
    Task<ApiResponse<BaseModifiyableObject>> AddPersonToClockGroup(Guid tenantId, int nodeId, Guid clockGroupId, Guid personId);

    [Post("/api/tenants/{tenantId}/people/{nodeId}/clockGroup/{clockGroupId}/devices/{deviceId}")]
    Task<ClockGroupResponse> AddDeviceToClockGroup(Guid tenantId, int nodeId, Guid clockGroupId, Guid deviceId);

    [Get("/api/tenants/{tenantId}/people/{nodeId}/clockGroup/{clockGroupId}/members")]
    Task<ApiResponse<Page<PersonResponse>>> GetPeopleInGroup(Guid tenantId, int nodeId, Guid clockGroupId);

    [Get("/api/tenants/{tenantId}/people/{nodeId}/consentAgreements")]
    Task<ApiResponse<ConsentResponse>> GetConsentAgreementsOnCompanyNode(Guid tenantId, int nodeId);

    [Post("/api/tenants/{tenantId}/people/{nodeId}/consentAgreements")]
    Task<ApiResponse<ConsentResponse>> AddConsentAgreementToCompany(Guid tenantId, int nodeId,
        [Body] CreateConsentCommand command);

    [Post("/api/tenants/{tenantId}/people/{nodeId}/ConsentAgreementText")]
    Task<ApiResponse<ConsentAgreementText>> AddConsentTextToAgreement(Guid tenantId, int nodeId,
        [Body] CreateConsentAgreementTextCommand command);

    [Post("/api/tenants/{tenantId}/people/{nodeId}/consentLinks")]
    Task<ActivateConsenttResponse> ActivateConsentOnCompany(Guid tenantId, int nodeId,
        [Body] ActivateConsentCommand command);

    [Delete("/api/tenants/{tenantId}/people/{nodeId}/consentLinks")]
    Task<bool> DeactivateConsentOnCompany(Guid tenantId, int nodeId,
        [Body] DeactivateConsentCommand command);

    [Post("/api/tenants/{tenantId}/people/{nodeId}/command/ReplayTransactions")]
    Task<ApiResponse<string>> ReplayTransactions(Guid tenantId, int nodeId,
        [Body] ReplayTransactionsCommand command);
}

public record ReplayTransactionsCommand(Guid CommandId, Guid TenantId, int NodeId, List<Guid> TransactionIds);

public class PeopleSeiveQueryParams
{
    [AliasAs("Filters")]
    public string? Filters { get; set; }
}

public class Page<TEntity> where TEntity : BaseModifiyableObject
{
    public List<TEntity> Payload { get; set; } = new();
    public int? PreviousPage { get; set; }
    public int? CurrentPage { get; set; }
    public int? NextPage { get; set; }
    public int? PageSize { get; set; }
    public int? TotalPages { get; set; }
    public int TotalItems { get; set; }
}

