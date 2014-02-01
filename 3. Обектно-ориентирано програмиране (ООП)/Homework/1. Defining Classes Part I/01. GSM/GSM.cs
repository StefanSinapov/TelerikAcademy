
/*
 * 2.Define several constructors for the defined classes that
 * take different sets of arguments (the full information for the class or part of it).
 * Assume that model and manufacturer are mandatory (the others are optional).
 * All unknown data fill with null.
 * 
 * 4.Add a method in the GSM class for displaying all information about it.
 * Try to override ToString().
 * 
 * 5. Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
 * Ensure all fields hold correct data at any given time.
 * 
 * 6. Add a static field and a property IPhone4S in the GSM class to hold the
 * information about iPhone 4S.

 */
using System;
using System.Text;
class GSM
{
	//Static field
	private static readonly GSM iPhone4S = new GSM("iPhone 4S", "Apple", 999.99m, "Stefan", new Battery(Battery.Type.LiIon, 400, 0), new Display(4, 10000000));

	//Fields
	private string model = null;
	private string manufacturer = null;
	private decimal? price = null;
	private string owner = null;
	private Battery battery = null;
	private Display display = null;

	//Constructors
	public GSM(string model, string manufacturer)
		: this(model, manufacturer, null, null, null, null)
	{

	}
	public GSM(string model, string manufacturer, decimal? price, string owner,
		Battery battery, Display display)
	{
		this.Model = model;
		this.Manufacturer = manufacturer;
		this.Price = price;
		this.Owner = owner;
		this.Battery = battery;
		this.Display = display;
	}

	//Properties
	public string Model
	{
		get { return this.model; }
		set
		{
			if(string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException("Model can't be null");
			}
			this.model = value;
		}
	}
	public string Manufacturer
	{
		get { return this.manufacturer; }
		set
		{
			if (string.IsNullOrEmpty(value))
				throw new ArgumentNullException("Manufacturer cannot be null");
			this.manufacturer = value;
		}
	}
	public decimal? Price
	{
		get { return this.price; }
		set
		{
			if (value.HasValue && (value < 0))
				throw new ArgumentOutOfRangeException("Price cannot be negative");
			this.price = value;
		}
	}
	public string Owner
	{
		get { return this.owner; }
		set { this.owner = value; }
	}
	public Battery Battery
	{
		get { return this.battery; }
		set { this.battery = value; }
	}
	public Display Display
	{
		get { return this.display; }
		set { this.display = value; }
	}
	public static GSM IPhone4S
	{
		get { return iPhone4S; }
	}


	//Override
	public override string ToString()
	{
		StringBuilder mobileInfo = new StringBuilder();
		mobileInfo.AppendLine("------GSM------");
		mobileInfo.AppendLine("Model: " + this.model);
		mobileInfo.AppendLine("Manufacturer: " + this.manufacturer);
		if(this.owner!=null)
		{
			mobileInfo.AppendLine("Owner: " + this.owner);
		}
		if(this.price!=null && this.price>0)
		{
			mobileInfo.AppendLine("Price: " + this.price);
		}
		//Todo add ToString override for battery and display

		return mobileInfo.ToString();
	}
}

