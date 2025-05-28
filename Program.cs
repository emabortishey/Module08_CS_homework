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

//Race race = new Race { _sp_car = new Sport_car { _name = "Sport car", _speed_kph = 0, _route = 1000 }, _moto_car = new Moto_car { _name = "Moto car", _speed_kph = 0, _route = 1000 }, _tr_car = new Truck_car { _name = "Truck", _speed_kph = 0, _route = 1000 }, _bus_car = new Bus_car { _name = "Bus", _speed_kph = 0, _route = 1000 } };

//race.RaceEv += race._sp_car.Ride;
//race.RaceEv += race._moto_car.Ride;
//race.RaceEv += race._tr_car.Ride;
//race.RaceEv += race._bus_car.Ride;

//race.Ride();

//public delegate void RaceDel();

//public class Race
//{
//    public event RaceDel RaceEv;
//    public Sport_car _sp_car { get; set; }
//    public Moto_car _moto_car { get; set; }
//    public Truck_car _tr_car { get; set; }
//    public Bus_car _bus_car { get; set; }
//    List<int> _routs { get; set; }
//    List<string> _winner_names {  get; set; }

//    int _hours;

//    public Race()
//    {
//        _routs = new List<int> { 1 };
//        _winner_names = new List<string> { };
//    }

//    public void Ride()
//    {
//        while (_routs.Count() > 0)
//        {

//            WriteLine($"\nHour {++_hours}:\n");

//            RaceEv();

//            _routs.Clear();
//            _routs = new List<int> { };

//            if (_sp_car._route > 0)
//            {
//                _routs.Add(_sp_car._route);
//            }
//            else if (_sp_car._route != -666)
//            {
//                _winner_names.Add(_sp_car._name);
//                _sp_car._route = -666;
//            }
//            if (_moto_car._route > 0)
//            {
//                _routs.Add(_moto_car._route);
//            }
//            else if (_moto_car._route != -666)
//            {
//                _winner_names.Add(_moto_car._name);
//                _moto_car._route = -666;
//            }
//            if (_tr_car._route > 0)
//            {
//                _routs.Add(_tr_car._route);
//            }
//            else if(_tr_car._route != -666)
//            {
//                _winner_names.Add(_tr_car._name);
//                _tr_car._route = -666;
//            }
//            if (_bus_car._route > 0)
//            {
//                _routs.Add(_bus_car._route);
//            }
//            else if (_bus_car._route != -666)
//            {
//                _winner_names.Add(_bus_car._name);
//                _bus_car._route = -666;
//            }
//        }

//        WriteLine($"\nWINNERS OF THE RACE:\n\n1st place: {_winner_names[0]}\n 2nd place: {_winner_names[1]}\n 3rd place: {_winner_names[2]}\n 4th place: {_winner_names[3]}");
//    }
//}

//public class Sport_car : Car
//{
//    public string _name { get; set; }
//    public int _speed_kph { get; set; }
//    public int _route { get; set; }

//    public override void Ride()
//    {
//        if (_route > 0)
//        {
//            Random rand = new Random();

//            _speed_kph = rand.Next(150);

//            _route -= _speed_kph;

//            WriteLine($"{_name} succesed {_speed_kph}!");
//        }
//    }
//}
//public class Moto_car : Car
//{
//    public string _name { get; set; }
//    public int _speed_kph { get; set; }
//    public int _route { get; set; }

//    public override void Ride()
//    {
//        if (_route > 0)
//        {
//            Random rand = new Random();

//            _speed_kph = rand.Next(150);

//            _route -= _speed_kph;

//            WriteLine($"{_name} succesed {_speed_kph}!");
//        }
//    }
//}
//public class Truck_car : Car
//{
//    public string _name { get; set; }
//    public int _speed_kph { get; set; }
//    public int _route { get; set; }

//    public override void Ride()
//    {
//        if (_route > 0)
//        {
//            Random rand = new Random();

//            _speed_kph = rand.Next(150);

//            _route -= _speed_kph;

//            WriteLine($"{_name} succesed {_speed_kph}!");
//        }
//    }
//}
//public class Bus_car : Car
//{
//    public string _name { get; set; }
//    public int _speed_kph { get; set; }
//    public int _route { get; set; }

//    public override void Ride()
//    {
//        if (_route > 0)
//        {
//            Random rand = new Random();

//            _speed_kph = rand.Next(150);

//            _route -= _speed_kph;

//            WriteLine($"{_name} succesed {_speed_kph}!");
//        }
//    }
//}

//public abstract class Car
//{
//    public string _name;
//    public int _speed_kph;
//    public int _route;
//    public event RaceDel RaceEv;

//    public abstract void Ride();
//}

