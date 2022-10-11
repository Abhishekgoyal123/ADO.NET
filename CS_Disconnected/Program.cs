// See https://aka.ms/new-console-template for more information
using CS_Disconnected;
Console.WriteLine("Hello, World!");

DataAccess dataAccess = new DataAccess();

dataAccess.LoadData();

dataAccess.Update(10);

dataAccess.Delete(10);

Console.ReadLine();