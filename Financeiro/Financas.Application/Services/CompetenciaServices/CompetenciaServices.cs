using Financeiro.Business.Aggregates;
using Financeiro.Business.Interfaces;
using Financeiro.Business.Models.CompetenciaModels;
using Financeiro.Business.ResultPattern;
using static Financeiro.Business.Localization.ErrorMessages;

namespace Financas.Application.Services.CompetenciaServices
{
	public class CompetenciaServices : ICompetenciaServices
	{
		private readonly ICompetenciaRepository _repository;
		public CompetenciaServices(ICompetenciaRepository repository)
		{
			_repository = repository;
		}

		public async Task<Result<bool>> AddAsync(CompetenciaRequest request)
		{
			var competencia = new Competencia(request.Mes, request.Ano);

			// TODO: Verificar se já existe essa entidade.

			await _repository.AddAsync(competencia);

			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> UpdateAsync(Guid id, CompetenciaRequest request)
		{

			var competencia = await ObterCompetenciaPorId(id);
			//TODO: Verificar se já existe a nova entidade ou homônima.

			competencia.Value!.Atualizar(request.Mes, request.Ano);

			await _repository.UpdateAsync(competencia.Value!);

			return Result<bool>.Success(true);
		}

		public async Task<Result<bool>> DeleteAsync(Guid id)
		{
			var competencia = await ObterCompetenciaPorId(id);

			await _repository.RemoveAsync(competencia.Value!);

			return Result<bool>.Success(true);
		}

		public async Task<(Result<bool> result, CompetenciaView view)> GetByIdAsync(Guid id)
		{
			var competencia = await ObterCompetenciaPorId(id);

			return (Result<bool>.Success(true), (CompetenciaView)competencia.Value!);
		}

		public async Task<(Result<bool> result, List<CompetenciaSummary> lista)> GetListAsync()
		{//TODO: Preciso debugar isso, pra ver como retornar os erros da melhor forma.

			var list = await _repository.GetListAsync();

			return (Result<bool>.Success(true), list.Select(x => new CompetenciaSummary { Ano = x.Ano, Mes = x.Mes }).ToList());
		}

		#region Métodos internos
		public async Task<Result<Competencia>> ObterCompetenciaPorId(Guid id)
		{
			var competencia = await _repository.GetByIdAsync(id);
			if (competencia == null)
				return Result<Competencia>.Failure(new Error(RecordNotFoundFormat(nameof(Competencia))));

			return Result<Competencia>.Success(competencia);
		}
		#endregion
	}
}
