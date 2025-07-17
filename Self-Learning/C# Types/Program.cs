// See https://aka.ms/new-console-template for more information

using PublicSpace.Moveable;
using PublicSpace.ParkingLot;
using PublicSpace.TownHall;

ParkingLot fmlxParkingLot = new("Formulatrix Parking Lot");
ParkingLot townHallParkingLot = new("Salatiga Town Hall Parking Lot");
TownHall salatigaTownHall = new("Salatiga Town Hall");
FoodTruck foodTruck = new("Rice Bowl Foodtruck", 10, 15);

Console.WriteLine("---");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
Console.Clear();

fmlxParkingLot.Open();
townHallParkingLot.Open();
salatigaTownHall.Open();
fmlxParkingLot.Close();
salatigaTownHall.Close();
foodTruck.Open();

Console.WriteLine("---");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
Console.Clear();

PublicSpace.PublicSpace.Info();
ParkingLot.Info();
TownHall.Info();
FoodTruck.Info();

Console.WriteLine("---");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
Console.Clear();

((IMoveble)foodTruck).Info();
foodTruck.Close();
foodTruck.Move(7, -2);
foodTruck.Open();
((IMoveble)foodTruck).Info();
foodTruck.Close();

Console.WriteLine("---");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
Console.Clear();

PublicSpace.PublicSpace.ViewOwners();
PublicSpace.PublicSpace.AddOwners("Mas Gumilang", "City Park");
PublicSpace.PublicSpace.ViewOwners();

Console.WriteLine("---");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
Console.Clear();

foodTruck.ViewMenu();

Console.WriteLine("---");
Console.WriteLine("Press any key to continue");
Console.ReadLine();
Console.Clear();
