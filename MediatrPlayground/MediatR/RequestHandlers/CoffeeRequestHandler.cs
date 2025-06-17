using MediatR;
using MediatrPlayground.Models.Dispensers;

namespace MediatrPlayground.MediatR.RequestHandlers
{ // parei aqui : https://dev.to/wsantosdev/playground-mediatr-22je#:~:text=Ainda%20na%20pasta%20RequestHandlers%2C%20crie%20o%20arquivo%20CoffeeRequestHandler.cs%20e%20cole%20o%20seguinte%20conte%C3%BAdo%3A
	public class CoffeeRequestHandler : DrinkRequestHandlerBase<CoffeeDispenser>, IRequestHandler<CoffeeRequest>
	{
		public CoffeeRequestHandler(IMediator mediator, CoffeeDispenser dispenser) : base(mediator, dispenser)
		{
			Task<Unit> IRequestHandler<CoffeeRequest, Unit>.Handle(CoffeeRequest, CancellationToken cancellationToken) =>
				Handle();
		}

	
	}
}
