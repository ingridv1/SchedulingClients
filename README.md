# SchedulingClients

Scheduling client wrappers for Guidance Automation products.

Get the latest builds, straight from NuGet:
https://www.nuget.org/packages/SchedulingClients/

## Release Notes

## v8.0.0

Supports tool chain for resolving tasks and jobs in a fault state.

## v7.2.0

Adds time to stationary and last completed instruction Id to the kingpin state

## v7.1.0

Refactored fleet manager client which supports the new FleetState callback and the ability to commit waypoints via the comms.

## v7.0.0

Refactored to use GenericClients.

## v6.0.0

Update pipe line task creation with finalization arguments.

## v5.0.0

Adds support to enable in progress jobs to be edited.

## v4.1.1

Bugfix to the UDP package preventing incorrect serialization of headings.

4.1.2 is added as package because I had the content folder instead of the lib folder.

## v4.1.0

Adds updated task support for

* Pipe-lining and move tasks
* Directives

Re-factors the fleet cast client to listen to UDP fleet messages.

## v4.0.0

Replaces the roadmap service reference with the new map service reference to enable support for nucleus studio 3.x.x

## v3.0.0

Switches to the .net 4.6.2 framework

## v2.0.0

Re-factors the entire code base so that all service calls return a service operation result which can either be successful or fail with additional information if is the fault client or server side, and potential reasons for the failure.

## v1.3.0

Adds a simple agent service listing agents currently registered with the scheduler (but not necessarily active). Makes allocation of jobs easier as valid agent Id's are available.

## v1.2.0

Adds a job state service to enable monitoring of jobs currently assigning, waiting and in progress. Also adds a control for marking a service as complete.

## v1.0.0

Initial release, basic roadmap, job and servicing services.

## v1.0.0-alpha 15/3/17 @ 19:23

Initial development release just to have a line in the sand and to bugfix against. Currently implements three clients with basic functionality:

* Job Builder Client
* Roadmap Client
* Servicing Client

