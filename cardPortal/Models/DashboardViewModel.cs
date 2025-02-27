namespace cardPortal.Models
{
    public class DashboardViewModel
    {
        public required List<Login> Logins { get; set; }
        public required List<Change> Changes { get; set; }
    }
}
