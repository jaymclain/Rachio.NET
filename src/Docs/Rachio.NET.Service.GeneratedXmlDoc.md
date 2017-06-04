# Rachio.NET.Service #

#### Method Model.Device.RainDelay(System.Int32)

 Rain delay device 

|Name | Description |
|-----|------|
|duration: |Duration in seconds. Range is 0 to 604800 (7 days). Default is 1 day.|


---
#### Method Model.Device.On

 Turn ON all features of the device (schedules, weather intelligence, water budget, etc.) 



---
#### Method Model.Zone.Start(System.Int32)

 Start a zone 

|Name | Description |
|-----|------|
|duration: |Duration in seconds. Range is 0 to 10800 (3 hours). Default is 15 minutes.|


---
## Type RachioService

 The main service for interaction with the Rachio Smart Sprinkler Controller 



---
#### Method RachioService.Create(Rachio.NET.Service.ServiceOptions)

 Creates the Rachio Smart Sprinkler Controller communications service 

|Name | Description |
|-----|------|
|options: |Options for the RachioService|
**Returns**: The RachioService



######  code

```
    var service = RachioService.Create(new ServiceOptions { AccessToken = "{Your Access Token}" });
```



---
#### Method RachioService.Person

 Retrieves the information for the person currently logged in. 

**Returns**: The Person entity



######  code

```
    var service = RachioService.Create(new ServiceOptions { AccessToken = "{Your Access Token}" });
    var person = service.Person();
```



---
#### Method RachioService.Person(System.String)

 Retrieves the information for a specific person 

|Name | Description |
|-----|------|
|id: |A unique person id|
**Returns**: The Person entity



---
#### Method RachioService.Device(System.String)

 Retrieve the information for a specific device 

|Name | Description |
|-----|------|
|id: |A unique device id|
**Returns**: The Device entity



---
#### Method RachioService.Zone(System.String)

 Retrieves the information for a specific zone 

|Name | Description |
|-----|------|
|id: |A unique zone id|
**Returns**: The Zone entity



---


