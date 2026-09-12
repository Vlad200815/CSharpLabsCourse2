namespace Lab1_Semeniuk_07;

// Validation Stages
internal enum InputStage {FullName, Group, Variant, Completed}

public static class InfoValidator
{
    /// <summary>
    /// Start Info Validator 
    /// </summary>
    public static void StartInfoValidator()
    {
        InputStage currentState = InputStage.FullName;
        
        string validFullName = string.Empty;
        string validGroup = string.Empty;
        string validVariant = string.Empty;
        
        
        // Enter a validation loop where it will be asking until you enter a valid variant of an answer
        while (currentState != InputStage.Completed)
        {   
            // Enter each validation stage
            switch (currentState)
            {
                case InputStage.FullName:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Please Enter full name: ");
                    string rawFullName = Console.ReadLine()?.Trim() ?? string.Empty;
                    
                    // If the answer is invalid make text red and print what was wrong
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    // Null and Empty check
                    if (string.IsNullOrWhiteSpace(rawFullName)) Console.WriteLine("The full name is empty.\n");
                    
                    // Length too small and too big check
                    else if (rawFullName.Length < 3 || rawFullName.Length > 50) 
                        Console.WriteLine("The full name is too short or too big.\n");
                    
                    // Check (full name must not contain digits) 
                    else if (rawFullName.Any(c => char.IsDigit(c))) 
                        Console.WriteLine("Didgits are not allowed in full name.\n");
                            
                    // The answer is valid, move on to the next validation field
                    else {
                        validFullName = rawFullName;
                        currentState = InputStage.Group;
                    }
                    
                    break;
            
                case InputStage.Group:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Please Enter group name: ");
                    string rawGroup = Console.ReadLine()?.Trim() ?? string.Empty;
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    // Null and Empty check
                    if (string.IsNullOrWhiteSpace(rawGroup)) Console.WriteLine("The group name is empty. \n");
                    
                    // Length too small and too big check
                    else if (rawGroup.Length < 2 || rawGroup.Length > 10) 
                        Console.WriteLine("Thr group name is too short or too long.\n");
                    
                    else
                    {
                        validGroup = rawGroup;
                        currentState = InputStage.Variant;
                    }
        
                    break;
                
                case InputStage.Variant:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Please Enter your variant: ");
                    string rawVariant = Console.ReadLine()?.Trim() ?? string.Empty;
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    
                    // Null & Empty check
                    if (string.IsNullOrWhiteSpace(rawVariant)) Console.WriteLine("The variant name is empty \n");
                    
                    // Length too big check
                    else if (rawVariant.Length > 2) Console.WriteLine("The variant is too big!\n");
                    
                    else if (rawVariant.Any(c => char.IsLetter(c))) 
                        Console.WriteLine("The variant must be in digits.\n");
                    else
                    {
                        validVariant = rawVariant;
                        currentState = InputStage.Completed;
                    }
        
                    break;
                
            }
        }
        Console.ResetColor();
        
        
        
        // Print out every collected info about the user with green color
        Console.WriteLine("-------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        
        Console.WriteLine($"Executed: {validFullName}");
        Console.WriteLine($"Group: {validGroup}");
        Console.WriteLine($"Variant: {validVariant}");
        
        Console.ResetColor();
        Console.WriteLine("-------------------------");
    }
    
}