Main joe = new Main();

Console.Clear();
joe.Menu();

class Main 
{
	public int X;
    public DateTime firstStartDate = new DateTime();
    public DateTime firstEndDate = new DateTime();
    public DateTime secondStartDate = new DateTime();
    public DateTime secondEndDate = new DateTime();
    
    public void Menu()
    {
        Console.WriteLine($"\n[0] Exit \n[1] Hello World! \n[2] Calc: checking for a prime number \n[3] Recursion date ");

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

	public void Calculate()
	{
		Console.Clear();
		
		do{
			Console.Write("\nInput X: ");
			string? inputX = Console.ReadLine();

			if(inputX == ""){
				Error("X != empty string");
			}

            else if(Convert.ToInt64(inputX) < 0){
                Error("X must be a positive number");
            }

			else if(!int.TryParse(inputX, out int numericValueX)){
				Error("X must be a number");
			}

			else{
				X = Convert.ToInt16(inputX);
				break;
			}


		} while(true);

        for (int i = 2; i <= Math.Sqrt(X); i+=1) {
            if (X % i == 0) {
                Console.WriteLine($"\n {X} doesn't prime number, since it is divided into {i}. NO");
                return;
            }
        }
        Console.WriteLine($"\n {X} have prime number. YES");
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
				Error("date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("invalid date format");
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
				Error("date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("invalid date format");
            }

            else if(Convert.ToDateTime(inputDate) <= firstStartDate){
                Error("Date 2 <= Date 1");
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
				Error("date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("invalid date format");
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
				Error("date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                Error("invalid date format");
            }

            else if(Convert.ToDateTime(inputDate) <= secondStartDate){
                Error("Date 4 <= Date 2");
            }

			else{
				secondEndDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);

        Console.WriteLine($"Date: {firstStartDate}, {firstEndDate}, {secondStartDate}, {secondEndDate}");
    }
}
