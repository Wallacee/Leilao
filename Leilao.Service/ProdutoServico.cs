using Leilao.DataAccess;
using Leilao.Infra;
using Leilao.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.Service
{
    public class ProdutoServico
    {
        private LeilaoContexto LeilaoContexto;
        public ProdutoServico()
        {
            LeilaoContexto = new LeilaoContexto();
        }
        public ResultProcessing Adicionar(Produto produto)
        {
            ResultProcessing result = new ResultProcessing();

            try
            {
                if (produto.Id == 0)
                {
                    LeilaoContexto.Entry(produto).State = EntityState.Added;
                    result.Message = "Salvo com sucesso";
                }
                else
                {
                    LeilaoContexto.Entry(produto).State = EntityState.Modified;
                    result.Message = "Editado com sucesso";
                }
                result.Success = true;
                LeilaoContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Falha ao atualizar";
            }

            return result;
        }

        public string BuscarNome(int produtoId)
        {
            string nome;
            try
            {
                nome = LeilaoContexto.Produtos.FirstOrDefault(p => p.Id == produtoId).Nome;
            }
            catch (Exception)
            {

                nome = "";
            }
            return nome;
        }

        public List<Produto> ListarTodos()
        {
            List<Produto> listProdutos;
            try
            {
                listProdutos = LeilaoContexto.Produtos.ToList();
            }
            catch (Exception ex)
            {

                listProdutos = null;
            }
            return listProdutos;

        }
    }
}
