using System;

#region Singleton: Authenticator

public class Authenticator
{
    private static Authenticator? _instance;
    private static readonly object _lock = new object();

    protected Authenticator()
    {
        Console.WriteLine("Authenticator instance created.");
    }


    public static Authenticator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Authenticator();
                    }
                }
            }
            return _instance;
        }
    }

    public void Authenticate(string username, string password)
    {
        Console.WriteLine($"Authenticating {username}...");

    }
}

#endregion

#region Наслідування приклад

public class AdvancedAuthenticator : Authenticator
{
    public void AdvancedAuthenticate(string username)
    {
        Console.WriteLine($"Advanced authentication for {username}.");
    }
}

#endregion
