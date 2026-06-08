namespace ConsoleApp1;

internal abstract class Program
{
    private static void Main()
    {
        GameMaster();
    }

    private static void GameMaster()
    {
        bool isAppRun = true;

        while (isAppRun)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("||        SELAMAT DATANG DI GAME TEBAK ANGKA        ||");
            Console.WriteLine("======================================================");
            Console.WriteLine(">> MENU: ");
            Console.WriteLine("1. Buat Akun");
            Console.WriteLine("2. Play Game");
            Console.WriteLine("3. Cek Score");
            Console.WriteLine("0. Keluar");
            Console.Write("Masukan pilihan anda: ");
            string input = Console.ReadLine()!;

            Console.Clear();
            if (input == "1")
            {
                CreateUser();
            } else if (input == "2")
            {
                PlayGame();
            } else if (input == "3")
            {
                CheckScores();
            } else if (input == "0")
            {
                Console.WriteLine(">>> Terima Kasih Telah Bermain <<<");
                isAppRun = false;
            } else
            {
                Console.WriteLine("Error: Pilihan kamu tidak ditemukan...");
            }
        }

    }

    private static void CreateUser()
    {
        Console.Clear();
        string userName, password;

        Console.WriteLine(">> CREATE USER: ");

        userNameLable:
        Console.Write("Masukan username baru: ");
        userName = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(userName))
        {
            Console.WriteLine("Error: Username tidak boleh kosong...");
            goto userNameLable;
        }

        passwordLable:
        Console.Write("Masukan password baru: ");
        password = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Error: Password tidak boleh kosong...");
            goto passwordLable;
        }

        foreach (User usr in Databases.listUsers)
        {
            if (usr == null)
            {
                continue;
            }

            if (usr.UserName == userName)
            {
                Console.Clear();
                Console.WriteLine($"Username {userName} sudah digunakan...");
                goto userNameLable;
            }
        }

        if (Databases.listUsers.Length == Databases.userCountIndex)
        {
            User[] newListDataUsers = new User[Databases.listUsers.Length * 2];
            Array.Copy(Databases.listUsers, newListDataUsers, Databases.listUsers.Length);

            Databases.listUsers = newListDataUsers;
            
        }
        
        Databases.listUsers[Databases.userCountIndex++] = new User
        {
            Id = Databases.userCountIndex,
            UserName = userName,
            Password = password
        };

        Console.Clear();
        Console.WriteLine(">>> Success Membuat User Baru <<<");
    }

    private static void PlayGame()
    {

        User? userLogin = LoginUser();

        if (userLogin != null)
        {
            bool playGames = true;
        int chance = 3;

        Random random = new();
        int secretNumber = random.Next(1,101);

        Console.Clear();
        Console.WriteLine(">>> Selamat Bermain <<<");
        while (playGames)
        {
            Console.WriteLine(">> Play Games: ");
            Console.WriteLine($"Kesempatan: {chance}");
            Console.Write("Masukan nomor tebakannya: ");
            bool inputValidation = int.TryParse(Console.ReadLine()!, out int guessNumber);

            if (!inputValidation)
            {
                Console.WriteLine("Input value must be a number");
                continue;
            }

            if (guessNumber > secretNumber)
            {
                Console.Clear();
                Console.WriteLine("Inputan angka kamu terlalu besar dari jawabannya");
                chance--;
            } else if (guessNumber < secretNumber)
            {
                Console.Clear();
                Console.WriteLine("Inputan angka kamu terlalu kecil dari jawabannya");
                chance--;
            } else
            {
                Console.Clear();
                Console.WriteLine("Jawaban kamu benar");
                Console.WriteLine($"Untuk secret numbernya adalah {secretNumber}");
                userLogin.Winner++;
                playGames = false;
            }

            if (chance == 0)
            {
                Console.Clear();
                Console.WriteLine("Game over, kesempatan kamu sudah habis");
                Console.WriteLine($"Untuk jawabannya adalah {secretNumber}");
                userLogin.Lose++;
                playGames = false;
            }

            if (!playGames)
            {
                Console.Write("Apakah ingin bermain lagi (y/n): ");
                string input =  Console.ReadLine()!;

                playGames = input.Trim() == "y";
                chance = playGames ? 3 : 0;
                secretNumber = random.Next(1, 11);
                Console.Clear();
            }
        }            
        } else
        {
            Console.WriteLine("Error: Kamu harus login dulu untuk bermain...");
        }
    }

    private static User? LoginUser()
    {
        User? user;
        
        do
        {
            Console.Clear();
            user = null;

            Console.WriteLine(">> LOGIN AKUN: ");

            Console.Write("Masukan username: ");
            string userName = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(userName))
        {
            Console.WriteLine("Error: Username tidak boleh kosong...");
            continue;
        }

        Console.Write("Masukan password: ");
        string password = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Error: Password tidak boleh kosong...");
            continue;
        }


        foreach (User usr in Databases.listUsers)
        {
            if (usr == null)
            {
                continue;
            }

            if (userName == usr.UserName && password == usr.Password)
            {
                user = usr;
            }
        }

        if (user == null)
            {
                Console.WriteLine("Error: Username atau password salah...");
                Console.Write("Apakah ingin melanjutkan login (y/n): ");
                
                if (Console.ReadLine()!.Trim() != "y")
                {
                    Console.Clear();
                    break;
                }
            }

        } while (user == null);
        

        return user;
    }

    private static void CheckScores()
    {
        Console.Clear();
        Console.WriteLine(">> List Scores Player: ");
        if (Databases.userCountIndex == 0)
        {
            Console.WriteLine("Belum ada user yang di buat...");
            return;
        }

        for (int i = 0; i < Databases.userCountIndex; i++)
        {
            Console.WriteLine($"{i + 1}. {Databases.listUsers[i].UserName}");
            Console.WriteLine($"Win: {Databases.listUsers[i].Winner}, Lose: {Databases.listUsers[i].Lose}\n");
        }
    }
}