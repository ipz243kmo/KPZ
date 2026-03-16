using System;
using System.Collections.Generic;

#region Subscriptions

abstract class Subscription
{
    public decimal MonthlyFee { get; protected set; }
    public int MinimumPeriodMonths { get; protected set; }
    public List<string> Channels { get; protected set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Monthly fee: {MonthlyFee} UAH");
        Console.WriteLine($"Minimum period: {MinimumPeriodMonths} months");
        Console.WriteLine("Included channels:");

        foreach (var channel in Channels)
        {
            Console.WriteLine($" • {channel}");
        }

        Console.WriteLine();
    }
}

class DomesticSubscription : Subscription
{
    public DomesticSubscription()
    {
        MonthlyFee = 150;
        MinimumPeriodMonths = 3;

        Channels = new List<string>
        {
            "News",
            "Movies",
            "Entertainment"
        };
    }
}

class EducationalSubscription : Subscription
{
    public EducationalSubscription()
    {
        MonthlyFee = 90;
        MinimumPeriodMonths = 6;

        Channels = new List<string>
        {
            "Education",
            "Science",
            "Documentaries"
        };
    }
}

class PremiumSubscription : Subscription
{
    public PremiumSubscription()
    {
        MonthlyFee = 300;
        MinimumPeriodMonths = 1;

        Channels = new List<string>
        {
            "HD Movies",
            "HD Sports",
            "Music",
            "Ad-free experience"
        };
    }
}

#endregion

#region Factory

enum SubscriptionType
{
    Domestic,
    Educational,
    Premium
}

abstract class SubscriptionProvider
{
    public abstract Subscription CreateSubscription(SubscriptionType type);
}

class WebSite : SubscriptionProvider
{
    public override Subscription CreateSubscription(SubscriptionType type)
    {
        Console.WriteLine("Creating subscription via website...");

        return type switch
        {
            SubscriptionType.Domestic => new DomesticSubscription(),
            SubscriptionType.Educational => new EducationalSubscription(),
            SubscriptionType.Premium => new PremiumSubscription(),
            _ => throw new ArgumentException("Invalid subscription type")
        };
    }
}

class MobileApp : SubscriptionProvider
{
    public override Subscription CreateSubscription(SubscriptionType type)
    {
        Console.WriteLine("Creating subscription via mobile app...");

        return type switch
        {
            SubscriptionType.Domestic => new DomesticSubscription(),
            SubscriptionType.Educational => new EducationalSubscription(),
            SubscriptionType.Premium => new PremiumSubscription(),
            _ => throw new ArgumentException("Invalid subscription type")
        };
    }
}

class ManagerCall : SubscriptionProvider
{
    public override Subscription CreateSubscription(SubscriptionType type)
    {
        Console.WriteLine("Creating subscription via manager call...");

        return type switch
        {
            SubscriptionType.Domestic => new DomesticSubscription(),
            SubscriptionType.Educational => new EducationalSubscription(),
            SubscriptionType.Premium => new PremiumSubscription(),
            _ => throw new ArgumentException("Invalid subscription type")
        };
    }
}

#endregion

