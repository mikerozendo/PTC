using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Application.HtmlSelectLists
{
    public abstract class BaseHtmlSelectList
    {
        public List<SelectListItem> Select { get; set; } = new();

        public abstract void DefiniSelect(IEnumerable<object> value);
    }
}
