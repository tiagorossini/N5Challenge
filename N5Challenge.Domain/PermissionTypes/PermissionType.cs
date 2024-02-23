namespace N5Challenge.Domain.PermissionTypes
{
    public class PermissionType
    {
        public int Id { get; }
        public string Description { get; }

        public PermissionType(string description)
        {
            Description = description;
        }

        private PermissionType()
        {

        }
    }
}
