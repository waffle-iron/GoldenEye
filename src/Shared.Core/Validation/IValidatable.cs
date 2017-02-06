

namespace GoldenEye.Shared.Core.Validation
{
    public interface IValidatable //: IValidatableObject
    {
        FluentValidation.Results.ValidationResult Validate();
    }
}
