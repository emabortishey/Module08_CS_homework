using static System.Console;

// MAIN ZADANIA 1
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

// переменная самой гонки
Race race = new Race { _sp_car = new Sport_car { _name = "Sport car", _speed_kph = 0, _route = 1000 }, _moto_car = new Moto_car { _name = "Moto car", _speed_kph = 0, _route = 1000 }, _tr_car = new Truck_car { _name = "Truck", _speed_kph = 0, _route = 1000 }, _bus_car = new Bus_car { _name = "Bus", _speed_kph = 0, _route = 1000 } };

// добавление в событие всех машин переменной 
// (точнее их метода езды)
race.RaceEv += race._sp_car.Ride;
race.RaceEv += race._moto_car.Ride;
race.RaceEv += race._tr_car.Ride;
race.RaceEv += race._bus_car.Ride;

// запуск метода отвечающего за начало события гонки
race.Ride();
WriteLine("\n");

// MAIN ZADANIA 2
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

// тестовая переменная игры с двумя игроками
Game game = new Game { _players = new List<Player> { new Player { _nick = "Player1", _cards = new List<Card> { } }, new Player { _nick = "Player2", _cards = new List<Card> { } } } };

// перемешиваем колоду
game.ShuffleDeck();

// выводим колоду для просмотра результата
game.PrintDeck();

// раздаём карты
game.DealCards();

// выводим колоду чтобы убедиться что та пуста
game.PrintDeck();

// выводим карты обоих игроков по очереди
game._players[0].PrintCards();
game._players[1].PrintCards();

// тестировка метода возвращения карт в стопку
//game.ReturnIntoDeck();
//game.PrintDeck();

// включаем всех игроков в событие игры
foreach (var player in game._players)
{
    game.thegame += player.PlaceCard;
}

// пока количество игроков не равно 0
// (т.к. при отсутствии карт у игрока тот
// удаляется из массива игроков
while (game._players.Count > 0)
{
    game.Play();
}


// KLASSI ZADANIYA 1

// делегат гонки
public delegate void RaceDel();

// класс гонки
public class Race
{
    // событие гонки
    public event RaceDel RaceEv;

    // (я пыталась сделать массив дочерних классов 
    // с типом родительского, но эт не сработало и
    // я решила не заморачиваться над массивом вовсе)
    public Sport_car _sp_car { get; set; }
    public Moto_car _moto_car { get; set; }
    public Truck_car _tr_car { get; set; }
    public Bus_car _bus_car { get; set; }
    // массив для хранения всех оставшихся маршрутов
    // машин, чтобы по нему было удобнее пробегаться
    // т.к. для пробега и подсчёта рутов в машинах
    // понадобилось больше времени
    List<int> _routs { get; set; }
    // массив для записи победителей
    // в порядке прибытия на финиш
    List<string> _winner_names { get; set; }

    // переменная для записи текущего часа гонки
    int _hours;

    // конструктор для первичной инициализации контейнеров
    public Race()
    {
        _routs = new List<int> { 1 };
        _winner_names = new List<string> { };
    }

