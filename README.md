# ***Currently in progress as this example is still using secrets in the connection string

# Azure Functions with App Configuration

This repo contains a sample Azure Functions project with a blob triggered and http function that are getting their config information from App Configuration. I created this example using the [Quickstart: Create an Azure Functions app with Azure App Configuration](https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-azure-functions-csharp?tabs=in-process) in conjunction with the [AppConfiguration FunctionApp example in Github](https://github.com/Azure/AppConfiguration/tree/main/examples/DotNetCore/AzureFunction/FunctionApp) since the quickstart doc only contained a http function example.

## Local

To run the project locally, you will need to do the following:

### VS Code

- Clone repo
- Create new `src/local.settings.json` in project root and make sure it has the following variables:

    ```json
    {
  "IsEncrypted": false,
  "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "ConnectionString":"<app-configuration-connection-string>",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
        }
  }
  ```

### Connection Type

In this simple example we are connecting using connection strings. The main branch is this same example only using managed identity.
