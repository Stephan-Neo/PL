using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

Programm joe = new Programm();

Console.Clear();
joe.formula = "Z/X + 7*sqrt(Y)";
joe.Menu();

class Task
{
	public string formula = "";
	public string? stringA = "";
	public string? stringB = "";
	public double X;
	public double Y;
	public double Z;
	public double N;
	public DateTime firstStartDate = new DateTime();
	public DateTime firstEndDate = new DateTime();
	public DateTime secondStartDate = new DateTime();
	public DateTime secondEndDate = new DateTime();
	public bool Regex;
}

class Programm: Task 
{
	public void Menu()
    {
        Console.WriteLine($"\n[0] Exit \n[1] Hello World! \n[2] Calc: {formula} \n[3] Recursion date \n[4] Strings");

        Error error = new Error();

		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));
		Console.Write("Input action: ");
		string? input = Console.ReadLine();
		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));

		if((Convert.ToString(input) != "" & input == "0") | (Convert.ToString(input) != "" & input == "1") | (Convert.ToString(input) != "" & input == "2" ) | (Convert.ToString(input) != "" & input == "3") | (Convert.ToString(input) != "" & input == "4"))
		{
			int action = Convert.ToInt32(input);
			switch(action)
			{
				case 0:
					Exit exit = new Exit();
					exit.CloseProgram();	
					break;
				
				case 1:
					Hello hello = new Hello();
					hello.PrintHello();
					Menu();
					break;
				
				case 2:
					InputCalculateFormula();
					CalculateFormula formula = new CalculateFormula();
					formula.Calculate(X, Y, Z);
					Menu();
					break;
                
                case 3:
					InputDate();
					CalculateDates date = new CalculateDates();
					date.CalculateIntersectionDates(firstStartDate, firstEndDate, secondStartDate, secondEndDate);
					date.CalculatePrimeNumber();
					Menu();
					break;

                case 4:
                    InputStrings();
                    CheckStrings check = new CheckStrings();
                    check.Same(stringA, stringB);
					Menu();
					break;
			}
		}
		else
		{
			error.PirntError("Error!!! The wrong line");
			Menu();
		}

    }

    public void InputStrings(){
        Error error = new Error();
        Console.Clear();
        do{
            Console.Write("\nInput string A: ");
            string? inputAString = Console.ReadLine();

			if(inputAString == ""){
				error.PirntError("Error!!! string != empty string");
			}else{
                stringA = inputAString;
                break;
            }
		} while(true);

        do{
            Console.Write("\nInput string B: ");
            string? inputBString = Console.ReadLine();

			if(inputBString == ""){
				error.PirntError("Error!!! string != empty string");
			}else{
                stringB = inputBString;
                break;
            }
		} while(true);

    }

    public void InputDate()
    {
        Error error = new Error();
        do{
			Console.Write("\nInput Date 1 (MM.DD.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				error.PirntError("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                error.PirntError("Error!!! invalid date format");
            }

			else{
				firstStartDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);

        do{
			Console.Write("\nInput Date 2 (MM.DD.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				error.PirntError("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                error.PirntError("Error!!! invalid date format");
            }

            else if(Convert.ToDateTime(inputDate) <= firstStartDate){
                error.PirntError("Error!!! Date 2 <= Date 1");
            }

			else{
				firstEndDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);

        do{
			Console.Write("\nInput Date 3 (MM.DD.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				error.PirntError("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                error.PirntError("Error!!! invalid date format");
            }

			else{
				secondStartDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);

        do{
			Console.Write("\nInput Date 4 (MM.DD.YYYY): ");
			string? inputDate = Console.ReadLine();

			if(inputDate == ""){
				error.PirntError("Error!!! date != empty string");
			}

            else if(!DateOnly.TryParse(inputDate, out DateOnly dateOnly)){
                error.PirntError("Error!!! invalid date format");
            }

            else if(Convert.ToDateTime(inputDate) <= secondStartDate){
                error.PirntError("Error!!! Error!!! Date 4 <= Date 2");
            }

			else{
				secondEndDate = Convert.ToDateTime(inputDate);
				break;
			}


		} while(true);
    }

	public void InputCalculateFormula()
	{
		Console.Clear();
		
        Error error = new Error();

		do{
			Console.WriteLine($"\nFormula: {formula}");
			Console.Write("\nInput X: ");
			string? inputX = Console.ReadLine();

			if(inputX == ""){
				error.PirntError("X != empty string");
			}

			else if(inputX == "0"){
				error.PirntError("X dont = 0");
			}

			else if(!double.TryParse(inputX, out double numericValueX)){
				error.PirntError("X must be a number");
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
				error.PirntError("Y != empty string");
			}

			else if(!double.TryParse(inputY, out double numericValueY)){
				error.PirntError("Y must be a number");
			}

			else if(Convert.ToDouble(inputY) <= 0){
				error.PirntError("Y dont < 0");
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
				error.PirntError("Z != empty string");
			}

			else if(!double.TryParse(inputZ, out double numericValueZ)){
				error.PirntError("Z must be a number");
			}

			else{
				Z = Convert.ToDouble(inputZ);
				break;
			}


		} while(true);
	}
}
class Hello: Task{
	public void PrintHello()
	{
		Console.Clear();
		Console.WriteLine("\nHello World!");
	}

}

class Error: Task{
	public void PirntError(string error)
	{	
		Console.Clear();
		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));
		Console.WriteLine($"	{error}");
		Console.WriteLine(String.Concat(Enumerable.Repeat("-", 20)));

	}
}

