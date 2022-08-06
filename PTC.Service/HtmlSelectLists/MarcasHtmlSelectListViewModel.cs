using Microsoft.AspNetCore.Mvc.Rendering;
using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Application.HtmlSelectLists
{
    public class MarcasHtmlSelectListViewModel : BaseHtmlSelectList
    {
        public MarcasHtmlSelectListViewModel() : base(){ }

        public override void DefiniSelect(IEnumerable<object> value)
        {
            Select.Add(new SelectListItem { Value = "", Text = "Nenhum" });

            foreach (Marca item in value)
            {
                Select.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }
        }
    }
}
