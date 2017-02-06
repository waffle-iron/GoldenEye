using System.Runtime.Serialization;
using GoldenEye.Shared.Core.Context;
using GoldenEye.Shared.Core.Validation;

namespace GoldenEye.Shared.Core.Objects.Requests
{
    [DataContract]
    public abstract class RequestBase : ValidatableObjectBase, IRequest
    {
        protected RequestBase()
        {
            //RequesterUserID = StaticManager.User.Id;
            //RequesterCultureName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            RequesterIP = UserContext.ClientIP;
            RequesterDNS = UserContext.ClientDNS;
            RequesterBrowser = UserContext.ClientBrowser;
        }

        //[DataMember(Order = 0)]
        //public Guid RequesterUserID { get; set; }

         
        public string RequesterCultureName { get; set; }

         
        public string RequesterIP = string.Empty;

         
        public string RequesterDNS = string.Empty;

         
        public string RequesterBrowser = string.Empty;
    }
}