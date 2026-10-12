using Lab8Models;

class Program
{
    static void Main()
    {
        const string divider = "--------------------------------------------------------------------------------------";
        const int variant = 7;
        
        Console.WriteLine(divider);
        Console.WriteLine("Fullname: Vlad Semeniuk");
        Console.WriteLine("Group: IPZ-21");
        Console.WriteLine("Variant: 7");
        Console.WriteLine(divider);

        Book book = new Book(8 + variant % 8, $"Book-{variant}", 180 + 5 * variant);
        Magazine magazine = new Magazine(variant, $"Magazine-{variant}", 40 + 2 * variant);

        Console.WriteLine("Get Base Info");
        Console.WriteLine(book.GetBaseInfo());
        Console.WriteLine(magazine.GetBaseInfo());
        Console.WriteLine(divider);

        Console.WriteLine("Get Info");
        Console.WriteLine(book.GetInfo());
        Console.WriteLine(magazine.GetInfo());
        Console.WriteLine(divider);

        Console.WriteLine("Call special methods");
        Console.WriteLine($"Average page per chapter: {book.CalculateAveragePagesPerChapter():F2}");
        Console.WriteLine($"Issue label: {magazine.CreateIssueLabel()}");
        Console.WriteLine(divider);
        
        Console.WriteLine("Try to call special method with base type of an inherited class\n");
        Publication secondMagazine = new Magazine(variant, $"Magazine-{variant}", 40 + 2 * variant);
        // secondMagazine.GetInfo(); it is an error
        
        ///0>Program.cs(37,24): Error CS1061 : 'Publication' does not contain a definition for
        /// 'GetInfo' and no accessible extension method 'GetInfo' accepting a first argument of
        /// type 'Publication' could be found (are you missing a using directive or an assembly reference?)
        ///0>------- Finished building project: Lab8App. Succeeded: False. Errors: 1. Warnings: 0
         
        Console.WriteLine("Explanation: We can't call method of an inherited class if we initialize its object with a base type.");
        Console.WriteLine("We could only use method and properties from the base class");
        
        Console.WriteLine("Hierarchy of my classes");
        Console.WriteLine("--Object\n  |--Publication\n     |--Magazine\n     |--Book");
        Console.WriteLine(divider);
        
        Console.WriteLine("Individual task A:\n");
        Fiction fiction = new Fiction(title: "It ends with us", genre: "Romance", chapterCount: 44, pageCount:223);
        Console.WriteLine(fiction.GetDetailedInfo());
        Console.WriteLine($"Is suitable for children: {fiction.IsSuitableForChildren()}");
        
        Console.WriteLine(divider);
        

    }
}








