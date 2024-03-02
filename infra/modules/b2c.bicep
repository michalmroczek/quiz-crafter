
@description('The local reply URL for the SPA')
param localSpaReplyUrl string = ''
@description('The dev reply URL for the SPA')
param devSpaReplyUrl string = ''
@description('The prod reply URL for the SPA')
param prodSpaReplyUrl string = ''

resource localAppRegistration 'Microsoft.AzureActiveDirectory/b2cDirectories/applications@2020-01-01-preview' = if (!empty(localSpaReplyUrl)) {
  name: '/quizcrafterlocalApp'
  properties: {
    signInAudience: 'AzureADandPersonalMicrosoftAccount'
    web: {
      redirectUris: localSpaReplyUrl
    }
  }
}

resource devAppRegistration 'Microsoft.AzureActiveDirectory/b2cDirectories/applications@2020-01-01-preview'= if (!empty(devSpaReplyUrl)) {
  name: '/quizcrafterdevApp'
  properties: {
    signInAudience: 'AzureADandPersonalMicrosoftAccount'
    web: {
      redirectUris: devSpaReplyUrl
    }
  }
}

resource prodAppRegistration 'Microsoft.AzureActiveDirectory/b2cDirectories/applications@2020-01-01-preview' = if (!empty(prodSpaReplyUrl)){
  name: '/quizcrafterprodApp'
  properties: {
    signInAudience: 'AzureADandPersonalMicrosoftAccount'
    web: {
      redirectUris: prodSpaReplyUrl
    }
  }
}

output localAppClientId string = localAppRegistration.properties.appId
output devAppClientId string = devAppRegistration.properties.appId
output prodAppClientId string = prodAppRegistration.properties.appId

output localAppId string = localAppRegistration.id
output devAppId string = devAppRegistration.id
output prodAppId string = prodAppRegistration.id
