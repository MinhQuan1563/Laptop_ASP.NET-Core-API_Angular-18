using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WAAL.API.Extensions
{
    public static class ModelStateExtend
    {
        public static void AddModelError(this ModelStateDictionary modelState, string error)
        {
            modelState.AddModelError(string.Empty, error);
        }
        public static void AddModelError(this ModelStateDictionary ModelState, IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Description);
            }
        }
    }
}
