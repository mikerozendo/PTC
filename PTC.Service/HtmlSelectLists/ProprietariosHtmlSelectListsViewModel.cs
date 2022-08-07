using Microsoft.AspNetCore.Mvc.Rendering;
using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Application.HtmlSelectLists
{
    public class ProprietariosHtmlSelectListsViewModel : BaseHtmlSelectList
    {
        public ProprietariosHtmlSelectListsViewModel() : base() { }

        public override void DefiniSelect(IEnumerable<object> value)
        {
            Select.Add(new SelectListItem { Value = "", Text = "Nenhum" });

            foreach (Proprietario item in value)
            {
                Select.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }
        }
    }
}
