using Financeiro.Business.Models.ObrigaçãoModels;
using Financeiro.Business.ResultPattern;

namespace Financas.Application.Services.ObrigaçãoServices.Interfaces
{
	public interface IDespesaAVistaServices
	{
		public Task<(Result<bool> result, DespesaAVistaView view)> GetDespesaAVistaByIdAsync(Guid id);

		public Task<Result<bool>> AddDespesaAVistaAsync(DespesaAVistaRequest request);
		public Task<Result<bool>> UpdateDespesaAVistaAsync(Guid id, DespesaAVistaRequest request);
		public Task<Result<bool>> DeleteDespesaAVistaAsync(Guid id);
	}
}
