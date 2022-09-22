Main joe = new Main();

Console.Clear();
joe.Menu();

class Main 
{
	public int X;
	public int N;
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
					CalculatePrimeNumber();
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
			N = Convert.ToInt16(stringN?.Substring(0, stringN.Length - 9)) + 1;
		}
		
		else if(date_3 < date_2 && date_4 <= date_2 | date_3 >= date_1 && date_4 > date_1){
			if(date_3 < date_2 && date_4 <= date_2){
				string ?stringN = Convert.ToString(date_4 - date_1);
				N = Convert.ToInt16(stringN?.Substring(0, stringN.Length - 9)) + 1;
			}
		
			else{
				string ?stringN = Convert.ToString(date_2 - date_3);
				N = Convert.ToInt16(stringN?.Substring(0, stringN.Length - 9)) + 1;
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
		
		do{
			Console.Write("\nInput X: ");
			string? inputX = Console.ReadLine();

			if(inputX == ""){
				Error("Error!!! X != empty string");
			}

            else if(Convert.ToInt64(inputX) < 0){
                Error("Error!!! X must be a positive number");
            }

			else if(!int.TryParse(inputX, out int numericValueX)){
				Error("Error!!! X must be a number");
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
		
		Console.WriteLine("\n");
		Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
        Console.WriteLine($"	N: {N}");
		Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
    }
}
