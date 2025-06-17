namespace MediatrPlayground.Models.Dispensers
{
	public class CappuccinoDispenser : AbstractDispenser
	{
		protected override Drink DispenserCore() =>
			new Cappuccino();

	}
}
