using MediatR;
using MediatrPlayground.Models.Dispensers;

namespace MediatrPlayground.MediatR.RequestHandlers
{
	public class DrinkRequestHandlerBase<TDispenser> where TDispenser : AbstractDispenser
	{
		private readonly IMediator _mediator;
		private readonly TDispenser _dispenser;

		public DrinkRequestHandlerBase(IMediator mediator, TDispenser dispenser)
		{
			_mediator = mediator;
			_dispenser = dispenser;			
		}

		public Task<Unit> Handle()
		{
			var drink = _dispenser.Dispense();

			_mediator.Publish(new DrinkDispensed(drink, _dispenser.AvailableDoses));
			return Task.FromResult(Unit.Value);
		}
	}
}
