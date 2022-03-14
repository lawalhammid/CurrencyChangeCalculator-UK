# CurrencyChangeCalculator-UK

PROJECT REQUIREMENTS BELOW

Develop an application that given a UK Currency amount and the purchase price of a product, displays the change to be returned split down by denomination, largest first.

 
Example:

Given £20 and a product price of £5.50, the application will output:

 

Your change is: (displayed within the console)

1 x £10

2 x £2

1 x 50p

 
-------------------------------------

Required Solution (Core or Framework)

-------------------------------------

1x Console App Project

1x Business / Logic Project

1x Unit Test Project (Framework of your choice)


PROJECT SOLUTION STRUCTURE BELOW

/// The code struture explained below
///---- Model  project is where i defined all the entities 
///---- Business project logic is where I defined my contracts(interfaces) and services(Implementations)
/// I have two classes for coins. CurrencyCoins(i.e for penny) and CurrencyCoinsHighWeight(for pounds. i.e they are coins too but they have heigher weights or values)
/// IChangeXchangeDenomService interface returns Denomination change and higher coins(i.e 1 and 2 pounds)
/// IChangeXchangeNomService interface returns Coins(i.e only penny change)
/// The view model is the class i used to display changes to console enviromnent
/// CountNoOfItems class in Helpers folder was used to track/control the number of currency to be added to ReturnedChange class. Once a particular change is found twice or more than once in CountNoOfItems it increases the number of currency to display  
///---- UKCurrencyCalculatorChange Project is the main project. i.e Where Business logic was referenced
///---- UKCurrencyCalculatorChangeTest project is the test project where the project requirements was tested