Main joe = new Main();

joe.formula = "Z/X + 7*sqrt(Y)";
joe.Menu();

class Main 
{
	public string formula = "";
	public double X;
	public double Y;
	public double Z;
    public void Menu()
    {
        Console.WriteLine($"\n[0] Exit \n[1] Hello World! \n[2] {formula}");

		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));
		Console.Write("Input action: ");
		string? input = Console.ReadLine();
		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));

		if((Convert.ToString(input) != "" & input == "0") | (Convert.ToString(input) != "" & input == "1") | (Convert.ToString(input) != "" & input == "2"))
		{
			int action = Convert.ToInt32(input);
			switch(action)
			{
				case 0:
					Exit();		
					break;
				
				case 1:
					Hello();
					Menu();
					break;
				
				case 2:
					Calculate();
					Menu();
					break;
			}
		}
		else
		{
			Error("Error!!! The wrong line");
			Menu();
		}

    }

	public void Hello()
	{
		Console.Clear();
		Console.WriteLine("\nHello World!");
	}

	public void Error(string error)
	{	
		Console.Clear();
		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));
		Console.WriteLine($"	{error}");
		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));
	}

	public void Calculate()
	{
		Console.Clear();
		
		do{
			Console.WriteLine($"\nFormula: {formula}");
			Console.Write("\nInput X: ");
			string? inputX = Console.ReadLine();

			if(inputX == ""){
				Error("X != empty string");
			}

			else if(inputX == "0"){
				Error("X dont = 0");
			}

			else if(!double.TryParse(inputX, out double numericValueX)){
				Error("X must be a number");
			}

			else{
				X = Convert.ToDouble(inputX);
				break;
			}


		} while(true);

		do{
			Console.WriteLine($"\nFormula: {formula}");
			Console.Write("\nInput Y: ");
			string? inputY = Console.ReadLine();

			if(inputY == ""){
				Error("Y != empty string");
			}

			else if(!double.TryParse(inputY, out double numericValueY)){
				Error("Y must be a number");
			}

			else if(Convert.ToDouble(inputY) <= 0){
				Error("Y dont < 0");
			}

			else{
				Y = Convert.ToDouble(inputY);
				break;
			}


		} while(true);

		do{
			Console.WriteLine($"\nFormula: {formula}");
			Console.Write("\nInput Z: ");
			string? inputZ = Console.ReadLine();

			if(inputZ == ""){
				Error("Z != empty string");
			}

			else if(!double.TryParse(inputZ, out double numericValueZ)){
				Error("Z must be a number");
			}

			else{
				Z = Convert.ToDouble(inputZ);
				break;
			}


		} while(true);

		double rezult = (Z / X) + (7 * Math.Sqrt(Y)); 
		double rezultRound = Math.Round(rezult, 3, MidpointRounding.ToEven);
		Console.WriteLine($"\nRezult: {rezultRound}");
	}
	public void Exit()
    {
        Environment.Exit(0);
    }
}
