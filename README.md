# Word Filter - Console Application 

This is a console application built using .NET 8, designed to process text file using required filters. The application is designed with SOLID principles and extendable architecture. It uses xUnit for unit testing and Moq for mocking dependencies in tests.

# Requirement : 
Write a C# application with the associated unit tests that will be able to take multiple text filters and apply them
on any given string. This should take no more than 2 hours.
The application should:
* Read from a txt file
* Create and apply the following 3 filters:
    * Filter1 – filter out all the words that contains a vowel in the middle of the word – the centre 1 or 2 letters
("clean" middle is ‘e’, "what" middle is ‘ha’, "currently" middle is ‘e’ and should be filtered, "the", "rather"
should not be)
    * Filter2 – filter out words that have length less than 3
    * Filter3 – filter out words that contains the letter ‘t’
* After all filters have completed display the resulted text in the console;


# Features
**SOLID Principles**: The application is built following the SOLID principles to ensure good object-oriented design practices.

**Filter Structure**: The filters are divided into 3 main categories, based on the requirements:
* **Vowel Filters**: Filters that check for vowels at specific positions in words.
* **Letter Filters**: Filters that check whether words contain or do not contain a specific letter.
* **Length Filters**: Filters that check if a word is longer or shorter than a specified length.


# Prerequisites
* .NET 8
* xUnit
* Moq
