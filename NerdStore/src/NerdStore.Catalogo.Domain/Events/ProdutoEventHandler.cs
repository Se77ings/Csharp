using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoEventHandler(IProdutoRepository produtoRep)
        {
            _produtoRepository = produtoRep;
            
        }
        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            //aqui lida com a lógica de negócio.
            //pode ser enviado um email para a equipe de vendas, por exemplo.

            
        }
    }
}
