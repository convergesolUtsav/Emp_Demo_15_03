namespace employee_demo.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
