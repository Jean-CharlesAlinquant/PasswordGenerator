using PasswordGenerator.App;

var passwordGenerator = new PasswordMaker(new RandomWrapper());
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(passwordGenerator.Generate(10, 15, true));
}
