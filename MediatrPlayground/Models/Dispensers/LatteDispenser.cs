namespace MediatrPlayground.Models.Dispensers
{
	public class LatteDispenser : AbstractDispenser
	{
		protected override Drink DispenserCore() =>
			new Latte();

	}
}
