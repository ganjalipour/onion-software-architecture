using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Common.Utility.Extentions
{
    public class CustomStringModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            string valueFromBody = string.Empty;

            using (var stream = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody = await stream.ReadToEndAsync();
            }

            if (string.IsNullOrEmpty(valueFromBody))
            {
                return;
            }
            string values = valueFromBody.Replace((char)1610, (char)1609).Replace((char)1603, (char)1705);
            var modelType = bindingContext.ModelMetadata.UnderlyingOrModelType;
            try
            {
                var modelInstance = JsonConvert.DeserializeObject(values, modelType);
                bindingContext.Result = ModelBindingResult.Success(modelInstance);
                return;
            }
            catch
            {
                //return Task.CompletedTask;
                return;
            }
        }
    }
}


 



