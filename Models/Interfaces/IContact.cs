namespace ContactAPI.Models.Interfaces
{
    public interface IContact
    {
        int ID { get; set; }
        string Email { get; set; }
        string Message { get; set; }
    }
}
