using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.Infra
{
    public class ResultProcessing
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string AdditionalData { get; set; }
        public int Id { get; set; }
        public ResultProcessing()
        {
            Success = false;
            Message = "";
            AdditionalData = "";
            Id = 0;
        }
    }
}
