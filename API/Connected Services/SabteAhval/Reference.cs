﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SabteAhval
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonInfo", Namespace="http://tempuri.org/")]
    public partial class PersonInfo : object
    {
        
        private string BirthDateField;
        
        private string BookNoField;
        
        private string BookRowField;
        
        private string DeathStatusField;
        
        private string FamilyField;
        
        private string FatherNameField;
        
        private string GenderField;
        
        private string NameField;
        
        private string NINField;
        
        private string OfficeCodeField;
        
        private string OfficeNameField;
        
        private string ShenasnameNoField;
        
        private string ShenasnameSeriField;
        
        private string ShenasnameSerialField;
        
        private SabteAhval.ArrayOfString MessageField;
        
        private string ImageField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string BirthDate
        {
            get
            {
                return this.BirthDateField;
            }
            set
            {
                this.BirthDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string BookNo
        {
            get
            {
                return this.BookNoField;
            }
            set
            {
                this.BookNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string BookRow
        {
            get
            {
                return this.BookRowField;
            }
            set
            {
                this.BookRowField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string DeathStatus
        {
            get
            {
                return this.DeathStatusField;
            }
            set
            {
                this.DeathStatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Family
        {
            get
            {
                return this.FamilyField;
            }
            set
            {
                this.FamilyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string FatherName
        {
            get
            {
                return this.FatherNameField;
            }
            set
            {
                this.FatherNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Gender
        {
            get
            {
                return this.GenderField;
            }
            set
            {
                this.GenderField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string NIN
        {
            get
            {
                return this.NINField;
            }
            set
            {
                this.NINField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string OfficeCode
        {
            get
            {
                return this.OfficeCodeField;
            }
            set
            {
                this.OfficeCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string OfficeName
        {
            get
            {
                return this.OfficeNameField;
            }
            set
            {
                this.OfficeNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string ShenasnameNo
        {
            get
            {
                return this.ShenasnameNoField;
            }
            set
            {
                this.ShenasnameNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string ShenasnameSeri
        {
            get
            {
                return this.ShenasnameSeriField;
            }
            set
            {
                this.ShenasnameSeriField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string ShenasnameSerial
        {
            get
            {
                return this.ShenasnameSerialField;
            }
            set
            {
                this.ShenasnameSerialField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public SabteAhval.ArrayOfString Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string Image
        {
            get
            {
                return this.ImageField;
            }
            set
            {
                this.ImageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="http://tempuri.org/", ItemName="string")]
    public class ArrayOfString : System.Collections.Generic.List<string>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SabteAhval.InquiryPersonInfoSoap")]
    public interface InquiryPersonInfoSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetPersonInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SabteAhval.GetPersonInfoResponse> GetPersonInfoAsync(SabteAhval.GetPersonInfoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetPersonInfoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetPersonInfo", Namespace="http://tempuri.org/", Order=0)]
        public SabteAhval.GetPersonInfoRequestBody Body;
        
        public GetPersonInfoRequest()
        {
        }
        
        public GetPersonInfoRequest(SabteAhval.GetPersonInfoRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetPersonInfoRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string nationalCode;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string birthDate;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string userName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string password;
        
        public GetPersonInfoRequestBody()
        {
        }
        
        public GetPersonInfoRequestBody(string nationalCode, string birthDate, string userName, string password)
        {
            this.nationalCode = nationalCode;
            this.birthDate = birthDate;
            this.userName = userName;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetPersonInfoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetPersonInfoResponse", Namespace="http://tempuri.org/", Order=0)]
        public SabteAhval.GetPersonInfoResponseBody Body;
        
        public GetPersonInfoResponse()
        {
        }
        
        public GetPersonInfoResponse(SabteAhval.GetPersonInfoResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetPersonInfoResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SabteAhval.PersonInfo GetPersonInfoResult;
        
        public GetPersonInfoResponseBody()
        {
        }
        
        public GetPersonInfoResponseBody(SabteAhval.PersonInfo GetPersonInfoResult)
        {
            this.GetPersonInfoResult = GetPersonInfoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    public interface InquiryPersonInfoSoapChannel : SabteAhval.InquiryPersonInfoSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30310-0943")]
    public partial class InquiryPersonInfoSoapClient : System.ServiceModel.ClientBase<SabteAhval.InquiryPersonInfoSoap>, SabteAhval.InquiryPersonInfoSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public InquiryPersonInfoSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(InquiryPersonInfoSoapClient.GetBindingForEndpoint(endpointConfiguration), InquiryPersonInfoSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InquiryPersonInfoSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(InquiryPersonInfoSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InquiryPersonInfoSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(InquiryPersonInfoSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public InquiryPersonInfoSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SabteAhval.GetPersonInfoResponse> SabteAhval.InquiryPersonInfoSoap.GetPersonInfoAsync(SabteAhval.GetPersonInfoRequest request)
        {
            return base.Channel.GetPersonInfoAsync(request);
        }
        

        public System.Threading.Tasks.Task<SabteAhval.GetPersonInfoResponse> GetPersonInfoAsync(string nationalCode, string birthDate, string userName, string password)
        {
            SabteAhval.GetPersonInfoRequest inValue = new SabteAhval.GetPersonInfoRequest();
            inValue.Body = new SabteAhval.GetPersonInfoRequestBody();
            inValue.Body.nationalCode = nationalCode;
            inValue.Body.birthDate = birthDate;
            inValue.Body.userName = userName;
            inValue.Body.password = password;
            return ((SabteAhval.InquiryPersonInfoSoap)(this)).GetPersonInfoAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.InquiryPersonInfoSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.InquiryPersonInfoSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.InquiryPersonInfoSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://smart.internalhost.ir/webservices/InquiryPersonInfo.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.InquiryPersonInfoSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://smart.internalhost.ir/webservices/InquiryPersonInfo.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            InquiryPersonInfoSoap,
            
            InquiryPersonInfoSoap12,
        }
    }
}