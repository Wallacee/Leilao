using Leilao.DataAccess;
using Leilao.Infra;
using Leilao.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Leilao.Service
{
    public class PessoaServico
    {
        private LeilaoContexto LeilaoContexto;
        public PessoaServico()
        {
            LeilaoContexto = new LeilaoContexto();
        }
        public ResultProcessing Adicionar(Pessoa pessoa)
        {
            ResultProcessing result = new ResultProcessing();

            try
            {
                if (pessoa.Id == 0) {
                    LeilaoContexto.Entry(pessoa).State = EntityState.Added;
                    result.Message = "Salvo com sucesso";
                }
                else
                {
                    LeilaoContexto.Entry(pessoa).State = EntityState.Modified;
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

        public string BuscarNome(int idPessoa)
        {
            string nome;
            try
            {
                nome = LeilaoContexto.Pessoas.FirstOrDefault(p => p.Id == idPessoa).Nome;
            }
            catch (Exception)
            {

                nome = "";
            }
            return nome;
        }

        public List<Pessoa> ListarTodos()
        {
            List<Pessoa> listPessoas;
            try
            {
                listPessoas = LeilaoContexto.Pessoas.ToList();
            }
            catch (Exception ex)
            {

                listPessoas = null;
            }
            return listPessoas;

        }
    }
}
