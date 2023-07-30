namespace GT.Connect.Management.Demo.ConnectApi.Platform;

public record TokenRequest(string Username, string Password, string Client_Id, string Client_Secret, string Grant_Type);

