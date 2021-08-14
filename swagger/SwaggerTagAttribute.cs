using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingticketAPI.swagger
{
    public class SwaggerTagAttribute
    {

        public string HeaderName { get; }
        public string Description { get; }
        public string DefaultValue { get; }
        public bool IsRequired { get; }

        public SwaggerTagAttribute(string headerName, string description = null, string defaultValue = null, bool isRequired = false)
        {
            HeaderName = headerName;
            Description = description;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
        }
    }
}
