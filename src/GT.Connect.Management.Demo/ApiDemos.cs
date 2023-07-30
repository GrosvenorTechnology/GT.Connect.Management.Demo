using Bogus;
using GT.Connect.Management.Demo.ConnectApi.DeviceConfig;
using GT.Connect.Management.Demo.ConnectApi.Organisation;
using GT.Connect.Management.Demo.ConnectApi.People;
using System.Runtime;
using static System.Net.Mime.MediaTypeNames;

namespace GT.Connect.Management.Demo;

[TestClass]
public class ApiDemos : ApiTestBase
{

    [TestMethod]
    public async Task CreateTestCompany()
    {
        var api = await GetClient();

        //Find the partner node
        var rootNode = (await api.GetNodes(Settings.TenantId,
            new(new(nameof(NodeResponse.NodeType), NodeType.Partner.ToString(), Operators.Equals))))
            .Single();

        //Look for the 'Api Demo' node and create if not found
        var childNodes = await api.GetNodeAndAllChildren(Settings.TenantId, rootNode.Id);
        var cpNode = childNodes.SingleOrDefault(x => x.Name == "Api Demo");
        if (cpNode is null)
        {
            cpNode = await api.AddNode(Settings.TenantId,
                new AddNodeCommmand(Settings.TenantId, rootNode.Id, "ChannelPartner", "Api Demo"));
        }

        //Now Look for the 'InGen' node and create if not found
        childNodes = await api.GetNodeAndAllChildren(Settings.TenantId, cpNode.Id);
        var cmpNode = childNodes.SingleOrDefault(x => x.Name == "InGen");
        if (cmpNode is null)
        {
            cmpNode = await api.AddNode(Settings.TenantId,
            new AddNodeCommmand(Settings.TenantId, cpNode.Id, "Company", "InGen"));
        }

        //Find the Company so we can get it's ID
        var company = await api.GetCompanyByNodeId(Settings.TenantId, cmpNode.Id);

        //Add a default clock group (ExternalId is your ref for a clock group)
        var clockGroupResponse = await api.GetClockGroupByExternalId(Settings.TenantId, cmpNode.Id, "1");
        ClockGroupResponse? clockGroup = null;
        if (clockGroupResponse.StatusCode == System.Net.HttpStatusCode.OK)
        {
            clockGroup = clockGroupResponse.Content!;
        }
        else
        {
            clockGroup = await api.AddClockGroup(Settings.TenantId, cmpNode.Id,
                    new ClockGroupRequest(Settings.TenantId, cmpNode.Id, company.Id, "1", "Default Group", ""));
        }

        //Now lets add some People to the Group
        Randomizer.Seed = new Random(1905);
        for (int i = 0; i < 10; i++)
        {
            var apiResponse = await api.GetPersonByExternalId(Settings.TenantId, company.NodeId, i.ToString());
            PersonResponse? person = null;
            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                person = apiResponse.Content!;
            }
            else
            {
                var p = new Person();  //This is the source of fake data
                person = await api.AddPerson(Settings.TenantId, company.NodeId,
                    new(cmpNode.Id, company.Id, p.FirstName, p.LastName, i.ToString(),
                        (1000 + i).ToString(), (1000 + i).ToString(), "", "EN", "", "", "", "", ""));

                //add an update, stressing how you have to copy every field
            }

            await api.AddPersonToClockGroup(Settings.TenantId, company.NodeId,
                clockGroup.Id, person.Id);
        }

