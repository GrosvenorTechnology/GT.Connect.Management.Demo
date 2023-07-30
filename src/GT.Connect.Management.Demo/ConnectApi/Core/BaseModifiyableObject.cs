namespace GT.Connect.Management.Demo.ConnectApi.Core;

public abstract record BaseModifiyableObject 
    (Guid Id, Guid CreatedById, DateTimeOffset CreatedOn, Guid LastModifiedById, DateTimeOffset LastModifiedOn);
