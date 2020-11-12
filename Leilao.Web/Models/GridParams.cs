using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.Web.Models
{
    public class GridParams
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public SearchPhrase Search { get; set; }
        public CampoOrdenado ObterCampoOrdenado(HttpRequestBase request)
        {
            var campoData = request.Form.GetValues("columns[" + request.Form.GetValues("order[0][column]").FirstOrDefault() + "][data]").FirstOrDefault();
            var campoNome = request.Form.GetValues("columns[" + request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();

            var ordenacao = request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var campo = campoNome != "" ? campoNome : campoData;
            campo = campo != "" ? campo : "Id";
            return new CampoOrdenado() { Campo = campo, Ordem = ordenacao };
        }
    }

    public class SearchPhrase
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

    public class CampoOrdenado
    {
        public string Campo { get; set; }
        public string Ordem { get; set; }
    }
}