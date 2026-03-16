namespace DesignPatterns.Mediator
{
    class CommandCentre
    {
        private List<Runway> runways = new();
        private Dictionary<Aircraft, Runway> aircraftRunway = new();

        public CommandCentre(List<Runway> runways)
        {
            this.runways = runways;
        }

        public void RequestLanding(Aircraft aircraft)
        {
            Console.WriteLine("Checking runways for landing...");

            foreach (var runway in runways)
            {
                if (!runway.IsBusy)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} landed on runway {runway.Id}");
                    runway.IsBusy = true;
                    runway.HighLightRed();

                    aircraftRunway[aircraft] = runway;
                    return;
                }
            }

            Console.WriteLine("No free runway available.");
        }

        public void RequestTakeOff(Aircraft aircraft)
        {
            if (aircraftRunway.ContainsKey(aircraft))
            {
                var runway = aircraftRunway[aircraft];

                Console.WriteLine($"Aircraft {aircraft.Name} is taking off from runway {runway.Id}");

                runway.IsBusy = false;
                runway.HighLightGreen();

                aircraftRunway.Remove(aircraft);
            }
            else
            {
                Console.WriteLine($"Aircraft {aircraft.Name} is not on any runway.");
            }
        }
    }
}
