﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchedulingClients.JobsStateServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceCallData", Namespace="http://schemas.datacontract.org/2004/07/Services")]
    [System.SerializableAttribute()]
    public partial class ServiceCallData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SchedulingClients.JobsStateServiceReference.ServiceCode ServiceCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SourceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SchedulingClients.JobsStateServiceReference.ServiceCode ServiceCode {
            get {
                return this.ServiceCodeField;
            }
            set {
                if ((this.ServiceCodeField.Equals(value) != true)) {
                    this.ServiceCodeField = value;
                    this.RaisePropertyChanged("ServiceCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Source {
            get {
                return this.SourceField;
            }
            set {
                if ((object.ReferenceEquals(this.SourceField, value) != true)) {
                    this.SourceField = value;
                    this.RaisePropertyChanged("Source");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceCode", Namespace="http://schemas.datacontract.org/2004/07/Services")]
    public enum ServiceCode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NOERROR = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SERVICENOTCONFIGURED = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CLIENTEXCEPTION = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SERVICEUNAVAILABLE = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SERVICENOTIMPLEMENTED = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        COMMITJOBFAILED = 1001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEJOBFAILED = 1002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEUNORDEREDLISTTASKFAILED = 1003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEATOMICMOVELISTTASKFAILED = 1004,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEORDEREDLISTTASKFAILED = 1005,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATESERVICINGTASKFAILED = 1006,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NOTACCEPTINGNEWJOBS = 1007,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DIRECTIVENOTALLOWED = 1008,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDNODETASKID = 1009,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATESLEEPINGTASKFAILED = 1010,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEGOTONODETASKFAILED = 1011,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEATOMICMOVETASKFAILED = 1012,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BEGINEDITINGJOBFAILED = 1013,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FINISHEDITINGJOBFAILED = 1014,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BEGINEDITINGTASKFAILED = 1015,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FINISHEDITINGTASKFAILED = 1016,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEAWAITINGTASKFAILED = 1017,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ABORTALLJOBSFAILED = 2001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ABORTALLJOBSFORAGENTFAILED = 2002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ABORTJOBFAILED = 2003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETACTIVEJOBSFORAGENTFAILED = 2004,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ABORTTASKFAILED = 2005,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RESOLVEFAULTEDJOBFAILED = 2006,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RESOLVEFAULTEDTASKFAILED = 2007,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETJOBSTATEFAILED = 3001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDJOBID = 3002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDTASKID = 3003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETALLMOVEDATAFAILED = 4001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETALLNODEDATAFAILED = 4002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETMAPPINGKEYCARDSIGNATUREFAILED = 4003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETRAJECTORYFAILED = 4004,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDMOVEID = 4005,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SETOCCUPYINGMANDATEFAILED = 4006,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CLEAROCCUPYINGMANDATEFAILED = 4007,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CONTAINSINVALIDMAPITEMIDS = 4008,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CONTAINSINVALIDTIMEOUT = 4009,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETOUTSTANDINGSERVICEREQUESTSFAILED = 5001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SETSERVICECOMPLETEFAILED = 5002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETALLAGENTDATAFAILED = 6001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETALLAGENTSINLIFETIMESTATEFAILED = 6002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SETAGENTLIFETIMESTATEFAILED = 6003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        COMMITINSTRUCTIONFAILED = 7001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REQUESTFREEZEFAILED = 7002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REQUESTUNFREEZEFAILED = 7003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INCORRECTNUMBEROFBYTES = 7004,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        COMMITEXTENDEDWAYPOINTSFAILED = 7005,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETKINGPINDESCRIPTIONFAILED = 7008,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEVIRTUALVEHICLEFAILED = 7009,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REMOVEVEHICLEFAILED = 7010,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SETPOSEFAILED = 7011,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RESETKINGPINFAILED = 7012,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ENABLEALLVEHICLESFAILED = 7013,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DISABLEALLVEHICLESFAILED = 7014,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDIPADDRESS = 7015,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ENABLEVEHICLEFAILED = 7016,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DISABLEVEHICLEFAILED = 7017,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SETFLEETSTATEFAILED = 7018,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SETKINGPINSTATEFAILED = 7019,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DOWNLOADFAILED = 8001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UPLOADFAILED = 8002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETFILENAMESFAILED = 8003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDAGENTID = 9001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDSTATECASTVARIABLEALIAS = 9002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        STATECASTVARIABLEDATATYPEMISMATCH = 9003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETSCHEDULERVERSIONFAILED = 10001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETPLUGINVERSIONSFAILED = 10002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETOUTSTANDINGAGENTREQUESTSFAILED = 11001,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JobsStateData", Namespace="http://schemas.datacontract.org/2004/07/Scheduling.Services.Jobs")]
    [System.SerializableAttribute()]
    public partial class JobsStateData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AssigningCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int InProgessCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WaitingCountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AssigningCount {
            get {
                return this.AssigningCountField;
            }
            set {
                if ((this.AssigningCountField.Equals(value) != true)) {
                    this.AssigningCountField = value;
                    this.RaisePropertyChanged("AssigningCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int InProgessCount {
            get {
                return this.InProgessCountField;
            }
            set {
                if ((this.InProgessCountField.Equals(value) != true)) {
                    this.InProgessCountField = value;
                    this.RaisePropertyChanged("InProgessCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int WaitingCount {
            get {
                return this.WaitingCountField;
            }
            set {
                if ((this.WaitingCountField.Equals(value) != true)) {
                    this.WaitingCountField = value;
                    this.RaisePropertyChanged("WaitingCount");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JobsStateServiceReference.IJobsStateService", CallbackContract=typeof(SchedulingClients.JobsStateServiceReference.IJobsStateServiceCallback))]
    public interface IJobsStateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionMajor", ReplyAction="http://tempuri.org/IService/VersionMajorResponse")]
        int VersionMajor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionMinor", ReplyAction="http://tempuri.org/IService/VersionMinorResponse")]
        int VersionMinor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionPatch", ReplyAction="http://tempuri.org/IService/VersionPatchResponse")]
        int VersionPatch();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/SubscriptionHeartbeat", ReplyAction="http://tempuri.org/ISubscriptionService/SubscriptionHeartbeatResponse")]
        void SubscriptionHeartbeat(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobsStateService/AbortAllJobs", ReplyAction="http://tempuri.org/IJobsStateService/AbortAllJobsResponse")]
        System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortAllJobs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobsStateService/AbortAllJobsForAgent", ReplyAction="http://tempuri.org/IJobsStateService/AbortAllJobsForAgentResponse")]
        System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortAllJobsForAgent(int agentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobsStateService/AbortJob", ReplyAction="http://tempuri.org/IJobsStateService/AbortJobResponse")]
        System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortJob(int jobId, string note);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobsStateService/AbortTask", ReplyAction="http://tempuri.org/IJobsStateService/AbortTaskResponse")]
        System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortTask(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobsStateService/GetActiveJobIdsForAgent", ReplyAction="http://tempuri.org/IJobsStateService/GetActiveJobIdsForAgentResponse")]
        System.Tuple<int[], SchedulingClients.JobsStateServiceReference.ServiceCallData> GetActiveJobIdsForAgent(int agentId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IJobsStateServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobsStateService/OnCallback", ReplyAction="http://tempuri.org/IJobsStateService/OnCallbackResponse")]
        void OnCallback(SchedulingClients.JobsStateServiceReference.JobsStateData callbackObject);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IJobsStateServiceChannel : SchedulingClients.JobsStateServiceReference.IJobsStateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class JobsStateServiceClient : System.ServiceModel.DuplexClientBase<SchedulingClients.JobsStateServiceReference.IJobsStateService>, SchedulingClients.JobsStateServiceReference.IJobsStateService {
        
        public JobsStateServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public JobsStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public JobsStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public JobsStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public JobsStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int VersionMajor() {
            return base.Channel.VersionMajor();
        }
        
        public int VersionMinor() {
            return base.Channel.VersionMinor();
        }
        
        public int VersionPatch() {
            return base.Channel.VersionPatch();
        }
        
        public void SubscriptionHeartbeat(System.Guid guid) {
            base.Channel.SubscriptionHeartbeat(guid);
        }
        
        public System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortAllJobs() {
            return base.Channel.AbortAllJobs();
        }
        
        public System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortAllJobsForAgent(int agentId) {
            return base.Channel.AbortAllJobsForAgent(agentId);
        }
        
        public System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortJob(int jobId, string note) {
            return base.Channel.AbortJob(jobId, note);
        }
        
        public System.Tuple<bool, SchedulingClients.JobsStateServiceReference.ServiceCallData> AbortTask(int taskId) {
            return base.Channel.AbortTask(taskId);
        }
        
        public System.Tuple<int[], SchedulingClients.JobsStateServiceReference.ServiceCallData> GetActiveJobIdsForAgent(int agentId) {
            return base.Channel.GetActiveJobIdsForAgent(agentId);
        }
    }
}