class CalculateDates: Task{
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
				N = Convert.ToDouble(stringN?.Substring(0, stringN.Length - 9)) + 1;
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

        Console.WriteLine("\n");
		Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
        Console.WriteLine($"	N: {N}");
		Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));

        Console.WriteLine($"\n {N} have prime number. YES");
	}
}

class Exit: Task{
	public void CloseProgram()
    {
        Environment.Exit(0);
    }
}

class CalculateFormula: Task{
	public void Calculate(double X_r, double Y_r, double Z_r)
	{
		double rezult = (X_r / X_r) + (7 * Math.Sqrt(Y_r)); 
		double rezultRound = Math.Round(rezult, 3, MidpointRounding.ToEven);
		Console.WriteLine($"\nRezult: {rezultRound}");
	}
}

class CheckStrings: Task{
    public void Same(string? A, string? B){

        string ANotSpaceLow = A.Replace(" ", "").ToLower();
        string BNotSpaceLow = B.Replace(" ", "").ToLower();

        Regex regexEmail = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+");
        Regex regexPhone = new Regex(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
        Regex regexIp = new Regex(@"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}");

        MatchCollection matchesAEmail = regexEmail.Matches(A);
        MatchCollection matchesAPhone = regexPhone.Matches(A);
        MatchCollection matchesAIp = regexIp.Matches(A);

        MatchCollection matchesBEmail = regexEmail.Matches(B);
        MatchCollection matchesBPhone = regexPhone.Matches(B);
        MatchCollection matchesBIp = regexIp.Matches(B);

        string ARevNotSpaceLow = new string(ANotSpaceLow.Reverse().ToArray());

        CheckSame(A, B);
        
        CheckNotSpaceLow(ANotSpaceLow, BNotSpaceLow);
        
        CheckRevNotSpaceLow(ARevNotSpaceLow, BNotSpaceLow);
        
		CheckRegex(matchesAEmail, matchesAPhone, matchesAIp, matchesBEmail, matchesBPhone, matchesBIp);
    }

    private void CheckSame(string A, string B)
    {
	    ValidateStrings validate = new ValidateStrings();
	    try
	    {
		    validate.isSame(A, B);
		    
		    Console.WriteLine(" ");
		    Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
		    Console.WriteLine($"\nIt's same strings");
		    Console.WriteLine(" ");
		    Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
	    }
	    catch(ValidationException vx)
	    {	
		    Console.WriteLine(" ");
		    Console.WriteLine($"	1) {vx.Message}");
		    Console.WriteLine(" ");
	    }
    }
    private void CheckNotSpaceLow(string A, string B)
    {
	    ValidateStrings validate = new ValidateStrings();
	    try
	    {
		    validate.isNotSpaceLow(A, B);
		    
		    Console.WriteLine(" ");
		    Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
		    Console.WriteLine($"\nIt's same strings not space and in low register. {A} == {B}");
		    Console.WriteLine(" ");
		    Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
	    }
	    catch(ValidationException vx)
	    {	
		    Console.WriteLine(" ");
		    Console.WriteLine($"	2) {vx.Message}");
		    Console.WriteLine(" ");
	    }
    }
    
    private void CheckRevNotSpaceLow(string A, string B)
    {
	    ValidateStrings validate = new ValidateStrings();
	    try
	    {
		    validate.isRevNotSpaceLow(A, B);
		    
		    Console.WriteLine(" ");
		    Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
		    Console.WriteLine($"\nIt's REVERSE strings. {A} == {B}");
		    Console.WriteLine(" ");
		    Console.WriteLine(String.Concat(Enumerable.Repeat("*", 20)));
	    }
	    catch(ValidationException vx)
	    {	
		    Console.WriteLine(" ");
		    Console.WriteLine($"	3) {vx.Message}");
		    Console.WriteLine(" ");
	    }
    }
    
    private void CheckRegex(
	    MatchCollection matchesAEmail,
	    MatchCollection matchesAPhone,
	    MatchCollection matchesAIp,
	    MatchCollection matchesBEmail,
	    MatchCollection matchesBPhone,
	    MatchCollection matchesBIp)
    {
	    ValidateStrings validate = new ValidateStrings();
	    try
	    {
		    validate.isRegex(
			    matchesAEmail,
			    matchesAPhone,
			    matchesAIp,
			    matchesBEmail,
			    matchesBPhone,
			    matchesBIp
			    );
	    }
	    catch(ValidationException vx)
	    {	
		    Console.WriteLine(" ");
		    Console.WriteLine($"	4) {vx.Message}");
		    Console.WriteLine(" ");
	    }
    }
}

class ValidateStrings : Task
{
	public void isSame(string A, string B)
	{
		if(A != B){
			throw new ValidationException($"{A} != {B}");
		}
	}
	
