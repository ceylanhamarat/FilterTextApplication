// See https://aka.ms/new-console-template for more information
using FilterText.Interfaces;
using FilterTextApplication.Extensions;
using FilterTextApplication.Helpers;
using FilterTextApplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello team, here are the words filtered out by all the required filters.\n");
         
        //Register services
        var serviceCollection = new ServiceCollection();
        var serviceProvider = serviceCollection.RegisterServices();

        // Get required services 
        var fileHelper = serviceProvider.GetRequiredService<IFileHelper>();
        var textHelper = serviceProvider.GetRequiredService<ITextHelper>();
        var filterService = serviceProvider.GetRequiredService<IFilterService>();

        // Get path for file
        var path = FilePathHelper.GetFilePath("TextInput.txt");

        // Create instance and apply the filters
        var textProcessor = new ProcessorHelper(fileHelper, textHelper, filterService);
        var filteredWords = textProcessor.ProcessText(path);

        Console.WriteLine("Filtered Paragraph: " + string.Join(" ", filteredWords));
        Console.ReadLine();
    }
}
 




