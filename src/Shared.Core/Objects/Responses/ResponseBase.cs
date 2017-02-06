using System.Runtime.Serialization;

namespace GoldenEye.Shared.Core.Objects.Responses
{
    [DataContract]
    public abstract class ResponseBase : IResponse//ValidatableObjectBase
    {
         
        //public FluentValidation.Results.ValidationResult ValidationResult { get; set; }

        //public ResponseBase()
        //{
        //    ValidationResult = new FluentValidation.Results.ValidationResult();
        //}
    }
}