    // метод для вызова события и осуществления гонки
    public void Ride()
    {
        // пока в рутах есть хоть что-то (какая-то
        // машина ещё не финиширована) цикл продолжается
        while (_routs.Count() > 0)
        {
            // вывод текущего часа
            WriteLine($"\nHour {++_hours}:\n");

            // вызов события которое вызывает метод езды
            // для каждой машины и форсирует их проехать
            // какое-то рандомное расстяние
            RaceEv();

            // очистка??? я не помню зачем это, но значит нужно
            _routs.Clear();
            _routs = new List<int> { };

            // если спортивной машине есть что проезжать
            if (_sp_car._route > 0)
            {
                // её расстояние записывается в руты
                // (чистая формальность нежели информация
                // для использования в будущем)
                _routs.Add(_sp_car._route);
            }
            // если же у машины рут меньше
            // или равен нулю,но не равен -666 то
            else if (_sp_car._route != -666)
            {
                // машина фактически финишировала, и происходит
                // её запись в контейнер победителей
                _winner_names.Add(_sp_car._name);

                // после чего её присваивается значение -666
                // чтобы дальнейшие действия с ней
                // никакие не осуществлялись
                _sp_car._route = -666;
            }
            if (_moto_car._route > 0)
            {
                _routs.Add(_moto_car._route);
            }
            else if (_moto_car._route != -666)
            {
                _winner_names.Add(_moto_car._name);
                _moto_car._route = -666;
            }
            if (_tr_car._route > 0)
            {
                _routs.Add(_tr_car._route);
            }
            else if (_tr_car._route != -666)
            {
                _winner_names.Add(_tr_car._name);
                _tr_car._route = -666;
            }
            if (_bus_car._route > 0)
            {
                _routs.Add(_bus_car._route);
            }
            else if (_bus_car._route != -666)
            {
                _winner_names.Add(_bus_car._name);
                _bus_car._route = -666;
            }

            // (всё элс ифы можно было бы упростить записью
            // участников гонки в массив, но раз уж этого сделать
            // не удалось, выкручиваюсь так)
        }

        // далее после того, как в рутах не осталось никого,
        // происходит поочерёдный вывод победителей
        WriteLine($"\nWINNERS OF THE RACE:\n\n 1st place: {_winner_names[0]}\n 2nd place: {_winner_names[1]}\n 3rd place: {_winner_names[2]}\n 4th place: {_winner_names[3]}");
    }
}

// класс спортивной машины
public class Sport_car : Car
{
    public string _name { get; set; }
    // скорость с которой она проедет текущий час гонки
    public int _speed_kph { get; set; }
    // оставшийся путь для контроля финиширования
    public int _route { get; set; }

    // метод езды в текущем часу
    public override void Ride()
    {
        // если машина ещё не финишировала то
        if (_route > 0)
        {
            Random rand = new Random();

            // её скорость меняется на рандомное значение
            // в диапазоне (у каждой машины диапазон разный
            // в зависимости от её типа)
            _speed_kph = rand.Next(150);

            // из путя вычитается пройденный путь за час
            _route -= _speed_kph;

            // вывод отчёта о том, какой маршрут проделала машина
            WriteLine($"{_name} succesed {_speed_kph}!");
        }
    }
}
public class Moto_car : Car
{
    public string _name { get; set; }
    public int _speed_kph { get; set; }
    public int _route { get; set; }

    public override void Ride()
    {
        if (_route > 0)
        {
            Random rand = new Random();

            _speed_kph = rand.Next(100);

            _route -= _speed_kph;

            WriteLine($"{_name} succesed {_speed_kph}!");
        }
    }
}
public class Truck_car : Car
{
    public string _name { get; set; }
    public int _speed_kph { get; set; }
    public int _route { get; set; }

    public override void Ride()
    {
        if (_route > 0)
        {
            Random rand = new Random();

            _speed_kph = rand.Next(90);

            _route -= _speed_kph;

            WriteLine($"{_name} succesed {_speed_kph}!");
        }
    }
}
public class Bus_car : Car
{
    public string _name { get; set; }
    public int _speed_kph { get; set; }
    public int _route { get; set; }

    public override void Ride()
    {
        if (_route > 0)
        {
            Random rand = new Random();

            _speed_kph = rand.Next(80);

            _route -= _speed_kph;

            WriteLine($"{_name} succesed {_speed_kph}!");
        }
    }
}

// базовый абстрактный класс машиныЖ
public abstract class Car
{
    public string _name;
    public int _speed_kph;
    public int _route;
    public event RaceDel RaceEv;

    public abstract void Ride();
}


// KLASSI ZADANIYA 2

// класс карты
public class Card
{
    // масть
    public string _suit { get; set; }
    // тип карты (6,7/туз,дама и тд)
    public string _type { get; set; }
    // условный уровень превосходства
    // карты над остальными для реализации игры
    public int _cost { get; set; }

    // не знаю зачем это
    //  ♧ ♤ ♡ ♢ ♣ ♠ ♥ ♦

    // метод для будущего вывода карт
    public override string ToString()
    {
        return $"Suit: {_suit} Type: {_type}";
    }
}

