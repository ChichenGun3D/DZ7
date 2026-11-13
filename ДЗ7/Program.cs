using System;

enum AccountType
{
    Current,
    Savings,
    Deposit
}

class BankAccount
{
    private decimal balance;
    private AccountType type;

    public BankAccount(decimal initialBalance, AccountType accountType)
    {
        balance = initialBalance;
        type = accountType;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма пополнения должна быть положительной.");
            return;
        }
        balance += amount;
        Console.WriteLine($"Счет пополнен на {amount:C}. Текущий баланс: {balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма снятия должна быть положительной.");
            return;
        }
        if (amount > balance)
        {
            Console.WriteLine($"Недостаточно средств. Запрошено: {amount:C}, доступно: {balance:C}");
            return;
        }
        balance -= amount;
        Console.WriteLine($"Снято со счета: {amount:C}. Текущий баланс: {balance:C}");
    }

    // Новый метод из Упражнения 8.1
    public void Transfer(BankAccount sourceAccount, decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма перевода должна быть положительной.");
            return;
        }
        if (sourceAccount.balance < amount)
        {
            Console.WriteLine($"Недостаточно средств для перевода. Запрошено: {amount:C}, доступно: {sourceAccount.balance:C}");
            return;
        }

        sourceAccount.balance -= amount;
        this.balance += amount;

        Console.WriteLine($"Перевод выполнен успешно!");
        Console.WriteLine($"Списано со счета-отправителя: {amount:C}.");
        Console.WriteLine($"Баланс отправителя: {sourceAccount.balance:C}");
        Console.WriteLine($"Баланс получателя: {this.balance:C}");
    }

    public void PrintInfo()
    {
        Console.WriteLine("--- Информация о счете ---");
        Console.WriteLine($"Тип счета: {type}");
        Console.WriteLine($"Баланс: {balance:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // --- Счет 1 ---
        Console.Write("Введите начальный баланс для счета 1: ");
        decimal balance1 = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Выберите тип счета 1:");
        Console.WriteLine("1 - Текущий");
        Console.WriteLine("2 - Сберегательный");
        Console.WriteLine("3 - Депозитный");
        Console.Write("Ваш выбор: ");
        int choice1 = int.Parse(Console.ReadLine());

        AccountType type1;
        switch (choice1)
        {
            case 1: type1 = AccountType.Current; break;
            case 2: type1 = AccountType.Savings; break;
            case 3: type1 = AccountType.Deposit; break;
            default: type1 = AccountType.Current; break;
        }

        BankAccount account1 = new BankAccount(balance1, type1);
        account1.PrintInfo();

        Console.WriteLine();
        Console.Write("Введите сумму для пополнения счета 1: ");
        decimal depositAmount = decimal.Parse(Console.ReadLine());
        account1.Deposit(depositAmount);

        // --- Счет 2 ---
        Console.WriteLine();
        Console.Write("Введите начальный баланс для счета 2: ");
        decimal balance2 = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Выберите тип счета 2:");
        Console.WriteLine("1 - Текущий");
        Console.WriteLine("2 - Сберегательный");
        Console.WriteLine("3 - Депозитный");
        Console.Write("Ваш выбор: ");
        int choice2 = int.Parse(Console.ReadLine());

        AccountType type2;
        switch (choice2)
        {
            case 1: type2 = AccountType.Current; break;
            case 2: type2 = AccountType.Savings; break;
            case 3: type2 = AccountType.Deposit; break;
            default: type2 = AccountType.Current; break;
        }

        BankAccount account2 = new BankAccount(balance2, type2);
        account2.PrintInfo();

        Console.WriteLine();
        Console.Write("Введите сумму для снятия со счета 1: ");
        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
        account1.Withdraw(withdrawAmount);

        // --- Перевод между счетами ---
        Console.WriteLine();
        Console.WriteLine("--- Перевод средств ---");
        Console.Write("Введите сумму для перевода со счета 1 на счет 2: ");
        decimal transferAmount = decimal.Parse(Console.ReadLine());
        account2.Transfer(account1, transferAmount);

        // --- Итоговая информация ---
        Console.WriteLine();
        Console.WriteLine("=== Итоговое состояние счетов ===");
        account1.PrintInfo();
        account2.PrintInfo();

        Console.ReadKey();
    }
}