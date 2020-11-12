using Leilao.DataAccess;
using Leilao.Infra;
using Leilao.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;


namespace Leilao.Service
{
    public class LanceServico
    {
        private LeilaoContexto LeilaoContexto;
        public LanceServico()
        {
            LeilaoContexto = new LeilaoContexto();
        }
        public ResultProcessing Adicionar(Lance lance)
        {
            ResultProcessing result = new ResultProcessing();

            try
            {
                if (lance.Id == 0)
                {
                    LeilaoContexto.Entry(lance).State = EntityState.Added;
                    result.Message = "Salvo com sucesso";
                }
                else
                {
                    LeilaoContexto.Entry(lance).State = EntityState.Modified;
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

        public bool ELanceValido(int idProduto, float valor)
        {
            return LeilaoContexto.Produtos.FirstOrDefault(l => l.Id == idProduto).Valor < valor;
        }

        public float BusvarValorAtual(int idProduto)
        {
            float valor = LeilaoContexto.Produtos.FirstOrDefault(p => p.Id == idProduto).Valor;
            return valor;
        }

        public ResultProcessing Salvar(int idProduto, float valor, int idPessoa)
        {
            ResultProcessing result = new ResultProcessing();

            if (ELanceValido(idProduto, valor))
            {
                Lance lance = new Lance
                {
                    PessoaId = idPessoa,
                    ProdutoId = idProduto,
                    Valor = valor
                };
                LeilaoContexto.Entry(lance).State = EntityState.Added;
                LeilaoContexto.SaveChanges();
                Produto produto = LeilaoContexto.Produtos.FirstOrDefault(l => l.Id == idProduto);
                produto.Valor = valor;
                LeilaoContexto.Entry(lance).State = EntityState.Modified;
                LeilaoContexto.SaveChanges();
                result.Success = true;
                result.Message = "Parabéns, seu lance foi validado";

            }
            else
            {
                Lance lance = new Lance
                {
                    PessoaId = idPessoa,
                    ProdutoId = idProduto,
                    Valor = valor
                };
                LeilaoContexto.Entry(lance).State = EntityState.Added;
                LeilaoContexto.SaveChanges();
                result.Success = false;
                result.Message = "Seu lance não foi validado, deve ser maior que o valor atual!";
            }
            return result;
        }

        public DadosPaginados ListarPaginado(int inicio, int tamanho, string busca, string campoOrdenacao, string tipoOrdenacao)
        {
            campoOrdenacao += tipoOrdenacao.ToUpper().Equals("DESC") ? " DESCENDING" : "";


            var dadosFiltrados = LeilaoContexto.Lances.Where(i =>
                    (busca == null) || (i.Pessoa.Nome.ToUpper().Contains(busca.ToUpper()))
                ).Include("Pessoa").Include("Produto")
                .Select(i => new
                {
                    i.Id,
                    nomePessoa = i.Pessoa.Nome,
                    nomeProduto = i.Produto.Nome,
                    valor = i.Valor
                });

            dadosFiltrados = dadosFiltrados.OrderBy(campoOrdenacao);

            DadosPaginados dadosPaginados = new DadosPaginados();
            dadosPaginados.QuantidadePorPagina = tamanho;
            dadosPaginados.Total = dadosFiltrados.Count();

            if (tamanho < 0)
            {
                dadosPaginados.Dados = dadosFiltrados.Skip(inicio).ToList();
            }
            else
            {
                dadosPaginados.Dados = dadosFiltrados.Skip(inicio).Take(tamanho).ToList();
            }

            return dadosPaginados;
        }

        public List<Lance> ListarTodos()
        {
            List<Lance> listLances;
            try
            {
                listLances = LeilaoContexto.Lances.Include(p => p.Pessoa).Include(p => p.Produto).ToList();
            }
            catch (Exception ex)
            {

                listLances = null;
            }
            return listLances;
        }
    }
}
