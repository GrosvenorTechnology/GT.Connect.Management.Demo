﻿
namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record Device
(
    Guid Id,
    Guid TenantId,
    int NodeId,
    string NodeType,
    string Name,
    string DeviceFamily,
    string DeviceType,
    string PartNumber,
    string SerialNumber,
    bool IsSubscription,
    bool AzIoTEnabled,
    string DeviceLifecycleState,
    string LegacyKey,
    string Features,
    string? BillingReference1,
    string? BillingReference2,
    string? BillingReference3,
    string? AdditionalField1,
    string? AdditionalField2,
    string? AdditionalField3,
    string? AdditionalField4,
    string? AdditionalField5,
    string? AdditionalField6,
    string? AdditionalField7,
    string? AdditionalField8,
    string? AdditionalField9,
    string? AdditionalField10,
    bool AdditionalField1_IsSecure,
    bool AdditionalField2_IsSecure,
    bool AdditionalField3_IsSecure,
    bool AdditionalField4_IsSecure,
    bool AdditionalField5_IsSecure,
    bool AdditionalField6_IsSecure,
    bool AdditionalField7_IsSecure,
    bool AdditionalField8_IsSecure,
    bool AdditionalField9_IsSecure,
    bool AdditionalField10_IsSecure,
    bool IsEnabled,
    int? PartnerNodeId,
    int? ChannelPartnerNodeId,
    int? CompanyNodeId,
    int? StructuralNodeId,
    string? Tags,
    string? BioFilterTags
    );