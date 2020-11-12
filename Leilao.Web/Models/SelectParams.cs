using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leilao.Web.Models
{
    public class SelectParams
    {
        public int Current { get; set; }
        public int rowCount { get; set; }
        public string SearchPhrase { get; set; }
        public string Id { get; set; }

        public CampoOrdenado ObterCampoOrdenado(HttpRequestBase request)
        {
            string campo = request.Form.AllKeys.Where(k => k.StartsWith("sort[")).FirstOrDefault();
            string ordenacao = request.Form[campo];
            ordenacao = ordenacao != null ? ordenacao : campo != null ? "" : "asc";
            campo = campo != null ? campo.TrimStart("sort[".ToCharArray()).TrimEnd(']') : "Id";
            return new CampoOrdenado() { Campo = campo, Ordem = ordenacao };
        }
    }
}