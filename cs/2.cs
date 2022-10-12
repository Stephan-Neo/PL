Main joe = new Main();

Console.Clear();
joe.formula = "Z/X + 7*sqrt(Y)";
joe.Menu();

class Main 
{
	public string formula = "";
	public double X;
	public double Y;
	public double Z;
	public double N;
    public DateTime firstStartDate = new DateTime();
    public DateTime firstEndDate = new DateTime();
    public DateTime secondStartDate = new DateTime();
    public DateTime secondEndDate = new DateTime();
    
    public void Menu()
    {
        Console.WriteLine($"\n[0] Exit \n[1] Hello World! \n[2] Calc: {formula} \n[3] Recursion date ");

		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));
		Console.Write("Input action: ");
		string? input = Console.ReadLine();
		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));

		if((Convert.ToString(input) != "" & input == "0") | (Convert.ToString(input) != "" & input == "1") | (Convert.ToString(input) != "" & input == "2" ) | (Convert.ToString(input) != "" & input == "3"))
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
                
                case 3:
					Date();
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

	public void CalculateIntersectionDates(DateTime date_1, DateTime date_2, DateTime date_3, DateTime date_4)
	{
		if(date_3 >= date_1 && date_4 <= date_2){
			string ?stringN = Convert.ToString(date_4 - date_3);
			N = Convert.ToDouble(stringN?.Substring(0, stringN.Length - 9)) + 1;
		}
		
		else if(date_3 < date_2 && date_4 <= date_2 | date_3 >= date_1 && date_4 > date_1){
			if(date_3 < date_2 && date_4 <= date_2){
				string ?stringN = Convert.ToString(date_4 - date_1);
				N = Convert.ToDouble(stringN?.Substring(0, stringN.Length - 9)) + 1;
			}
		
			else{
				string ?stringN = Convert.ToString(date_2 - date_3);
				N = Convert.ToDouble(stringN?.Substring(0, stringN.Length - 9)) + 1;
			}
		}

		else{
			if((date_3 > date_2 && date_4 > date_2) | (date_3 < date_1 && date_4 < date_1)){
				N = 0;
			}
			else{
				string ?stringN = Convert.ToString(date_2 - date_1);
				N = Convert.ToInt16(stringN?.Substring(0, stringN.Length - 9)) + 1;
			}
		}
	}

	public void CalculatePrimeNumber()
	{
		Console.Clear();

        for (int i = 2; i <= Math.Sqrt(N); i+=1) {
            if (X % i == 0) {
                Console.WriteLine($"\n {N} doesn't prime number, since it is divided into {i}. NO");
                return;
            }
        }
        Console.WriteLine($"\n {N} have prime number. YES");
	}

	public void Exit()
    {
        Environment.Exit(0);
    }

    public void Date()
    {
        do{
			Console.Write("\nInput Date 1 (DD.MM.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				Error("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("Error!!! invalid date format");
            }

			else{
				firstStartDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);

        do{
			Console.Write("\nInput Date 2 (DD.MM.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				Error("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("Error!!! invalid date format");
            }

            else if(Convert.ToDateTime(inputDate) <= firstStartDate){
                Error("Error!!! Date 2 <= Date 1");
            }

			else{
				firstEndDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);

        do{
			Console.Write("\nInput Date 3 (DD.MM.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				Error("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("Error!!! invalid date format");
            }

			else{
				secondStartDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);

        do{
			Console.Write("\nInput Date 4 (DD.MM.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				Error("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("Error!!! invalid date format");
            }

            else if(Convert.ToDateTime(inputDate) <= secondStartDate){
                Error("Error!!! Error!!! Date 4 <= Date 2");
            }

			else{
				secondEndDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);


		CalculateIntersectionDates(firstStartDate, firstEndDate, secondStartDate, secondEndDate);
		CalculatePrimeNumber();
		
		Console.WriteLine("\n");
		Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
        Console.WriteLine($"	N: {N}");
		Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
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
}
