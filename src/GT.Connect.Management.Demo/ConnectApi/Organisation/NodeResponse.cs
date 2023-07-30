namespace GT.Connect.Management.Demo.ConnectApi.Organisation;

public record NodeResponse(int? ParentId, Guid TenantId, string NodeType, string Name,
    string? AdditionalField1, string? AdditionalField2, string? AdditionalField3, string? AdditionalField4,
    string? AdditionalField5, string? AdditionalField6, string? AdditionalField7, string? AdditionalField8,
    string? AdditionalField9, string? AdditionalField10,
    bool AdditionalField1_IsSecure, bool AdditionalField2_IsSecure, bool AdditionalField3_IsSecure,
    bool AdditionalField4_IsSecure, bool AdditionalField5_IsSecure, bool AdditionalField6_IsSecure,
    bool AdditionalField7_IsSecure, bool AdditionalField8_IsSecure, bool AdditionalField9_IsSecure,
    bool AdditionalField10_IsSecure,
    int Id, Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedById, DateTimeOffset LastModifiedOn);
