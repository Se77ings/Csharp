namespace MediatrPlayground.Models.Dispensers
{
	public class CoffeeDispenser : AbstractDispenser
	{
		protected override Drink DispenserCore() =>
			new Coffee();

	}
}
