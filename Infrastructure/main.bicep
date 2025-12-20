targetScope = 'subscription'

param location string = 'westeurope'

resource newRG 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: 'rg-erp-prod'
  location: location
}