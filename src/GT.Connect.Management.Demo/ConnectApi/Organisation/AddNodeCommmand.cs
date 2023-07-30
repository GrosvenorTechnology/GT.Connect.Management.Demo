namespace GT.Connect.Management.Demo.ConnectApi.Organisation;

public record AddNodeCommmand(Guid TenantId, int ParentId, string NodeType, string Name,
    string? AdditionalField1 = null, string? AdditionalField2 = null, string? AdditionalField3 = null, string? AdditionalField4 = null,
    string? AdditionalField5 = null, string? AdditionalField6 = null, string? AdditionalField7 = null, string? AdditionalField8 = null,
    string? AdditionalField9 = null, string? AdditionalField10 = null,
    bool AdditionalField1_IsSecure = false, bool AdditionalField2_IsSecure = false, bool AdditionalField3_IsSecure = false,
    bool AdditionalField4_IsSecure = false, bool AdditionalField5_IsSecure = false, bool AdditionalField6_IsSecure = false,
    bool AdditionalField7_IsSecure = false, bool AdditionalField8_IsSecure = false, bool AdditionalField9_IsSecure = false,
    bool AdditionalField10_IsSecure = false);
