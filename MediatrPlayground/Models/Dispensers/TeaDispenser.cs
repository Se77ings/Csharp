namespace MediatrPlayground.Models.Dispensers
{
	public class TeaDispenser : AbstractDispenser
	{
		protected override Drink DispenserCore() =>
			new Tea();

	}
}
