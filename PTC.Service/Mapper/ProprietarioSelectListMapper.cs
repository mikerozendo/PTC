using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using PTC.Application.Dtos;
using PTC.Domain.Entities;

namespace PTC.Application.Mapper
{
    public static class ProprietarioSelectListMapper
    {
        public static OperacaoViewModel ToViewModel(this IEnumerable<Proprietario> domain)
        {
            var proprietario = new OperacaoViewModel();
            proprietario.ProprietariosHtmlSelectList.Add(new SelectListItem { Value = "", Text = "Nenhum" });

            foreach (Proprietario item in domain)
            {
                proprietario.ProprietariosHtmlSelectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }

            return proprietario;
        }
    }
}
