namespace GT.Connect.Management.Demo.ConnectApi.Organisation;

[Headers("Authorization: Bearer")]
public interface IConnectApiOrganisation
{
    [Get("/api/tenants/{tenantId}/org/nodes")]
    Task<List<NodeResponse>> GetNodes(Guid tenantId, [Query] SieveQueryParams? query = null);

    [Get("/api/tenants/{tenantId}/org/nodes/{nodeId}?walkdown=true&onlyAdjacent=true")]
    Task<List<NodeResponse>> GetNodeAndAllChildren(Guid tenantId, int nodeId);

    [Get("/api/tenants/{tenantId}/org/nodes/{nodeId}?walkdown=false&onlyAdjacent=true")]
    Task<List<NodeResponse>> GetNodeAdjacentNodes(Guid tenantId, int nodeId);

    [Post("/api/tenants/{tenantId}/org/nodes")]
    Task<NodeResponse> AddNode(Guid tenantId, [Body] AddNodeCommmand command);

    [Put("/api/tenants/{tenantId}/org/nodes/{nodeId}")]
    Task<NodeResponse> UpdateNode(Guid tenantId, int nodeId, [Body] UpdateNodeCommmand command);

    [Post("/api/tenants/{tenantId}/org/users/attach")]
    Task<UserResponse> AttachUser(Guid tenantId, int nodeId, [Body] AttachUserRequest command);

    [Post("/api/tenants/{tenantId}/org/users/invite")]
    Task<UserResponse> InviteUser(Guid tenantId, int nodeId, [Body] InviteUserRequest command);

    [Get("/api/tenants/{tenantId}/org/userGroups/node/{nodeId}")]
    Task<List<UserGroupResponse>> GetUserGroupsOnNode(Guid tenantId, int nodeId);

    [Post("/api/tenants/{tenantId}/org/userGroupMembers")]
    Task<UserToUserGroupResponse> AddUserToUserGroup(Guid tenantId, [Body] AddUserToUserGroupRequest command);
}

public enum NodeType
{
    Partner,
    ChannelPartner,
    Company
}

public record AttachUserRequest (Guid TenantId, int NodeId, string Title, string Firstname, string Surname, string Email);
public record InviteUserRequest (Guid TenantId, int NodeId, string Title, string Firstname, string Surname, string Email, string Password);

public record UserResponse(Guid TenantId, int NodeId, string Title, string Firstname, string Surname, string Email,
    bool IsActive, string NodeType, string NodeName, bool MfaEnabled,
    Guid Id, Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn)
    : BaseModifiyableObject(Id, CreatedById, CreatedOn, LastModifiedBy, LastModifiedOn);

public record UserGroupResponse (Guid TenantId, int NodeId, Guid Id, string Name, bool IsSystem, string NodeType, string NodeName,
    Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn)
    : BaseModifiyableObject(Id, CreatedById, CreatedOn, LastModifiedBy, LastModifiedOn);

public record AddUserToUserGroupRequest(Guid TenantId, Guid UserId, Guid UserGroupId);

public record UserToUserGroupResponse (Guid TenantId, Guid SystemUserId, Guid UserGroupId,
    Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedBy, DateTimeOffset LastModifiedOn)
    : BaseObject(CreatedById, CreatedOn, LastModifiedBy, LastModifiedOn);

