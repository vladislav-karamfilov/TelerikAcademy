﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18213
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DayOfWeekInBulgarianConsoleClient.DayOfWeekInBulgarianService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DayOfWeekInBulgarianService.IDayOfWeekInBulgarianService")]
    public interface IDayOfWeekInBulgarianService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayOfWeekInBulgarianService/GetDayOfWeekInBulgarian", ReplyAction="http://tempuri.org/IDayOfWeekInBulgarianService/GetDayOfWeekInBulgarianResponse")]
        string GetDayOfWeekInBulgarian(System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayOfWeekInBulgarianService/GetDayOfWeekInBulgarian", ReplyAction="http://tempuri.org/IDayOfWeekInBulgarianService/GetDayOfWeekInBulgarianResponse")]
        System.Threading.Tasks.Task<string> GetDayOfWeekInBulgarianAsync(System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDayOfWeekInBulgarianServiceChannel : DayOfWeekInBulgarianConsoleClient.DayOfWeekInBulgarianService.IDayOfWeekInBulgarianService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DayOfWeekInBulgarianServiceClient : System.ServiceModel.ClientBase<DayOfWeekInBulgarianConsoleClient.DayOfWeekInBulgarianService.IDayOfWeekInBulgarianService>, DayOfWeekInBulgarianConsoleClient.DayOfWeekInBulgarianService.IDayOfWeekInBulgarianService {
        
        public DayOfWeekInBulgarianServiceClient() {
        }
        
        public DayOfWeekInBulgarianServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DayOfWeekInBulgarianServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayOfWeekInBulgarianServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayOfWeekInBulgarianServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetDayOfWeekInBulgarian(System.DateTime date) {
            return base.Channel.GetDayOfWeekInBulgarian(date);
        }
        
        public System.Threading.Tasks.Task<string> GetDayOfWeekInBulgarianAsync(System.DateTime date) {
            return base.Channel.GetDayOfWeekInBulgarianAsync(date);
        }
    }
}
