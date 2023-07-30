# GT.Connect.Management.Demo
Demos for how to use the GtConnect Management API

## Setup
Add the details provided to you to the Settings.cs class at the root of the project

## The code
The ConnectApi folder contains a Refit implementation of sections of the GtConnect API

The ApiDemos.cs file contains the following demo
- CreateTestCompany : Add a company and set up some sample users
- AllocateAndAssignDevice : Takes a test device and assigns it into the company created above
- UnassignAndUnallocateDevice : Returns a device to the partner pool of devices
- CreateAndSendConfiguration : This sample creates a simple configuration on the company node above and sends it to all devices assigned in the company.
