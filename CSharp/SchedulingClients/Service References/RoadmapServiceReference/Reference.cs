﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchedulingClients.RoadmapServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MoveData", Namespace="http://schemas.datacontract.org/2004/07/SchedulingServices")]
    [System.SerializableAttribute()]
    public partial class MoveData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AliasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DestinationIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LengthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SourceIdField;
        
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
        public string Alias {
            get {
                return this.AliasField;
            }
            set {
                if ((object.ReferenceEquals(this.AliasField, value) != true)) {
                    this.AliasField = value;
                    this.RaisePropertyChanged("Alias");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int DestinationId {
            get {
                return this.DestinationIdField;
            }
            set {
                if ((this.DestinationIdField.Equals(value) != true)) {
                    this.DestinationIdField = value;
                    this.RaisePropertyChanged("DestinationId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Length {
            get {
                return this.LengthField;
            }
            set {
                if ((this.LengthField.Equals(value) != true)) {
                    this.LengthField = value;
                    this.RaisePropertyChanged("Length");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SourceId {
            get {
                return this.SourceIdField;
            }
            set {
                if ((this.SourceIdField.Equals(value) != true)) {
                    this.SourceIdField = value;
                    this.RaisePropertyChanged("SourceId");
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
        private SchedulingClients.RoadmapServiceReference.ServiceCode ServiceCodeField;
        
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
        public SchedulingClients.RoadmapServiceReference.ServiceCode ServiceCode {
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
        CREATELISTTASKFAILED = 1003,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CREATESERVICINGTASKFAILED = 1004,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NOTACCEPTINGNEWJOBS = 1005,
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="NodeData", Namespace="http://schemas.datacontract.org/2004/07/SchedulingServices")]
    [System.SerializableAttribute()]
    public partial class NodeData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AliasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double HeadingRadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MapItemIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SchedulingClients.RoadmapServiceReference.ServiceType[] ServicesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double XField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double YField;
        
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
        public string Alias {
            get {
                return this.AliasField;
            }
            set {
                if ((object.ReferenceEquals(this.AliasField, value) != true)) {
                    this.AliasField = value;
                    this.RaisePropertyChanged("Alias");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double HeadingRad {
            get {
                return this.HeadingRadField;
            }
            set {
                if ((this.HeadingRadField.Equals(value) != true)) {
                    this.HeadingRadField = value;
                    this.RaisePropertyChanged("HeadingRad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MapItemId {
            get {
                return this.MapItemIdField;
            }
            set {
                if ((this.MapItemIdField.Equals(value) != true)) {
                    this.MapItemIdField = value;
                    this.RaisePropertyChanged("MapItemId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SchedulingClients.RoadmapServiceReference.ServiceType[] Services {
            get {
                return this.ServicesField;
            }
            set {
                if ((object.ReferenceEquals(this.ServicesField, value) != true)) {
                    this.ServicesField = value;
                    this.RaisePropertyChanged("Services");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ServiceType", Namespace="http://schemas.datacontract.org/2004/07/Mapping.Roadmaps")]
    public enum ServiceType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Charge = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Null = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Park = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fault = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Pick = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Drop = 5,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WaypointData", Namespace="http://schemas.datacontract.org/2004/07/SchedulingServices")]
    [System.SerializableAttribute()]
    public partial class WaypointData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double HeadingRadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double XField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double YField;
        
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
        public double HeadingRad {
            get {
                return this.HeadingRadField;
            }
            set {
                if ((this.HeadingRadField.Equals(value) != true)) {
                    this.HeadingRadField = value;
                    this.RaisePropertyChanged("HeadingRad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double X {
            get {
                return this.XField;
            }
            set {
                if ((this.XField.Equals(value) != true)) {
                    this.XField = value;
                    this.RaisePropertyChanged("X");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Y {
            get {
                return this.YField;
            }
            set {
                if ((this.YField.Equals(value) != true)) {
                    this.YField = value;
                    this.RaisePropertyChanged("Y");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoadmapServiceReference.IRoadmapService")]
    public interface IRoadmapService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetAllMoveData", ReplyAction="http://tempuri.org/IRoadmapService/GetAllMoveDataResponse")]
        System.Tuple<SchedulingClients.RoadmapServiceReference.MoveData[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetAllMoveData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetAllMoveData", ReplyAction="http://tempuri.org/IRoadmapService/GetAllMoveDataResponse")]
        System.Threading.Tasks.Task<System.Tuple<SchedulingClients.RoadmapServiceReference.MoveData[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetAllMoveDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetAllNodeData", ReplyAction="http://tempuri.org/IRoadmapService/GetAllNodeDataResponse")]
        System.Tuple<SchedulingClients.RoadmapServiceReference.NodeData[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetAllNodeData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetAllNodeData", ReplyAction="http://tempuri.org/IRoadmapService/GetAllNodeDataResponse")]
        System.Threading.Tasks.Task<System.Tuple<SchedulingClients.RoadmapServiceReference.NodeData[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetAllNodeDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetMappingKeyCardSignature", ReplyAction="http://tempuri.org/IRoadmapService/GetMappingKeyCardSignatureResponse")]
        System.Tuple<byte[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetMappingKeyCardSignature();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetMappingKeyCardSignature", ReplyAction="http://tempuri.org/IRoadmapService/GetMappingKeyCardSignatureResponse")]
        System.Threading.Tasks.Task<System.Tuple<byte[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetMappingKeyCardSignatureAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetTrajectory", ReplyAction="http://tempuri.org/IRoadmapService/GetTrajectoryResponse")]
        System.Tuple<SchedulingClients.RoadmapServiceReference.WaypointData[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetTrajectory(int moveId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoadmapService/GetTrajectory", ReplyAction="http://tempuri.org/IRoadmapService/GetTrajectoryResponse")]
        System.Threading.Tasks.Task<System.Tuple<SchedulingClients.RoadmapServiceReference.WaypointData[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetTrajectoryAsync(int moveId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRoadmapServiceChannel : SchedulingClients.RoadmapServiceReference.IRoadmapService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RoadmapServiceClient : System.ServiceModel.ClientBase<SchedulingClients.RoadmapServiceReference.IRoadmapService>, SchedulingClients.RoadmapServiceReference.IRoadmapService {
        
        public RoadmapServiceClient() {
        }
        
        public RoadmapServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RoadmapServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoadmapServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RoadmapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Tuple<SchedulingClients.RoadmapServiceReference.MoveData[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetAllMoveData() {
            return base.Channel.GetAllMoveData();
        }
        
        public System.Threading.Tasks.Task<System.Tuple<SchedulingClients.RoadmapServiceReference.MoveData[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetAllMoveDataAsync() {
            return base.Channel.GetAllMoveDataAsync();
        }
        
        public System.Tuple<SchedulingClients.RoadmapServiceReference.NodeData[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetAllNodeData() {
            return base.Channel.GetAllNodeData();
        }
        
        public System.Threading.Tasks.Task<System.Tuple<SchedulingClients.RoadmapServiceReference.NodeData[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetAllNodeDataAsync() {
            return base.Channel.GetAllNodeDataAsync();
        }
        
        public System.Tuple<byte[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetMappingKeyCardSignature() {
            return base.Channel.GetMappingKeyCardSignature();
        }
        
        public System.Threading.Tasks.Task<System.Tuple<byte[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetMappingKeyCardSignatureAsync() {
            return base.Channel.GetMappingKeyCardSignatureAsync();
        }
        
        public System.Tuple<SchedulingClients.RoadmapServiceReference.WaypointData[], SchedulingClients.RoadmapServiceReference.ServiceCallData> GetTrajectory(int moveId) {
            return base.Channel.GetTrajectory(moveId);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<SchedulingClients.RoadmapServiceReference.WaypointData[], SchedulingClients.RoadmapServiceReference.ServiceCallData>> GetTrajectoryAsync(int moveId) {
            return base.Channel.GetTrajectoryAsync(moveId);
        }
    }
}