	public void isNotSpaceLow(string ANotSpaceLow, string BNotSpaceLow)
	{
		if(ANotSpaceLow != BNotSpaceLow){
			throw new ValidationException($"{ANotSpaceLow} != {BNotSpaceLow}");
		}
		
	}
	
	public void isRevNotSpaceLow(string A, string B)
	{
		if(A != B){
			throw new ValidationException($"{A} != {B}");
		}
	}
	
	public void isRegex(
		MatchCollection matchesAEmail,
		MatchCollection matchesAPhone,
		MatchCollection matchesAIp,
		MatchCollection matchesBEmail,
		MatchCollection matchesBPhone,
		MatchCollection matchesBIp)
	{
		Regex = false;
		
		if (matchesAEmail.Count > 0)
		{
			foreach (Match match in matchesAEmail)
				Console.WriteLine($"\n{match.Value} it's Email");
			Regex = true;
		}
        
		if (matchesAPhone.Count > 0){
			foreach (Match match in matchesAPhone)
				Console.WriteLine($"\n{match.Value} it's Phone Number");
			Regex = true;
		}
        
		if (matchesAIp.Count > 0){
			foreach (Match match in matchesAIp)
				Console.WriteLine($"\n{match.Value} it's Ip");
			Regex = true;
		}
        
		if (matchesBEmail.Count > 0){
			foreach (Match match in matchesBEmail)
				Console.WriteLine($"\n{match.Value} it's Email");
			Regex = true;
		}

		if (matchesBPhone.Count > 0){
			foreach (Match match in matchesBPhone)
				Console.WriteLine($"\n{match.Value} it's Phone Number");
			Regex = true;
		}
        
		if (matchesBIp.Count > 0){
			foreach (Match match in matchesBIp)
				Console.WriteLine($"\n{match.Value} it's Ip");
			Regex = true;
		}

		if (!Regex)
		{
			throw new ValidationException($"NOT Regex");
		}
	}
}