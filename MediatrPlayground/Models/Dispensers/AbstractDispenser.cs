namespace MediatrPlayground.Models.Dispensers
{
	public abstract class AbstractDispenser
	{
		public int AvailableDoses { get; set; } = 10;

		public Drink Dispense()
		{
			if (AvailableDoses <= 0)
				throw new InvalidOperationException("Bruh, there's no available dose!!!");

			AvailableDoses--;

			return DispenserCore();

		}

		protected abstract Drink DispenserCore();
	}
}