// метод игрока
public class Player
{
    public string _nick { get; set; }
    // массив карт которые сейчас в руках игрока
    public List<Card> _cards { get; set; }
    // выбранная карта для осуществления хода
    public Card choosen { get; set; }

    // вывод карт пользователя
    public void PrintCards()
    {
        int indx = 1;

        WriteLine($"\n\n\n{_nick}'s card collection:");

        foreach (var card in _cards)
        {
            WriteLine ($"{indx++}. - {card}");
        }
    }

    // метод для осуществления хода
    public void PlaceCard()
    {
        // индекс выбранной карты
        int choosencard;

        WriteLine($"\n{_nick}, choose the card:\n");

        for(int i = 0; i< _cards.Count; i++)
        {
            WriteLine ($"{i+1}. - {_cards[i]}");
        }

        WriteLine();

        choosencard = Convert.ToInt32(ReadLine());

        // выбранный индекс -1 т.к. при выводе карты
        // нумеруются не от 0 а от 1 для простоты
        // ввода пользователя и общего понимания

        // выбранная карта переносится в переменную
        // выбранной карты обьекта класса
        choosen = _cards[choosencard-1];
        // и удаляется из массива карт пользователя
        _cards.RemoveAt(choosencard-1);
    }
}

// делегат для события игры
public delegate void PlayDelegate( );

// класс игры
public class Game
{
    // событие игры
    public event PlayDelegate thegame;
    // массив игроков
    public List<Player> _players { get; set; }
    // массив карт находящихся на столе
    public List<Card> _table { get; set; }
    // колода
    List<Card> _deck = new List<Card> 
    {   new Card { _suit = "Spades", _type = "Six", _cost = 6 },
        new Card { _suit = "Spades", _type = "Seven", _cost = 7 },
        new Card { _suit = "Spades", _type = "Eight", _cost = 8 },
        new Card { _suit = "Spades", _type = "Nine", _cost = 9 },
        new Card { _suit = "Spades", _type = "Ten", _cost = 10 },
        new Card { _suit = "Spades", _type = "Jack", _cost = 11 },
        new Card { _suit = "Spades", _type = "Queen", _cost = 12 },
        new Card { _suit = "Spades", _type = "King", _cost = 13 },
        new Card { _suit = "Spades", _type = "Ace", _cost = 14 },

        new Card { _suit = "Clubs", _type = "Six", _cost = 6 },
        new Card { _suit = "Clubs", _type = "Seven", _cost = 7 },
        new Card { _suit = "Clubs", _type = "Eight", _cost = 8 },
        new Card { _suit = "Clubs", _type = "Nine", _cost = 9 },
        new Card { _suit = "Clubs", _type = "Ten", _cost = 10 },
        new Card { _suit = "Clubs", _type = "Jack", _cost = 11 },
        new Card { _suit = "Clubs", _type = "Queen", _cost = 12 },
        new Card { _suit = "Clubs", _type = "King", _cost = 13 },
        new Card { _suit = "Clubs", _type = "Ace", _cost = 14 },

        new Card { _suit = "Hearts", _type = "Six", _cost = 6 },
        new Card { _suit = "Hearts", _type = "Seven", _cost = 7 },
        new Card { _suit = "Hearts", _type = "Eight", _cost = 8 },
        new Card { _suit = "Hearts", _type = "Nine", _cost = 9 },
        new Card { _suit = "Hearts", _type = "Ten", _cost = 10 },
        new Card { _suit = "Hearts", _type = "Jack", _cost = 11 },
        new Card { _suit = "Hearts", _type = "Queen", _cost = 12 },
        new Card { _suit = "Hearts", _type = "King", _cost = 13 },
        new Card { _suit = "Hearts", _type = "Ace", _cost = 14 },

        new Card { _suit = "Diamonds", _type = "Six", _cost = 6 },
        new Card { _suit = "Diamonds", _type = "Seven", _cost = 7 },
        new Card { _suit = "Diamonds", _type = "Eight", _cost = 8 },
        new Card { _suit = "Diamonds", _type = "Nine", _cost = 9 },
        new Card { _suit = "Diamonds", _type = "Ten", _cost = 10 },
        new Card { _suit = "Diamonds", _type = "Jack", _cost = 11 },
        new Card { _suit = "Diamonds", _type = "Queen", _cost = 12 },
        new Card { _suit = "Diamonds", _type = "King", _cost = 13 },
        new Card { _suit = "Diamonds", _type = "Ace", _cost = 14 },
    };

