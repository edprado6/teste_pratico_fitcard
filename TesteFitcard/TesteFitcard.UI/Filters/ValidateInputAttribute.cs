//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TesteFitcard.UI.Filters
//{
//    /// <summary>
//    /// Classe responsável pela validação das models. 
//    /// </summary>
//    public class ValidateInputAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            if (context.ModelState.IsValid)
//                return;

//            context.Result = new BadRequestObjectResult(context.ModelState);
//        }
//    }
//}
