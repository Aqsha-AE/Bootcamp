//Conversion 


int integerNumber = 300023192;
double doubleNumber = integerNumber; 
Console.WriteLine(doubleNumber); 

double doubleValue = 300023192.0;
decimal decimalValue = (decimal)doubleValue;
Console.WriteLine(decimalValue);

string stringNumber = "300023192";
int stringToInteger = Convert.ToInt32(stringNumber);
Console.WriteLine(stringToInteger); 

// Value Type 
int p1 = 10;
int p2 = p1;
p2 = 20;
Console.WriteLine(p1); // Output: 10

char newLine = '\n';
Console.WriteLine(newLine); // Output: (newline character)

char bckslash = '\\';
Console.WriteLine(bckslash); // Output: \

char f = 'f';
int asciiValue = (int)f;
Console.WriteLine(asciiValue); // Output: 102

bool isSuccess = false;
Console.WriteLine($"Your Code is {(isSuccess ? "succes" : "not succes")}"); 

bool isRaw = true;
bool isSteam = false;

if (isRaw){
    Console.WriteLine("Raw");
}
else if (isSteam){
    Console.WriteLine("Try to Steam");
}
else{
    Console.WriteLine("Not Raw or Steam");
}
