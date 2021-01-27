using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Client.Shared
{
    public class BlogHeaderBase : ComponentBase
    {
        [Parameter]
        public string Heading { get; set; }

        [Parameter]
        public string SubHeading { get; set; }

        [Parameter]
        public string Author { get; set; }

        [Parameter]
        public DateTimeOffset PostedDate  { get; set; }
    }
}
