# Functions Continous Deployment demo (using VSTS)

This is a simple Azure Functions project (requires Visual Studio 2017 + Functions Tools) that listens for new Documents in Cosmos DB and then sends their contents as an email via SendGrid.

It is used to demonstrate how we can deploy to Azure using Visual Studio Team Services (VSTS) even when the source repository is Github.

You can learn more about how to use this repository by:

- Watching [The DevOps Lab episode](https://channel9.msdn.com/Shows/DevOps-Lab/Deploying-Azure-Functions-with-VSTS) where we cover how it works.
- Read the [detailed blog](https://blog.siliconvalve.com/2018/05/03/multi-environment-deployments-for-compiled-c-azure-functions-with-vsts-release-management/) on how you can deploy and use it.

The default gitignore blocks the upload of the local settings file (which is a good idea), so to help you get started here is a copy of the settings file that shows which App Settings you will need to deploy to get the Functions in this sample to work.

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "DefaultEndpointsProtocol=https;AccountName=[ACCOUNT_NAME];AccountKey=[ACCOUNT_KEY]",
    "AzureWebJobsDashboard": "DefaultEndpointsProtocol=https;AccountName=[ACCOUNT_NAME];AccountKey=[ACCOUNT_KEY]",
    "AzureWebJobsSendGridApiKey": "SG.[SENDGRID_KEY]",
    "DatabaseName": "quotedemo",
    "CollectionName": "quotes",
    "LeasesCollectionName": "leases",
    "CosmosConnection": "AccountEndpoint=https://[COSMOS_ACCOUNT].documents.azure.com:443/;AccountKey=[COSMOS_KEY]",
    "NotificationsSender": "use@a_real_address.com",
    "APPINSIGHTS_INSTRUMENTATIONKEY": "[APP_INSIGHTS_TELEMETRY_KEY]",
    "TimerRecipient": "use@a_real_address.com"
  }
}
```

*Note:* if you are planning on deploying to a Consumption Plan, make sure you set the value of [WEBSITE_CONTENTAZUREFILECONNECTIONSTRING](https://docs.microsoft.com/en-us/azure/azure-functions/functions-app-settings#websitecontentazurefileconnectionstring). If you don't set this value (or delete it on deployment) your Function App will stop working after initial deployment.

[See the official docs](https://docs.microsoft.com/en-us/azure/azure-functions/functions-app-settings) for the options you have for App Settings for Functions.

I recorded a walk-through video you can watch to understand how this all hangs together: https://youtu.be/bXYL8ycLqX0
