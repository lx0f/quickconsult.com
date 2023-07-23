using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickConsult.Models;

namespace QuickConsult.Pages.Doctor
{

    public class DashboardModel : PageModel
    {
        private UserManager<User> _userManager;

        private readonly QsContext _qsContext;
        public DashboardModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public List<Appointment> Appointments { get; set;}
        [BindProperty]
        public int appointmentCount { get; set; }
        public void OnGet()
        {
            var user = _userManager.GetUserName(User);
            Appointments = _qsContext.Appointments.Where(x => x.Doctor.Nric == user).ToList();
            appointmentCount = Appointments.Count;
            //get payments and appointments and store count and bind
        }
    }
}
