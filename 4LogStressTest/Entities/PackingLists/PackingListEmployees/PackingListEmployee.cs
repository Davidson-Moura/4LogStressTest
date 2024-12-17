namespace Api.Domain.Entities.PackingLists.PackingListEmployees
{
    public class PackingListEmployee
    {
        public int Id { get; set; }
        public bool? Sel { get; set; }
        public int? PackingListId { get; set; }
        public int? EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string RoleName { get; set; }
    }
}
