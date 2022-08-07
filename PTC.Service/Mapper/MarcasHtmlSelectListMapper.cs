using Microsoft.AspNetCore.Mvc.Rendering;
using PTC.Application.HtmlSelectLists;
using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Application.Mapper
{
    public static class MarcasHtmlSelectListMapper
    {
        public static MarcasHtmlSelectListViewModel ToViewModel(this IEnumerable<Marca> domain)
        {
            var marca = new MarcasHtmlSelectListViewModel();
            marca.Select.Add(new SelectListItem { Value = "", Text = "Nenhum" });

            foreach (Marca item in domain)
            {
                marca.Select.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }

            return marca;
        }
    }
}
