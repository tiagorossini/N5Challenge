using FluentValidation;

namespace N5Challenge.Application.Permissions.Commands.RequestPermission
{
    public class RequestPermissionCommandValidator : AbstractValidator<RequestPermissionCommand>
    {
        public RequestPermissionCommandValidator()
        {
            RuleFor(x => x.EmployeeName).MinimumLength(3).MaximumLength(60);
            RuleFor(x => x.EmployeeSurname).MinimumLength(3).MaximumLength(80);
            RuleFor(x => x.PermissionTypeId).NotEmpty();
        }
    }
}
