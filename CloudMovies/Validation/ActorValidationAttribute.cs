using CloudMovies.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CloudMovies.Service.Validation
{
    public class ActorValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var item in context.ActionArguments)
            {
                var actor = item.Value as Actor;
                if (actor == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(actor.FirstName) &&
                    string.IsNullOrEmpty(actor.LastName))
                {
                    context.ModelState.AddModelError("ActorValidationError",
                        $"{nameof(actor.FirstName)} and {nameof(actor.LastName)} can't be empty.");
                }

                break;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
