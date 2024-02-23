using FluentValidation;

namespace N5Challenge.Application.Permissions.Commands.ModifyPermission
{
    public class ModifyPermissionCommandValidator : AbstractValidator<ModifyPermissionCommand>
    {
        public ModifyPermissionCommandValidator()
        {
            RuleFor(x => x.PermissionId).NotEmpty();
            RuleFor(x => x.EmployeeName).MinimumLength(3).MaximumLength(60);
            RuleFor(x => x.EmployeeSurname).MinimumLength(3).MaximumLength(80);
            RuleFor(x => x.PermissionTypeId).NotEmpty();
        }
    }
}
