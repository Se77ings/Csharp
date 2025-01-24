using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using DevIO.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {

        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            // Validar se a entity é consistente.
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor) || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            // Validar se não existe outro fornecedor com o mesmo documento
            if(_fornecedorRepository.Buscar(f=> f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if(!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if(_fornecedorRepository.Buscar(f=> f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado");
                return;
            }
            await _fornecedorRepository.Atualizar(fornecedor);

        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);
            var endereco = await _fornecedorRepository.ObterEnderecoPorFornecedor(id);

            if (fornecedor == null)
            {
                Notificar("Fornecedor não existe");
            }

            if (fornecedor.Produtos.Any())
            {
                Notificar("O Fornecedor possui produtos cadastrados!");
            }

            if(endereco != null)
            {
                await _fornecedorRepository.RemoverEnderecoFornecedor(endereco);
            }

            await _fornecedorRepository.Remover(id);
        }
        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }

    }
}
