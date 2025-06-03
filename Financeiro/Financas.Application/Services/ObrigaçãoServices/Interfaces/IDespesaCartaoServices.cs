using Financeiro.Business.Models.ObrigaçãoModels;
using Financeiro.Business.ResultPattern;

namespace Financas.Application.Services.ObrigaçãoServices.Interfaces
{
	public interface IDespesaCartaoServices
	{
		public Task<(Result<bool> result, List<DespesaCartaoView> lista)> GetListAsync();
		public Task<Result<bool>> AddDespesaCartaoAsync(DespesaCartaoRequest request);
		public Task<Result<bool>> UpdateDespesaCartaoAsync(Guid id, DespesaCartaoRequest request);
		public Task<Result<bool>> DeleteDespesaCartaoAsync(Guid id);

		//Obs: Esses métodos abaixo, não possuem repositório. na realidade fazem um Update de DespesaCartao!!!!!
		public Task<bool> AddDespesaCartaoItemAsync(Guid id, DespesaCartaoItemRequest request);
		public Task<bool> UpdateDespesaCartaoItemAsync(Guid id, Guid itemId, DespesaCartaoItemRequest request);
		public Task<bool> DeleteDespesaCartaoItemAsync(Guid id, Guid itemId);

	}
}
