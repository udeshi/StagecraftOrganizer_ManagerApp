﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StagecraftOrganizer_ManagerApp.StagecraftOrganizingService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SeatDetails", Namespace="http://schemas.datacontract.org/2004/07/StagecraftOrganizingService.DataContracts" +
        "")]
    [System.SerializableAttribute()]
    public partial class SeatDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BgColourField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BlockNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FloorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAvailableSeatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RowNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SeatNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.TicketDetails TicketDetailsField;
        
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
        public string BgColour {
            get {
                return this.BgColourField;
            }
            set {
                if ((object.ReferenceEquals(this.BgColourField, value) != true)) {
                    this.BgColourField = value;
                    this.RaisePropertyChanged("BgColour");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BlockNo {
            get {
                return this.BlockNoField;
            }
            set {
                if ((this.BlockNoField.Equals(value) != true)) {
                    this.BlockNoField = value;
                    this.RaisePropertyChanged("BlockNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Floor {
            get {
                return this.FloorField;
            }
            set {
                if ((this.FloorField.Equals(value) != true)) {
                    this.FloorField = value;
                    this.RaisePropertyChanged("Floor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAvailableSeat {
            get {
                return this.IsAvailableSeatField;
            }
            set {
                if ((this.IsAvailableSeatField.Equals(value) != true)) {
                    this.IsAvailableSeatField = value;
                    this.RaisePropertyChanged("IsAvailableSeat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RowNo {
            get {
                return this.RowNoField;
            }
            set {
                if ((this.RowNoField.Equals(value) != true)) {
                    this.RowNoField = value;
                    this.RaisePropertyChanged("RowNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SeatNo {
            get {
                return this.SeatNoField;
            }
            set {
                if ((this.SeatNoField.Equals(value) != true)) {
                    this.SeatNoField = value;
                    this.RaisePropertyChanged("SeatNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.TicketDetails TicketDetails {
            get {
                return this.TicketDetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.TicketDetailsField, value) != true)) {
                    this.TicketDetailsField = value;
                    this.RaisePropertyChanged("TicketDetails");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TicketDetails", Namespace="http://schemas.datacontract.org/2004/07/StagecraftOrganizingService.DataContracts" +
        "")]
    [System.SerializableAttribute()]
    public partial class TicketDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TicketNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TicketPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TicketTypeField;
        
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
        public int TicketNo {
            get {
                return this.TicketNoField;
            }
            set {
                if ((this.TicketNoField.Equals(value) != true)) {
                    this.TicketNoField = value;
                    this.RaisePropertyChanged("TicketNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TicketPrice {
            get {
                return this.TicketPriceField;
            }
            set {
                if ((this.TicketPriceField.Equals(value) != true)) {
                    this.TicketPriceField = value;
                    this.RaisePropertyChanged("TicketPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TicketType {
            get {
                return this.TicketTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TicketTypeField, value) != true)) {
                    this.TicketTypeField = value;
                    this.RaisePropertyChanged("TicketType");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StagecraftOrganizingService.IStagecraftOrganizingService", CallbackContract=typeof(StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.IStagecraftOrganizingServiceCallback))]
    public interface IStagecraftOrganizingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/Connect", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/ConnectResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/ConnectApplicationExceptionFault", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/RequestUpdatedSeatList", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/RequestUpdatedSeatListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/RequestUpdatedSeatListApplication" +
            "ExceptionFault", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void RequestUpdatedSeatList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/BookSeats", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/BookSeatsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/BookSeatsApplicationExceptionFaul" +
            "t", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void BookSeats(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> seatDetailsList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/DeleteBookedSeat", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/DeleteBookedSeatResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/DeleteBookedSeatApplicationExcept" +
            "ionFault", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void DeleteBookedSeat(int userId, StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails seatDetails);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/CheckAvailibility", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/CheckAvailibilityResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/CheckAvailibilityApplicationExcep" +
            "tionFault", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void CheckAvailibility(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> seatDetailsList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/RequestMoreSeats", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/RequestMoreSeatsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/RequestMoreSeatsApplicationExcept" +
            "ionFault", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void RequestMoreSeats(int userId, int noOfSeatsNeeded);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/SendUpdatedList", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/SendUpdatedListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/SendUpdatedListApplicationExcepti" +
            "onFault", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void SendUpdatedList(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> updatedSeatDetailsList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStagecraftOrganizingService/Disconnect", ReplyAction="http://tempuri.org/IStagecraftOrganizingService/DisconnectResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ApplicationException), Action="http://tempuri.org/IStagecraftOrganizingService/DisconnectApplicationExceptionFau" +
            "lt", Name="ApplicationException", Namespace="http://schemas.datacontract.org/2004/07/System")]
        void Disconnect();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStagecraftOrganizingServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStagecraftOrganizingService/SendUpdatedSeatingList")]
        void SendUpdatedSeatingList(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> seatingList);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStagecraftOrganizingService/NotifyToGetUpdatedSeatingList")]
        void NotifyToGetUpdatedSeatingList();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStagecraftOrganizingService/SendBookedSeatDetailsToDelete")]
        void SendBookedSeatDetailsToDelete(int userId, StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails seatDetails);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStagecraftOrganizingService/NotifyToCheckAvailabiltyOfSeats")]
        void NotifyToCheckAvailabiltyOfSeats(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> seatDetails);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStagecraftOrganizingService/SendAvailabiltyOfSeats")]
        void SendAvailabiltyOfSeats(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> seatDetails);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStagecraftOrganizingService/SendRequestForMoreTickets")]
        void SendRequestForMoreTickets(int userId, int noOfSeatsNeeded);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStagecraftOrganizingServiceChannel : StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.IStagecraftOrganizingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StagecraftOrganizingServiceClient : System.ServiceModel.DuplexClientBase<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.IStagecraftOrganizingService>, StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.IStagecraftOrganizingService {
        
        public StagecraftOrganizingServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public StagecraftOrganizingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public StagecraftOrganizingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StagecraftOrganizingServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StagecraftOrganizingServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect() {
            base.Channel.Connect();
        }
        
        public void RequestUpdatedSeatList() {
            base.Channel.RequestUpdatedSeatList();
        }
        
        public void BookSeats(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> seatDetailsList) {
            base.Channel.BookSeats(seatDetailsList);
        }
        
        public void DeleteBookedSeat(int userId, StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails seatDetails) {
            base.Channel.DeleteBookedSeat(userId, seatDetails);
        }
        
        public void CheckAvailibility(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> seatDetailsList) {
            base.Channel.CheckAvailibility(seatDetailsList);
        }
        
        public void RequestMoreSeats(int userId, int noOfSeatsNeeded) {
            base.Channel.RequestMoreSeats(userId, noOfSeatsNeeded);
        }
        
        public void SendUpdatedList(System.Collections.Generic.List<StagecraftOrganizer_ManagerApp.StagecraftOrganizingService.SeatDetails> updatedSeatDetailsList) {
            base.Channel.SendUpdatedList(updatedSeatDetailsList);
        }
        
        public void Disconnect() {
            base.Channel.Disconnect();
        }
    }
}