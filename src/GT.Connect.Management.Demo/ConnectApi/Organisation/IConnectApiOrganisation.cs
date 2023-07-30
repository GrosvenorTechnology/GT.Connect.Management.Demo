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
}

public enum NodeType
{
    Partner,
    ChannelPartner,
    Company
}
