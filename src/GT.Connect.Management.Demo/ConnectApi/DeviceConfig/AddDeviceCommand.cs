namespace GT.Connect.Management.Demo.ConnectApi.DeviceConfig;

public record AddDeviceCommand
(
    Guid TenantId,
    string Name,
    string DeviceFamily,
    string DeviceType,
    string SerialNumber,
    string LegacyKey,
    DateTimeOffset PurchasedDate,
    DateTimeOffset? ValidTo,
    string Features,
    bool IsSubscription,
    bool AzIoTEnabled,
    string PartNumber,
    string BillingReference1,
    string BillingReference2,
    string BillingReference3,
    string? AdditionalField1,
    string? AdditionalField2,
    string? AdditionalField3,
    string? AdditionalField4,
    string? AdditionalField5,
    string? AdditionalField6,
    string? AdditionalField7,
    string? AdditionalField8,
    string? AdditionalField9,
    string? AdditionalField10
) ;
