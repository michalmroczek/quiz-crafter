@description('Repository url')
param repositoryUrl string
@description('Repository name')
param repo string 
@description('Branch name')
param branchName string 
@secure()
param repositoryToken string

// module cosmos 'cosmos-mongo.bicep' = {
//   name: 'cosmos'
//   params: {
//     databaseName: 'QuizDb'
//     containerName: 'quizzes'
//     partitionKey: 'id'
//     primaryRegion: resourceGroup().location
//     accountName: 'quizcosmos${take(uniqueString(resourceGroup().id), 6)}'
//     defaultConsistencyLevel: 'Session'
//     location: resourceGroup().location
//   }
// }

resource swa 'Microsoft.Web/staticSites@2023-01-01' = {
  name: 'quizcrafter${take(uniqueString(resourceGroup().id), 6)}'
  location: resourceGroup().location
  sku: {
    name: 'Free'
    tier: 'Free'
  }
  properties: {
    repositoryUrl: '${repositoryUrl}${repo}'
    branch: branchName
    provider: 'GitHub'
    repositoryToken: repositoryToken
}
}


// module b2c 'modules/b2c.bicep' = { 
//   name: 'b2c'
//   params: {

//     tenantName: 'quizcrafter${take(uniqueString(resourceGroup().id), 6)}'
//     appName: 'quiz{take(uniqueString(resourceGroup().id), 6)}'
//     prodSpaReplyUrl: swa.properties.url
//   }
// }
