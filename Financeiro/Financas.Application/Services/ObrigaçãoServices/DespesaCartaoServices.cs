using Financas.Application.Services.ObrigaçãoServices.Interfaces;
using Financeiro.Business.Aggregates.Obrigação;
using Financeiro.Business.Aggregates.Validações;
using Financeiro.Business.Interfaces;
using Financeiro.Business.Localization;
using Financeiro.Business.Models.ObrigaçãoModels;
using Financeiro.Business.ResultPattern;
using FluentValidation.Results;
using static Financeiro.Business.Localization.ErrorMessages;

namespace Financas.Application.Services.ObrigaçãoServices
{
	public class DespesaCartaoServices : IDespesaCartaoServices
	{
		private readonly IDespesaCartaoRepository _repository;

		public DespesaCartaoServices(IDespesaCartaoRepository repository)
		{
			_repository = repository;
		}

		public async Task<Result<bool>> AddDespesaCartaoAsync(DespesaCartaoRequest request)
		{
			var entidade = new DespesaCartao(request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao);
			if (!await DespesaCartaoIsValid(entidade))
				return Result<bool>.Failure(new Error(Errors.InvalidEntity));

			await _repository.AddAsync(entidade);
			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> UpdateDespesaCartaoAsync(Guid id, DespesaCartaoRequest request)
		{
			var result = await ObterDespesaCartaoPorId(id);

			var novaEntidade = new DespesaCartao(request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao);

			if (!await DespesaCartaoIsValid(novaEntidade))
				return Result<bool>.Failure(new Error(Errors.InvalidEntity));

			result.Value!.Atualizar(request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao);

			await _repository.UpdateAsync(result.Value);
			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> DeleteDespesaCartaoAsync(Guid id)
		{
			var result = await ObterDespesaCartaoPorId(id);

			await _repository.RemoveAsync(result.Value);
			return Result<bool>.Success(true);
		}

		public async Task<(Result<bool> result, List<DespesaCartaoView> lista)> GetListAsync()
		{
			var lista = await _repository.GetListAsync();

			if (lista == null || !lista.Any())
				return (Result<bool>.Failure(new Error(Errors.EmptyData)), null);

			var views = lista.Select(l => (DespesaCartaoView)l).ToList();
			return (Result<bool>.Success(true), views);
		}

		public async Task<bool> AddDespesaCartaoItemAsync(Guid id, DespesaCartaoItemRequest request)
		{
			var result = await ObterDespesaCartaoPorId(id);

			result.Value!.AdicionarDespesa(request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao, request.ParcelaAtual, request.QtdParcelas);

			await _repository.UpdateAsync(result.Value);
			return true;
		}

		public async Task<bool> UpdateDespesaCartaoItemAsync(Guid id, Guid itemId, DespesaCartaoItemRequest request)
		{
			var result = await ObterDespesaCartaoPorId(id);

			result.Value!.AtualizarDespesa(itemId, request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao, request.ParcelaAtual, request.QtdParcelas);

			await _repository.UpdateAsync(result.Value);
			return true;
		}

		public async Task<bool> DeleteDespesaCartaoItemAsync(Guid id, Guid itemId)
		{
			var result = await ObterDespesaCartaoPorId(id);

			result.Value!.RemoverDespesa(itemId);

			await _repository.UpdateAsync(result.Value);
			return true;
		}

		#region Métodos internos

		private async Task<Result<DespesaCartao>> ObterDespesaCartaoPorId(Guid id)
		{
			var despesa = await _repository.GetByIdAsync(id);

			if (despesa == null)
				return Result<DespesaCartao>.Failure(new Error(RecordNotFoundFormat(nameof(DespesaCartao))));

			return Result<DespesaCartao>.Success(despesa);
		}

		private async Task<bool> DespesaCartaoIsValid(DespesaCartao entidade)
		{
			DespesaCartaoValidador validator = new();
			ValidationResult result = await validator.ValidateAsync(entidade);

			return result.IsValid;
		}

		#endregion
	}
}
