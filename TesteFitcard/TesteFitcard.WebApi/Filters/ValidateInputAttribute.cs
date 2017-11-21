using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TesteFitcard.WebApi.Filters
{
    /// <summary>
    /// Classe responsável pela validação das models. 
    /// </summary>
    public class ValidateInputAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
