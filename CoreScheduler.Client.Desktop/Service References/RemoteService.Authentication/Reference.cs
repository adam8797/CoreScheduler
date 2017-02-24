﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreScheduler.Client.Desktop.RemoteService.Authentication {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RemoteService.Authentication.IAuthenticationService")]
    public interface IAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Authenticate", ReplyAction="http://tempuri.org/IAuthenticationService/AuthenticateResponse")]
        bool Authenticate(string username, string password, string terminal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/Authenticate", ReplyAction="http://tempuri.org/IAuthenticationService/AuthenticateResponse")]
        System.Threading.Tasks.Task<bool> AuthenticateAsync(string username, string password, string terminal);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : CoreScheduler.Client.Desktop.RemoteService.Authentication.IAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<CoreScheduler.Client.Desktop.RemoteService.Authentication.IAuthenticationService>, CoreScheduler.Client.Desktop.RemoteService.Authentication.IAuthenticationService {
        
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Authenticate(string username, string password, string terminal) {
            return base.Channel.Authenticate(username, password, terminal);
        }
        
        public System.Threading.Tasks.Task<bool> AuthenticateAsync(string username, string password, string terminal) {
            return base.Channel.AuthenticateAsync(username, password, terminal);
        }
    }
}