        Assert.IsTrue(true);
    }


    /// <summary>
    /// This test will find a device in the partner unallocated pool and transfer it to the company
    /// assign it and add it to a clock group.
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task AllocateAndAssignDevice()
    {
        var api = await GetClient();

        //Get the root node, this is where unallocated devices start
        var rootNode = (await api.GetNodes(Settings.TenantId,
            new(new(nameof(NodeResponse.NodeType), NodeType.Partner.ToString(), Operators.Equals))))
            .Single();

        //Get the commpany node, this is where we want to send the device
        var cmpNode = (await api.GetNodes(Settings.TenantId,
            new(new(nameof(NodeResponse.NodeType), NodeType.Company.ToString(), Operators.Equals))))
            .Single(x => x.Name == "InGen");

        //find the devices on the root partner node
        var apiResponse = await api.GetDevices(Settings.TenantId, rootNode.Id,
            new(new(nameof(Device.SerialNumber), "fp-gt8~99990001", Operators.CaseInsensitiveStringEquals)));

        if (apiResponse.StatusCode != System.Net.HttpStatusCode.OK)
        {
            // 204 is no devices, so have to check for OK
            Assert.Fail($"No Devices Found, status code: {apiResponse.StatusCode}");
        }

        Assert.IsNotNull(apiResponse.Content, "There should be one device in the results");
        var device = apiResponse.Content.Single();

        //Allocate the device into the company node, this returns an updated device record
        device = await api.AllocateUnassignedDevice(Settings.TenantId, device.Id,
            new(device.Id, Settings.TenantId, cmpNode.Id));

        //In this example we're just adding the device at the root of the company node,
        //  but this could have been a structral node under the commpany
        device = await api.AssignDevice(Settings.TenantId, device.Id, new(device.Id, Settings.TenantId, cmpNode.Id));

        //Finally enable the device
        //  It's important to supply all the fields currently, as the update operation
        //  is a full record updated, we do not currently support patches.
        //  To make this easier, we user a mapper here
        var mapper = new MapperClasses();

        if (device.IsEnabled == false)
        {
            var updateCommand = mapper.Map(device) with
            {
                IsEnabled = true,
            };

            var updateResponse = await api.UpdateDevice(updateCommand);
        }


        Assert.AreEqual("Company", device.NodeType);
        Assert.AreEqual("Assigned", device.DeviceLifecycleState);
    }

    /// <summary>
    /// This test will unasign a device and return it to the partner root node.
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task UnassignAndUnallocateDevice()
    {
        var api = await GetClient();

        //Get the root node, this is where unallocated devices start
        var rootNode = (await api.GetNodes(Settings.TenantId,
            new(new(nameof(NodeResponse.NodeType), NodeType.Partner.ToString(), Operators.Equals))))
            .Single();

        //Get the commpany node, this is where we want to send the device
        var cmpNode = (await api.GetNodes(Settings.TenantId,
            new(new(nameof(NodeResponse.NodeType), NodeType.Company.ToString(), Operators.Equals))))
            .Single(x => x.Name == "InGen");

        //find the devices on the company node
        var apiResponse = await api.GetDevices(Settings.TenantId, cmpNode.Id,
            new(new(nameof(Device.SerialNumber), "fp-gt8~99990001", Operators.CaseInsensitiveStringEquals)));

        if (apiResponse.StatusCode != System.Net.HttpStatusCode.OK)
        {
            // 204 is no devices, so have to check for OK
            Assert.Fail($"No Devices Found, status code: {apiResponse.StatusCode}");
        }

        Assert.IsNotNull(apiResponse.Content, "There should be one device in the results");
        var device = apiResponse.Content.Single();

        if (device.DeviceLifecycleState == "Assigned")
        {
            //Allocate the device into the company node, this returns an updated device record
            device = await api.UnassignDevice(Settings.TenantId, device.Id,
            new(device.Id, Settings.TenantId));
        }

        //Allocate the device back to the root partner node
        device = await api.AllocateUnassignedDevice(Settings.TenantId, device.Id,
            new(device.Id, Settings.TenantId, rootNode.Id));

        Assert.AreEqual("Partner", device.NodeType);
        Assert.AreEqual("Unassigned", device.DeviceLifecycleState);
    }

    /// <summary>
    /// This example will create a simple config file on a node and send it.
    /// </summary>
    /// <returns></returns>
    [TestMethod]
    public async Task CreateAndSendConfiguration()
    {
        //Note for simplicity we've hardcoded the FileTypeId here, but you can get them by
        //  calling the /api/tenants/{{tenantId}}/device-config/fileTypes/family/{{deviceFamily}} or
        //  /api/tenants/{{tenantId}}/device-config/fileTypes/deviceType/{{deviceType}} apis.
        var policyFileTypeId = new Guid("5BEBD327-D6E1-427D-8A34-38C717B50A3E");
        var policyName = "Api Demo Policy";
        var policyData = """
            <?xml version='1.0' encoding='UTF-8' standalone='yes' ?>
            <configuration>
                <com.gtl.android.gteasyclock>
                    <settings>
                        <app_log>dbg</app_log>
                    </settings>
                </com.gtl.android.gteasyclock>
            </configuration>
            """;

        var api = await GetClient();

        //Get the commpany node, this is where we want to send the device
        var cmpNode = (await api.GetNodes(Settings.TenantId,
            new(new(nameof(NodeResponse.NodeType), NodeType.Company.ToString(), Operators.Equals))))
            .Single(x => x.Name == "InGen");

        
        var response = await api.GetConfigurationOnNode(Settings.TenantId, cmpNode.Id);
        await response.EnsureSuccessStatusCodeAsync();

        //The GetConfigurationOnNode function retuns a 204 if there is no content,
        //  Refit does not like that when deserializing the response content, so have to check explicitly
        DeviceConfiguration? policy = default;
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            policy = response.Content?.SingleOrDefault(x => x.Description == policyName);
        }

        if (policy is not null)
        {
            //Policy exists, lets update instead
            policy = await api.UpdateConfiguration(Settings.TenantId, policy.Id,
                new(Settings.TenantId, policyName, policyData));
        }
        else
        {
            policy = await api.AddConfigurationToNodeOrDevice(Settings.TenantId,
                new(Settings.TenantId, cmpNode.Id, null, policyName, policyFileTypeId, policyData));
        }

        //Now send the policy to all devices under the company node.
        await api.SynchroniseSelectedOnDeviceOrNode(Settings.TenantId,
            new SynchroniseSelectedCommand(Settings.TenantId, cmpNode.Id, null, Configs: new[] { policy.Id }));
    }

}