    // конструктор
    public Game()
    {
        _table = new List<Card> { };
    }

    // метод для тасовки карт
    public void ShuffleDeck()
    {
        // самый простой способ перемешивания
        // элементов коллекции
        for(int i = 0; i < _deck.Count; i++)
        {
            Card buff = _deck[0];
            _deck.RemoveAt(0);
            _deck.Insert(Random.Shared.Next(_deck.Count), buff);
        }
    }

    // метод раздачи карт
    public void DealCards()
    {
        // переменная содержащая количество карт
        // которое необходимо раздать каждому
        int buff = _deck.Count / _players.Count;

        // пробегается по каждому игроку и
        for (int i = 0; i < _players.Count; i++) 
        {
            // и раздаёт необходимое количество карт
            // попутно удаляя их из колоды
            // и переходя к следующему игроку
            for (int j = buff - 1; j >= 0; j--)
            {
                _players[i]._cards.Add(_deck[j]);

                _deck.RemoveAt(j);
            }
        }
    }

    // метод возвращения карт в колоду
    public void ReturnIntoDeck()
    {
        // пробегает по всем игрокам, возвращая
        // их карты назад, а затем очищая их массивы карт
        for (int i = 0; i < _players.Count; i++)
        {
            for (int j = 0; j < _players[i]._cards.Count; j++)
            {
                _deck.Add(_players[i]._cards[j]);
            }

            _players[i]._cards.Clear();
        }
    }

    // вывод всей колоды
    public void PrintDeck()
    {
        foreach(var card in _deck)
        {
            WriteLine(card);
        }
    }

    // метод для запуска события игры
    public void Play()
    {
        // если игроков осталось более одного
        if (_players.Count > 1)
        {
            // и если пока что не все игроки положили
            // выбранную карту на стол
            if (_table.Count != _players.Count)
            {
                // вызывается событие, которое вызывает у всех
                // игроков класса метод выбора карты по очереди
                thegame();

                // после чего у всех игроков выбранная карта
                // перемещается в массив карт стола
                foreach(var player in _players)
                {
                    _table.Add(player.choosen);
                }
            }
            // если же все игроки сделали свой ход
            else
            {
                // переменная макс. индекса
                int maxindx = 0;
                // переменная для вывода карт находящихся на столе
                int indx = 1;

                // нахождение индекса максимального элемента на столе
                // (самой большой карты)
                for (int i = 1; i < _table.Count; i++)
                {
                    if (_table[i]._cost > _table[i - 1]._cost)
                    {
                        maxindx = i;
                    }
                }

                // вывод карт на столе
                WriteLine("Table:");

                foreach(var card in _table)
                {
                    WriteLine($"{indx++}. - {card}");
                }

                // вывод пользователя который положил наибольшую
                // карту на стол (т.к. пользователи делали это по
                // очереди, индекс найденной макс. карты соответствует
                // пользователю который её положил
                WriteLine($"\n{_players[maxindx]._nick} got all the cards from the table for this round! Loser.");

                // все карты на столе передаются в колоду проигравшего
                foreach (var card in _table)
                {
                    _players[maxindx]._cards.Add(card);
                }

                // очищение стола
                _table.Clear();
            }
        }
        // если игрок остался 1, выводится проигравший
        // и игроки очищаются для прекращения цикла в мейне
        else if(_players.Count == 1)
        {
            WriteLine($"{_players[0]._nick} IS LOSER! CONGRATS!");

            _players.Clear();
        }

        // далее происходит проверка на то, что
        // кто-либо из игроков раздал все карты,
        // после чего он исключается с массива игроков
        for (int i = 0; i < _players.Count; i++) 
        {
            if (_players[i] ._cards.Count == 0)
            {
                _players.RemoveAt(i);
            }
        }
    }
}