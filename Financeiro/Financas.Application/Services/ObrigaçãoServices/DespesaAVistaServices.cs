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
	public class DespesaAVistaServices : IDespesaAVistaServices
	{
		private readonly IDespesaAVistaRepository _repository;

		public DespesaAVistaServices(IDespesaAVistaRepository repository)
		{
			_repository = repository;
		}

		public async Task<Result<bool>> AddDespesaAVistaAsync(DespesaAVistaRequest request)
		{
			// TODO: Verificar se já existe essa entidade.
			var despesa = new DespesaAVista(request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao);

			if (!await DespesaAVistaIsValid(despesa))
				return Result<bool>.Failure(new Error(Errors.InvalidEntity));

			await _repository.AddAsync(despesa);
			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> UpdateDespesaAVistaAsync(Guid id, DespesaAVistaRequest request)
		{
			var despesaResult = await ObterDespesaAVistaPorId(id);

			var novaEntidade = new DespesaAVista(request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao);
			// TODO: Verificar se já existe a nova entidade ou homônima.

			if (!await DespesaAVistaIsValid(novaEntidade))
				return Result<bool>.Failure(new Error(Errors.InvalidEntity));

			despesaResult.Value!.Atualizar(request.Descricao, request.SubTotal, request.DataVencimento, request.Descontos, request.Observacao);

			await _repository.UpdateAsync(despesaResult.Value);

			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> DeleteDespesaAVistaAsync(Guid id)
		{
			var despesaResult = await ObterDespesaAVistaPorId(id);

			await _repository.RemoveAsync(despesaResult.Value);

			return Result<bool>.Success(true);
		}

		public async Task<(Result<bool> result, DespesaAVistaView view)> GetDespesaAVistaByIdAsync(Guid id)
		{
			var despesaResult = await ObterDespesaAVistaPorId(id);

			return (Result<bool>.Success(true), (DespesaAVistaView)despesaResult.Value!);
		}

		#region Métodos internos

		private async Task<bool> DespesaAVistaIsValid(DespesaAVista entidade)
		{
			DespesaAVistaValidador validator = new();
			ValidationResult result = await validator.ValidateAsync(entidade);

			if (!result.IsValid)
				return false;

			return true;
		}

		private async Task<Result<DespesaAVista>> ObterDespesaAVistaPorId(Guid id)
		{
			var despesa = await _repository.GetByIdAsync(id);

			if (despesa == null)
				return Result<DespesaAVista>.Failure(new Error(RecordNotFoundFormat(nameof(DespesaAVista))));

			return Result<DespesaAVista>.Success(despesa);
		}

		#endregion
	}
}
