using MediatR;

namespace MediatrPlayground.MediatR
{
	public record CoffeeRequest : IRequest;
	public record LatteRequest : IRequest;
	public record CappuccinoRequest : IRequest;
	public record TeaRequest : IRequest;

	public record AvailableDosesRequest : IRequest<AvailableDoses>;
}
