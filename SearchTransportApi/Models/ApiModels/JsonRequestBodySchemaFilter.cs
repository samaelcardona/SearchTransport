using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SearchTransportApi.Models.ApiModels
{
    public class JsonRequestBodySchemaFilter<T> : ISchemaFilter
    {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(T))
            {
                schema.Example = new OpenApiObject
                {
                    ["LocationName"] = new OpenApiString("locacion 1"),
                    ["ClientLocationName"] = new OpenApiString("locacion 2")
                };
            }
        }
    }
}
