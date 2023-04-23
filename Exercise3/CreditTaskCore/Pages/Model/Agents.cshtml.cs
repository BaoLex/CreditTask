using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreditTaskCore.Pages.Model
{
    public class AgentsModel : PageModel
    {
        public List<AgentsInfo> 
        public void OnGet()
        {

        }
    }

    public class AgentsInfo
    {
        public String? AgentID { get; set; }
        public String? AgentName { get; set; }
        public String? Address { get; set; }
    }
}
