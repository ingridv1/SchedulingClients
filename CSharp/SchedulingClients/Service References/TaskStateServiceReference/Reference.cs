﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchedulingClients.TaskStateServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TaskProgressData", Namespace="http://schemas.datacontract.org/2004/07/Scheduling.Services.Jobs")]
    [System.SerializableAttribute()]
    public partial class TaskProgressData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AssignedAgentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TaskIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SchedulingClients.TaskStateServiceReference.TaskStatus TaskStatusField;
        
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
        public int AssignedAgentId {
            get {
                return this.AssignedAgentIdField;
            }
            set {
                if ((this.AssignedAgentIdField.Equals(value) != true)) {
                    this.AssignedAgentIdField = value;
                    this.RaisePropertyChanged("AssignedAgentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TaskId {
            get {
                return this.TaskIdField;
            }
            set {
                if ((this.TaskIdField.Equals(value) != true)) {
                    this.TaskIdField = value;
                    this.RaisePropertyChanged("TaskId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SchedulingClients.TaskStateServiceReference.TaskStatus TaskStatus {
            get {
                return this.TaskStatusField;
            }
            set {
                if ((this.TaskStatusField.Equals(value) != true)) {
                    this.TaskStatusField = value;
                    this.RaisePropertyChanged("TaskStatus");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TaskStatus", Namespace="http://schemas.datacontract.org/2004/07/Scheduling.Core")]
    public enum TaskStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unstarted = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InProgress = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Completed = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Aborted = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Assembly = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AttemptingAbort = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AwaitingAbort = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PendingFurtherInstruction = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Editing = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InProgressUnderFault = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CompletedUnderFault = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AttemptingEarlyFailure = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AwaitingEarlyFailure = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AwaitingFailure = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Failed = 14,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TaskStateServiceReference.ITaskStateService", CallbackContract=typeof(SchedulingClients.TaskStateServiceReference.ITaskStateServiceCallback))]
    public interface ITaskStateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionMajor", ReplyAction="http://tempuri.org/IService/VersionMajorResponse")]
        int VersionMajor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionMajor", ReplyAction="http://tempuri.org/IService/VersionMajorResponse")]
        System.Threading.Tasks.Task<int> VersionMajorAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionMinor", ReplyAction="http://tempuri.org/IService/VersionMinorResponse")]
        int VersionMinor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionMinor", ReplyAction="http://tempuri.org/IService/VersionMinorResponse")]
        System.Threading.Tasks.Task<int> VersionMinorAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionPatch", ReplyAction="http://tempuri.org/IService/VersionPatchResponse")]
        int VersionPatch();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VersionPatch", ReplyAction="http://tempuri.org/IService/VersionPatchResponse")]
        System.Threading.Tasks.Task<int> VersionPatchAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/SubscriptionHeartbeat", ReplyAction="http://tempuri.org/ISubscriptionService/SubscriptionHeartbeatResponse")]
        void SubscriptionHeartbeat(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubscriptionService/SubscriptionHeartbeat", ReplyAction="http://tempuri.org/ISubscriptionService/SubscriptionHeartbeatResponse")]
        System.Threading.Tasks.Task SubscriptionHeartbeatAsync(System.Guid guid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITaskStateServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITaskStateService/OnCallback", ReplyAction="http://tempuri.org/ITaskStateService/OnCallbackResponse")]
        void OnCallback(SchedulingClients.TaskStateServiceReference.TaskProgressData callbackObject);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITaskStateServiceChannel : SchedulingClients.TaskStateServiceReference.ITaskStateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskStateServiceClient : System.ServiceModel.DuplexClientBase<SchedulingClients.TaskStateServiceReference.ITaskStateService>, SchedulingClients.TaskStateServiceReference.ITaskStateService {
        
        public TaskStateServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public TaskStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public TaskStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TaskStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TaskStateServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int VersionMajor() {
            return base.Channel.VersionMajor();
        }
        
        public System.Threading.Tasks.Task<int> VersionMajorAsync() {
            return base.Channel.VersionMajorAsync();
        }
        
        public int VersionMinor() {
            return base.Channel.VersionMinor();
        }
        
        public System.Threading.Tasks.Task<int> VersionMinorAsync() {
            return base.Channel.VersionMinorAsync();
        }
        
        public int VersionPatch() {
            return base.Channel.VersionPatch();
        }
        
        public System.Threading.Tasks.Task<int> VersionPatchAsync() {
            return base.Channel.VersionPatchAsync();
        }
        
        public void SubscriptionHeartbeat(System.Guid guid) {
            base.Channel.SubscriptionHeartbeat(guid);
        }
        
        public System.Threading.Tasks.Task SubscriptionHeartbeatAsync(System.Guid guid) {
            return base.Channel.SubscriptionHeartbeatAsync(guid);
        }
    }
}
