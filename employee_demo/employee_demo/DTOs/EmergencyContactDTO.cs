namespace employee_demo.DTOs
{
    public class EmergencyContactDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string Relation { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
