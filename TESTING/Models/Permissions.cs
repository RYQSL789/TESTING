namespace TESTING.Models
{
    public class Permissions
    {
        public int Id { get; set; }
        public int PermissonType { get; set; }
        public string EmployeeForceName { get; set; } = "";
        public string EmployeeSuname { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime PermissionDate { get; set; }
        //public virtual PermissionTypes PermissionTypes { get; set; } = new PermissionTypes();

    }
}
