﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchedulingClients.JobBuilderServiceReference {
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
        private SchedulingClients.JobBuilderServiceReference.ServiceCode ServiceCodeField;
        
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
        public SchedulingClients.JobBuilderServiceReference.ServiceCode ServiceCode {
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
        COMMITJOBFAILED = 1001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEJOBFAILED = 1002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEUNORDEREDLISTTASKFAILED = 1003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATEPIPELINEDTASKFAILED = 1004,
        
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
        CREATEMOVINGTASKFAILED = 1011,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FINALISETASKFAILED = 1012,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BEGINEDITINGJOBFAILED = 1013,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FINISHEDITINGJOBFAILED = 1014,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BEGINEDITINGTASKFAILED = 1015,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FINISHEDITINGTASKFAILED = 1016,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ABORTALLJOBSFAILED = 2001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ABORTALLJOBSFORAGENTFAILED = 2002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ABORTJOBFAILED = 2003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETACTIVEJOBSFORAGENTFAILED = 2004,
        
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
        GETTRAJECTORYFAILED = 4004,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        INVALIDMOVEID = 4005,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETOUTSTANDINGSERVICEREQUESTSFAILED = 5001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SETSERVICECOMPLETEFAILED = 5002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETALLAGENTDATAFAILED = 6001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GETALLAGENTSINLIFETIMESTATEFAILED = 6002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        COMMITINSTRUCTIONFAILED = 7001,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REQUESTFREEZEFAILED = 7002,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        REQUESTUNFREEZEFAILED = 7003,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JobData", Namespace="http://schemas.datacontract.org/2004/07/SchedulingServices")]
    [System.SerializableAttribute()]
    public partial class JobData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int JobIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderedListTaskIdField;
        
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
        public int JobId {
            get {
                return this.JobIdField;
            }
            set {
                if ((this.JobIdField.Equals(value) != true)) {
                    this.JobIdField = value;
                    this.RaisePropertyChanged("JobId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderedListTaskId {
            get {
                return this.OrderedListTaskIdField;
            }
            set {
                if ((this.OrderedListTaskIdField.Equals(value) != true)) {
                    this.OrderedListTaskIdField = value;
                    this.RaisePropertyChanged("OrderedListTaskId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceType", Namespace="http://schemas.datacontract.org/2004/07/Mapping")]
    public enum ServiceType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Charge = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Park = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fault = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ManualLoadHandling = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GoTo = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JobBuilderServiceReference.IJobBuilderService")]
    public interface IJobBuilderService {
        
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CommitJob", ReplyAction="http://tempuri.org/IJobBuilderService/CommitJobResponse")]
        System.Tuple<bool, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CommitJob(int jobId, int agentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CommitJob", ReplyAction="http://tempuri.org/IJobBuilderService/CommitJobResponse")]
        System.Threading.Tasks.Task<System.Tuple<bool, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CommitJobAsync(int jobId, int agentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateJob", ReplyAction="http://tempuri.org/IJobBuilderService/CreateJobResponse")]
        System.Tuple<SchedulingClients.JobBuilderServiceReference.JobData, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateJob();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateJob", ReplyAction="http://tempuri.org/IJobBuilderService/CreateJobResponse")]
        System.Threading.Tasks.Task<System.Tuple<SchedulingClients.JobBuilderServiceReference.JobData, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateJobAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateUnorderedListTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateUnorderedListTaskResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateUnorderedListTask(int parentTaskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateUnorderedListTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateUnorderedListTaskResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateUnorderedListTaskAsync(int parentTaskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateOrderedListTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateOrderedListTaskResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateOrderedListTask(int parentTaskId, bool isFinalised);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateOrderedListTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateOrderedListTaskResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateOrderedListTaskAsync(int parentTaskId, bool isFinalised);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreatePipelinedTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreatePipelinedTaskResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreatePipelinedTask(int parentTaskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreatePipelinedTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreatePipelinedTaskResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreatePipelinedTaskAsync(int parentTaskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateServicingTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateServicingTaskResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateServicingTask(int parentTaskId, int nodeId, SchedulingClients.JobBuilderServiceReference.ServiceType serviceType, System.TimeSpan expectedDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateServicingTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateServicingTaskResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateServicingTaskAsync(int parentTaskId, int nodeId, SchedulingClients.JobBuilderServiceReference.ServiceType serviceType, System.TimeSpan expectedDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateSleepingTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateSleepingTaskResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateSleepingTask(int parentTaskId, int nodeId, System.TimeSpan expectedDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateSleepingTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateSleepingTaskResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateSleepingTaskAsync(int parentTaskId, int nodeId, System.TimeSpan expectedDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateMovingTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateMovingTaskResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateMovingTask(int parentTaskId, int nodeId, System.TimeSpan expectedDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/CreateMovingTask", ReplyAction="http://tempuri.org/IJobBuilderService/CreateMovingTaskResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateMovingTaskAsync(int parentTaskId, int nodeId, System.TimeSpan expectedDuration);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueEnumDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueEnumDirectiveResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueEnumDirective(int taskId, int parameterId, byte value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueEnumDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueEnumDirectiveResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueEnumDirectiveAsync(int taskId, int parameterId, byte value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueShortDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueShortDirectiveResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueShortDirective(int taskId, int parameterId, short value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueShortDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueShortDirectiveResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueShortDirectiveAsync(int taskId, int parameterId, short value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueUShortDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueUShortDirectiveResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueUShortDirective(int taskId, int parameterId, ushort value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueUShortDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueUShortDirectiveResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueUShortDirectiveAsync(int taskId, int parameterId, ushort value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueFloatDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueFloatDirectiveResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueFloatDirective(int taskId, int parameterId, float value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueFloatDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueFloatDirectiveResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueFloatDirectiveAsync(int taskId, int parameterId, float value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueIPAddressDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueIPAddressDirectiveResponse")]
        System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueIPAddressDirective(int taskId, int parameterId, System.Net.IPAddress value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/IssueIPAddressDirective", ReplyAction="http://tempuri.org/IJobBuilderService/IssueIPAddressDirectiveResponse")]
        System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueIPAddressDirectiveAsync(int taskId, int parameterId, System.Net.IPAddress value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/BeginEditingJob", ReplyAction="http://tempuri.org/IJobBuilderService/BeginEditingJobResponse")]
        SchedulingClients.JobBuilderServiceReference.ServiceCallData BeginEditingJob(int jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/BeginEditingJob", ReplyAction="http://tempuri.org/IJobBuilderService/BeginEditingJobResponse")]
        System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> BeginEditingJobAsync(int jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/FinishEditingJob", ReplyAction="http://tempuri.org/IJobBuilderService/FinishEditingJobResponse")]
        SchedulingClients.JobBuilderServiceReference.ServiceCallData FinishEditingJob(int jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/FinishEditingJob", ReplyAction="http://tempuri.org/IJobBuilderService/FinishEditingJobResponse")]
        System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> FinishEditingJobAsync(int jobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/BeginEditingTask", ReplyAction="http://tempuri.org/IJobBuilderService/BeginEditingTaskResponse")]
        SchedulingClients.JobBuilderServiceReference.ServiceCallData BeginEditingTask(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/BeginEditingTask", ReplyAction="http://tempuri.org/IJobBuilderService/BeginEditingTaskResponse")]
        System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> BeginEditingTaskAsync(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/FinishEditingTask", ReplyAction="http://tempuri.org/IJobBuilderService/FinishEditingTaskResponse")]
        SchedulingClients.JobBuilderServiceReference.ServiceCallData FinishEditingTask(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/FinishEditingTask", ReplyAction="http://tempuri.org/IJobBuilderService/FinishEditingTaskResponse")]
        System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> FinishEditingTaskAsync(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/FinaliseTask", ReplyAction="http://tempuri.org/IJobBuilderService/FinaliseTaskResponse")]
        SchedulingClients.JobBuilderServiceReference.ServiceCallData FinaliseTask(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IJobBuilderService/FinaliseTask", ReplyAction="http://tempuri.org/IJobBuilderService/FinaliseTaskResponse")]
        System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> FinaliseTaskAsync(int taskId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IJobBuilderServiceChannel : SchedulingClients.JobBuilderServiceReference.IJobBuilderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class JobBuilderServiceClient : System.ServiceModel.ClientBase<SchedulingClients.JobBuilderServiceReference.IJobBuilderService>, SchedulingClients.JobBuilderServiceReference.IJobBuilderService {
        
        public JobBuilderServiceClient() {
        }
        
        public JobBuilderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public JobBuilderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JobBuilderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public JobBuilderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
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
        
        public System.Tuple<bool, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CommitJob(int jobId, int agentId) {
            return base.Channel.CommitJob(jobId, agentId);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<bool, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CommitJobAsync(int jobId, int agentId) {
            return base.Channel.CommitJobAsync(jobId, agentId);
        }
        
        public System.Tuple<SchedulingClients.JobBuilderServiceReference.JobData, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateJob() {
            return base.Channel.CreateJob();
        }
        
        public System.Threading.Tasks.Task<System.Tuple<SchedulingClients.JobBuilderServiceReference.JobData, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateJobAsync() {
            return base.Channel.CreateJobAsync();
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateUnorderedListTask(int parentTaskId) {
            return base.Channel.CreateUnorderedListTask(parentTaskId);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateUnorderedListTaskAsync(int parentTaskId) {
            return base.Channel.CreateUnorderedListTaskAsync(parentTaskId);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateOrderedListTask(int parentTaskId, bool isFinalised) {
            return base.Channel.CreateOrderedListTask(parentTaskId, isFinalised);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateOrderedListTaskAsync(int parentTaskId, bool isFinalised) {
            return base.Channel.CreateOrderedListTaskAsync(parentTaskId, isFinalised);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreatePipelinedTask(int parentTaskId) {
            return base.Channel.CreatePipelinedTask(parentTaskId);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreatePipelinedTaskAsync(int parentTaskId) {
            return base.Channel.CreatePipelinedTaskAsync(parentTaskId);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateServicingTask(int parentTaskId, int nodeId, SchedulingClients.JobBuilderServiceReference.ServiceType serviceType, System.TimeSpan expectedDuration) {
            return base.Channel.CreateServicingTask(parentTaskId, nodeId, serviceType, expectedDuration);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateServicingTaskAsync(int parentTaskId, int nodeId, SchedulingClients.JobBuilderServiceReference.ServiceType serviceType, System.TimeSpan expectedDuration) {
            return base.Channel.CreateServicingTaskAsync(parentTaskId, nodeId, serviceType, expectedDuration);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateSleepingTask(int parentTaskId, int nodeId, System.TimeSpan expectedDuration) {
            return base.Channel.CreateSleepingTask(parentTaskId, nodeId, expectedDuration);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateSleepingTaskAsync(int parentTaskId, int nodeId, System.TimeSpan expectedDuration) {
            return base.Channel.CreateSleepingTaskAsync(parentTaskId, nodeId, expectedDuration);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> CreateMovingTask(int parentTaskId, int nodeId, System.TimeSpan expectedDuration) {
            return base.Channel.CreateMovingTask(parentTaskId, nodeId, expectedDuration);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> CreateMovingTaskAsync(int parentTaskId, int nodeId, System.TimeSpan expectedDuration) {
            return base.Channel.CreateMovingTaskAsync(parentTaskId, nodeId, expectedDuration);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueEnumDirective(int taskId, int parameterId, byte value) {
            return base.Channel.IssueEnumDirective(taskId, parameterId, value);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueEnumDirectiveAsync(int taskId, int parameterId, byte value) {
            return base.Channel.IssueEnumDirectiveAsync(taskId, parameterId, value);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueShortDirective(int taskId, int parameterId, short value) {
            return base.Channel.IssueShortDirective(taskId, parameterId, value);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueShortDirectiveAsync(int taskId, int parameterId, short value) {
            return base.Channel.IssueShortDirectiveAsync(taskId, parameterId, value);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueUShortDirective(int taskId, int parameterId, ushort value) {
            return base.Channel.IssueUShortDirective(taskId, parameterId, value);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueUShortDirectiveAsync(int taskId, int parameterId, ushort value) {
            return base.Channel.IssueUShortDirectiveAsync(taskId, parameterId, value);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueFloatDirective(int taskId, int parameterId, float value) {
            return base.Channel.IssueFloatDirective(taskId, parameterId, value);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueFloatDirectiveAsync(int taskId, int parameterId, float value) {
            return base.Channel.IssueFloatDirectiveAsync(taskId, parameterId, value);
        }
        
        public System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData> IssueIPAddressDirective(int taskId, int parameterId, System.Net.IPAddress value) {
            return base.Channel.IssueIPAddressDirective(taskId, parameterId, value);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<int, SchedulingClients.JobBuilderServiceReference.ServiceCallData>> IssueIPAddressDirectiveAsync(int taskId, int parameterId, System.Net.IPAddress value) {
            return base.Channel.IssueIPAddressDirectiveAsync(taskId, parameterId, value);
        }
        
        public SchedulingClients.JobBuilderServiceReference.ServiceCallData BeginEditingJob(int jobId) {
            return base.Channel.BeginEditingJob(jobId);
        }
        
        public System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> BeginEditingJobAsync(int jobId) {
            return base.Channel.BeginEditingJobAsync(jobId);
        }
        
        public SchedulingClients.JobBuilderServiceReference.ServiceCallData FinishEditingJob(int jobId) {
            return base.Channel.FinishEditingJob(jobId);
        }
        
        public System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> FinishEditingJobAsync(int jobId) {
            return base.Channel.FinishEditingJobAsync(jobId);
        }
        
        public SchedulingClients.JobBuilderServiceReference.ServiceCallData BeginEditingTask(int taskId) {
            return base.Channel.BeginEditingTask(taskId);
        }
        
        public System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> BeginEditingTaskAsync(int taskId) {
            return base.Channel.BeginEditingTaskAsync(taskId);
        }
        
        public SchedulingClients.JobBuilderServiceReference.ServiceCallData FinishEditingTask(int taskId) {
            return base.Channel.FinishEditingTask(taskId);
        }
        
        public System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> FinishEditingTaskAsync(int taskId) {
            return base.Channel.FinishEditingTaskAsync(taskId);
        }
        
        public SchedulingClients.JobBuilderServiceReference.ServiceCallData FinaliseTask(int taskId) {
            return base.Channel.FinaliseTask(taskId);
        }
        
        public System.Threading.Tasks.Task<SchedulingClients.JobBuilderServiceReference.ServiceCallData> FinaliseTaskAsync(int taskId) {
            return base.Channel.FinaliseTaskAsync(taskId);
        }
    }
}
