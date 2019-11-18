﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Restaurant_", Namespace="http://schemas.datacontract.org/2004/07/MoodWcfService.Entities")]
    public partial class Restaurant_ : object
    {
        
        private decimal AvgExperienceField;
        
        private decimal AvgMoodField;
        
        private decimal AvgPriceField;
        
        private string NameField;
        
        private int RestaurantIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal AvgExperience
        {
            get
            {
                return this.AvgExperienceField;
            }
            set
            {
                this.AvgExperienceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal AvgMood
        {
            get
            {
                return this.AvgMoodField;
            }
            set
            {
                this.AvgMoodField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal AvgPrice
        {
            get
            {
                return this.AvgPriceField;
            }
            set
            {
                this.AvgPriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RestaurantId
        {
            get
            {
                return this.RestaurantIdField;
            }
            set
            {
                this.RestaurantIdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RestaurantServiceReference.IRestaurantService")]
    public interface IRestaurantService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetAllRestaurants", ReplyAction="http://tempuri.org/IRestaurantService/GetAllRestaurantsResponse")]
        System.Threading.Tasks.Task<RestaurantServiceReference.Restaurant_[]> GetAllRestaurantsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/GetRestaurantById", ReplyAction="http://tempuri.org/IRestaurantService/GetRestaurantByIdResponse")]
        System.Threading.Tasks.Task<RestaurantServiceReference.Restaurant_> GetRestaurantByIdAsync(string restId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/CreateRestaurant", ReplyAction="http://tempuri.org/IRestaurantService/CreateRestaurantResponse")]
        System.Threading.Tasks.Task<bool> CreateRestaurantAsync(RestaurantServiceReference.Restaurant_ restaurant);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/EditRestaurant", ReplyAction="http://tempuri.org/IRestaurantService/EditRestaurantResponse")]
        System.Threading.Tasks.Task<bool> EditRestaurantAsync(RestaurantServiceReference.Restaurant_ restaurant);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRestaurantService/DeleteRestaurant", ReplyAction="http://tempuri.org/IRestaurantService/DeleteRestaurantResponse")]
        System.Threading.Tasks.Task<bool> DeleteRestaurantAsync(RestaurantServiceReference.Restaurant_ restaurant);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public interface IRestaurantServiceChannel : RestaurantServiceReference.IRestaurantService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public partial class RestaurantServiceClient : System.ServiceModel.ClientBase<RestaurantServiceReference.IRestaurantService>, RestaurantServiceReference.IRestaurantService
    {
        
        public RestaurantServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<RestaurantServiceReference.Restaurant_[]> GetAllRestaurantsAsync()
        {
            return base.Channel.GetAllRestaurantsAsync();
        }
        
        public System.Threading.Tasks.Task<RestaurantServiceReference.Restaurant_> GetRestaurantByIdAsync(string restId)
        {
            return base.Channel.GetRestaurantByIdAsync(restId);
        }
        
        public System.Threading.Tasks.Task<bool> CreateRestaurantAsync(RestaurantServiceReference.Restaurant_ restaurant)
        {
            return base.Channel.CreateRestaurantAsync(restaurant);
        }
        
        public System.Threading.Tasks.Task<bool> EditRestaurantAsync(RestaurantServiceReference.Restaurant_ restaurant)
        {
            return base.Channel.EditRestaurantAsync(restaurant);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteRestaurantAsync(RestaurantServiceReference.Restaurant_ restaurant)
        {
            return base.Channel.DeleteRestaurantAsync(restaurant);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
    }
}
