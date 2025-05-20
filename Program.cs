using static System.Console;

// ZADANIE 1

/*

Игра «Автомобильные гонки»

Разработать игру "Автомобильные гонки" с использованием делегатов.

1. В игре использовать несколько типов автомобилей:
спортивные, легковые, грузовые и автобусы.

2. Реализовать игру «Гонки». Принцип игры: Автомобили двигаются от старта к финишу со скоростями,
которые изменяются в установленных пределах
случайным образом. Победителем считается автомобиль, пришедший к финишу первым.

Рекомендации по выполнению работы

1. Разработать абстрактный класс «автомобиль»
(класс Car). Собрать в нем все общие поля, свойства
(например, скорость) методы (например, ехать).

2. Разработать классы автомобилей с конкретной
реализацией конструкторов и методов, свойств.
В классы автомобилей добавить необходимые события (например, финиш).

3. Класс игры должен производить запуск соревнований автомобилей, выводить сообщения о текущем
положении автомобилей, выводить сообщение об
автомобиле, победившем в гонках. Создать делегаты, обеспечивающие вызов методов из классов
автомобилей (например, выйти на старт, начать
гонку).

4. Игра заканчивается, когда какой-то из автомобилей
проехал определенное расстояние (старт в положении 0, финиш в положении 100). Уведомление об
окончании гонки (прибытии какого-либо автомобиля на финиш) реализовать с помощью событий.

*/

//int way_length = 1000;

//SortedList<Car, int> race = new SortedList<Car, int>
//{
//    {new Sport_car {_name = "Sport car", _speed_kph = 0}, way_length},
//    {new Moto_car {_name = "Passenger car", _speed_kph = 0}, way_length},
//    {new Truck_car {_name = "Truck car", _speed_kph = 0}, way_length},
//    {new Bus_car {_name = "Bus car", _speed_kph = 0}, way_length}
//};

//RaceDel sport = race.Keys[0].Ride;
//RaceDel moto = race.Keys[1].Ride;
//RaceDel truck = race.Keys[2].Ride;
//RaceDel bus = race.Keys[3].Ride;

//foreach(var item in race.Keys)
//{
//    item.RaceEv += item.Ride;
//}

Race race = new Race ( new List<Car> { new Sport_car { _name = "car1" }, new Sport_car { _name = "car2" }, new Sport_car { _name = "car3" } } );

foreach(var item in race._race)
{
    race.RaceEv += item.Ride;
}

race.Ride();

public delegate void RaceDel();

public class Race
{
    public event RaceDel RaceEv;
    public List<Car> _race { get; set; }

    public Race(List<Car> race)
    {
        _race = race;
    }

    public void Ride()
    {
        RaceEv();
    }
}

public class Sport_car : Car
{
    public string _name { get; set; }
    public int _speed_kph { get; set; }
    public int _route {  get; set; }

    public override void Ride()
    {
        Random rand = new Random();

        _speed_kph = rand.Next(150);

        _route -= _speed_kph;

        WriteLine($"Car {_name} succesed {_speed_kph} route on it's way to finish!");
    }
}
//public class Moto_car : Car
//{
//    public event RaceDel RaceEv;
//    public string _name { get; set; }
//    public int _speed_kph { get; set; }

//    public override int Ride()
//    {
//        Random rand = new Random();

//        _speed_kph = rand.Next(110);

//        return _speed_kph;
//    }
//}
//public class Truck_car : Car
//{
//    public event RaceDel RaceEv;
//    public string _name { get; set; }
//    public int _speed_kph { get; set; }

//    public override int Ride()
//    {
//        Random rand = new Random();

//        _speed_kph = rand.Next(95);

//        return _speed_kph;
//    }
//}
//public class Bus_car : Car
//{
//    public event RaceDel RaceEv;
//    public string _name { get; set; }
//    public int _speed_kph { get; set; }

//    public override int Ride()
//    {
//        Random rand = new Random();

//        _speed_kph = rand.Next(80);

//        return _speed_kph;
//    }
//}

public abstract class Car
{
    string _name;
    int _speed_kph;
    public event RaceDel RaceEv;

    public abstract void Ride();
}