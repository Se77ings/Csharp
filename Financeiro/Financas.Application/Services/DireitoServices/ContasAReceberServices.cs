using Financeiro.Business.Aggregates.Direito;
using Financeiro.Business.Aggregates.Validações;
using Financeiro.Business.Interfaces;
using Financeiro.Business.Localization;
using Financeiro.Business.Models.DireitoModels;
using Financeiro.Business.ResultPattern;
using FluentValidation.Results;
using static Financeiro.Business.Localization.ErrorMessages;

namespace Financas.Application.Services.DireitoServices
{
	public class ContasAReceberServices : IContasAReceberServices
	{
		private readonly IContasAReceberRepository _repository;
		public ContasAReceberServices(IContasAReceberRepository repository)
		{
			_repository = repository;
		}

		public async Task<Result<bool>> AddAsync(ContasAReceberRequest request)
		{
			//TODO: Verificar se já existe essa entidade.
			var contaAReceber = new ContasAReceber(request.Descricao, request.SubTotal, request.Data, request.Descontos);

			if (!await ContasAReceberIsValid(contaAReceber))
				return Result<bool>.Failure(new Error(RecordNotFoundFormat(nameof(ContasAReceber))));

			await _repository.AddAsync(contaAReceber);

			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> UpdateAsync(Guid id, ContasAReceberRequest request)
		{
			var contaAReceber = await ObterContaAReceberPorId(id);

			var novaEntidade = new ContasAReceber(request.Descricao, request.SubTotal, request.Data, request.Descontos);
			//TODO: Verificar se já existe a nova entidade ou homônima.

			if (!await ContasAReceberIsValid(novaEntidade))
				return Result<bool>.Failure(new Error(Errors.InvalidEntity));

			contaAReceber.Value!.Atualizar(request.Descricao, request.SubTotal, request.Data, request.Descontos);

			await _repository.UpdateAsync(contaAReceber.Value);

			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> DeleteAsync(Guid id)
		{
			var contaAReceber = await ObterContaAReceberPorId(id);

			await _repository.RemoveAsync(contaAReceber.Value);

			return Result<bool>.Success(true);
		}

		public async Task<(Result<bool> result, ContasAReceberView view)> GetByIdAsync(Guid id)
		{
			var contaAReceber = await ObterContaAReceberPorId(id);


			return (Result<bool>.Success(true), (ContasAReceberView)contaAReceber.Value!);

		}

		public async Task<(Result<bool> result, List<ContasAReceberSummary> lista)> GetListAsync()
		{
			var list = await _repository.GetListAsync();

			if (list == null)
				return (Result<bool>.Failure(new Error(Errors.EmptyData)), null);

			var result = list.Select(c => new ContasAReceberSummary { Data = c.Data, Descricao = c.Descricao, Total = c.Total }).ToList();

			return (Result<bool>.Success(true), result);
		}

		#region Métodos internos
		public async Task<bool> ContasAReceberIsValid(ContasAReceber entidade)
		{//TODO: Preciso debugar isso, pra ver como retornar os erros da melhor forma.
			ContasAReceberValidador validator = new();
			ValidationResult result = await validator.ValidateAsync(entidade);

			if (!result.IsValid)
				return false;

			return true;
		}

		public async Task<Result<ContasAReceber>> ObterContaAReceberPorId(Guid id)
		{
			var contaAReceber = await _repository.GetByIdAsync(id);

			if (contaAReceber == null)
				return Result<ContasAReceber>.Failure(new Error(RecordNotFoundFormat(nameof(ContasAReceber))));


			return Result<ContasAReceber>.Success(contaAReceber);
		}

		#endregion
	}
}