/*

Программа «Карточная игра!»
Создать модель карточной игры.
Требования:
1. Класс Game формирует и обеспечивает:
1.1.1. Список игроков (минимум 2);
1.1.2. Колоду карт (36 карт);
1.1.3. Перетасовку карт (случайным образом);
1.1.4. Раздачу карт игрокам (равными частями каждому
игроку);
1.1.5. Игровой процесс. Принцип: Игроки кладут по
одной карте. У кого карта больше, то тот игрок
забирает все карты и кладет их в конец своей
колоды. Упрощение: при совпадении карт забирает первый игрок, шестерка не забирает туза.
Выигрывает игрок, который забрал все карты.
2. Класс Player (набор имеющихся карт, вывод имеющихся карт).
3. Класс Karta (масть и тип карты (6–10, валет, дама,
король, туз).

*/

Game game = new Game { _players = new List<Player> { new Player { _nick = "Player1", _cards = new List<Card> { } }, new Player { _nick = "Player2", _cards = new List<Card> { } } } };

game.ShuffleDeck();

game.DealCards();

game.PrintDeck();

game._players[0].PrintCards();
game._players[1].PrintCards();

game.ReturnIntoDeck();

game.PrintDeck();

public class Card
{
    public string _suit { get; set; }
    public string _type { get; set; }

    public override string ToString()
    {
        return $"\nSuit: {_suit} Type: {_type}";
    }
}

public class Player
{
    public string _nick { get; set; }
    public List<Card> _cards { get; set; }

    public void PrintCards()
    {
        WriteLine($"\n\n{_nick}'s card collection:\n\n");

        foreach (var card in _cards)
        {
            Write($"{card} ");
        }
    }
}

public class Game
{
    public List<Player> _players { get; set; }
    List<Card> _deck = new List<Card> 
    {   new Card { _suit = "Spades", _type = "Six" },
        new Card { _suit = "Spades", _type = "Seven" },
        new Card { _suit = "Spades", _type = "Eight" },
        new Card { _suit = "Spades", _type = "Nine" },
        new Card { _suit = "Spades", _type = "Ten" },
        new Card { _suit = "Spades", _type = "Jack" },
        new Card { _suit = "Spades", _type = "Queen" },
        new Card { _suit = "Spades", _type = "King" },
        new Card { _suit = "Spades", _type = "Ace" },

        new Card { _suit = "Clubs", _type = "Six" },
        new Card { _suit = "Clubs", _type = "Seven" },
        new Card { _suit = "Clubs", _type = "Eight" },
        new Card { _suit = "Clubs", _type = "Nine" },
        new Card { _suit = "Clubs", _type = "Ten" },
        new Card { _suit = "Clubs", _type = "Jack" },
        new Card { _suit = "Clubs", _type = "Queen" },
        new Card { _suit = "Clubs", _type = "King" },
        new Card { _suit = "Clubs", _type = "Ace" },

        new Card { _suit = "Hearts", _type = "Six" },
        new Card { _suit = "Hearts", _type = "Seven" },
        new Card { _suit = "Hearts", _type = "Eight" },
        new Card { _suit = "Hearts", _type = "Nine" },
        new Card { _suit = "Hearts", _type = "Ten" },
        new Card { _suit = "Hearts", _type = "Jack" },
        new Card { _suit = "Hearts", _type = "Queen" },
        new Card { _suit = "Hearts", _type = "King" },
        new Card { _suit = "Hearts", _type = "Ace" },

        new Card { _suit = "Diamonds", _type = "Six" },
        new Card { _suit = "Diamonds", _type = "Seven" },
        new Card { _suit = "Diamonds", _type = "Eight" },
        new Card { _suit = "Diamonds", _type = "Nine" },
        new Card { _suit = "Diamonds", _type = "Ten" },
        new Card { _suit = "Diamonds", _type = "Jack" },
        new Card { _suit = "Diamonds", _type = "Queen" },
        new Card { _suit = "Diamonds", _type = "King" },
        new Card { _suit = "Diamonds", _type = "Ace" },
    };

    public void ShuffleDeck()
    {
        for(int i = 0; i < _deck.Count; i++)
        {
            Card buff = _deck[0];
            _deck.RemoveAt(0);
            _deck.Insert(Random.Shared.Next(_deck.Count), buff);
        }
    }

    public void DealCards()
    {
        int buff = _deck.Count / _players.Count;

        for (int i = 0; i < _players.Count; i++) 
        {
            for (int j = 0; j < buff; j++)
            {
                _players[i]._cards.Add(_deck[j]);

                _deck.RemoveAt(j);
            }
        }
    }

    public void ReturnIntoDeck()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            for (int j = 0; j < _players[i]._cards.Count; j++)
            {
                _deck.Add(_players[i]._cards[j]);

                _players[i]._cards.RemoveAt(j);
            }
        }
    }

    public void PrintDeck()
    {
        foreach(var card in _deck)
        {
            WriteLine(card);
        }
    }
}