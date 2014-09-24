﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Substring.Console.ServiceSubstring {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceSubstring.ISubstringService")]
    public interface ISubstringService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubstringService/GetNumberOfSubstrings", ReplyAction="http://tempuri.org/ISubstringService/GetNumberOfSubstringsResponse")]
        int GetNumberOfSubstrings(string text, string substring);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISubstringService/GetNumberOfSubstrings", ReplyAction="http://tempuri.org/ISubstringService/GetNumberOfSubstringsResponse")]
        System.Threading.Tasks.Task<int> GetNumberOfSubstringsAsync(string text, string substring);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISubstringServiceChannel : Substring.Console.ServiceSubstring.ISubstringService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubstringServiceClient : System.ServiceModel.ClientBase<Substring.Console.ServiceSubstring.ISubstringService>, Substring.Console.ServiceSubstring.ISubstringService {
        
        public SubstringServiceClient() {
        }
        
        public SubstringServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SubstringServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubstringServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SubstringServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetNumberOfSubstrings(string text, string substring) {
            return base.Channel.GetNumberOfSubstrings(text, substring);
        }
        
        public System.Threading.Tasks.Task<int> GetNumberOfSubstringsAsync(string text, string substring) {
            return base.Channel.GetNumberOfSubstringsAsync(text, substring);
        }
    }
}