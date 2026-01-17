using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CitrusMicroblog.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        
        public FormMessage message { get; set; }
        [BindNever]
        [ValidateNever]
        public IEnumerable<NewsTopic> topics { get; set; }
    }
}
