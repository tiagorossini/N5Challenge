namespace N5Challenge.Contracts.Permissions
{
    public record ModifyPermissionRequest(int PermissionId, string? EmployeeName, string? EmployeeSurname, int PermissionTypeId);
}
