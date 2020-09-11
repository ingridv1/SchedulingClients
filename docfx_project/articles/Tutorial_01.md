# Tutorial 01 - Creating a job to route a vehicle to a Node

Pre-requisites:

* An active fleet management and scheduling service installation
  * Hosting HTTP endpoints on 41916.
  * Hosting Net.TCP endpoint on 41917.
* Visual Studio 2019.
* Basic C# knowledge.

## Getting Started

- Download the source code from [Github](https://github.com/GuidanceAutomation/SchedulingClients)
- Open the solution ```SchedulingClients.sln``` in VS 2019

> [!TIP]
> Ensure your fleet management and scheduling services are running and exposing endpoints on localhost.

> [!IMPORTANT]
> Check the http endpoint [fleetManager.svc](http://127.0.0.1:41916/fleetManager.svc) is active.
> Check the http endpoint [map.svc](http://127.0.0.1:41916/map.svc) is active.

### Run the Console application

Select ```Tutorial 01``` as the startup project, build and run the solution.

A simple demo will run where initially a map client is used to obtain a list of all the nodes in the map. Then, using a fleet manager client a virtual vehicle is placed at the first node in the map. A node is then picked at random, and the job builder client is used to route the vehicle to a random node.

## Code Snippets

Check the code in ```Tutorial01\Program.cs``` for a commented walkthrough.

### EndpointSettings

```EndpointSettings``` is a lightweight object that tightly couples:

* IP Address
* Http port (41916 default)
* TCP port (41917 default)
* UDP port (41918 default)

of the host (server). Use this in conjunction with the client factory to create a client.

### IMapClient

The map client is created via the static factory class ```ClientFactory```

```
IMapClient mapClient = SchedulingClients.Core.ClientFactory.CreateTcpMapClient(endpointSettings);
```
> [!WARNING]
> The map client has its own background thread for auto-subscribing to server events. Dispose of the client when it is no longer required: ```mapClient.Dispose()```

### IJobBuilderClient

Job building takes place in three stages:

1) A new job is created:

```IServiceCallResult<JobDto> createResult = jobBuilder.CreateJob();```

2) A new task is added to the job:

```IServiceCallResult<int> gotoResult = jobBuilder.CreateGoToNodeTask(createResult.Value.RootOrderedListTaskId, nodeId);```

This is a GoTo task, a task which sends a vehicle to a node. Once the vehicle arrive there the task is complete.

3) Commit job

```IServiceCallResult commitResult = jobBuilder.CommitJob(createResult.Value.JobId);```

Committing the job instructs the scheduler the job is fully described, and ready for assignment. 

> [!WARNING]
> Remember to check the success of your ```IServiceCallResult``` for client or server errors.
