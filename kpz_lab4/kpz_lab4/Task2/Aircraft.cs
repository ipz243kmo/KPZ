namespace DesignPatterns.Mediator
{
    class Aircraft
    {
        public string Name;
        public bool IsTakingOff { get; set; }

        private CommandCentre mediator;

        public Aircraft(string name, CommandCentre mediator)
        {
            Name = name;
            this.mediator = mediator;
        }

        public void Land()
        {
            Console.WriteLine($"Aircraft {Name} requests landing.");
            mediator.RequestLanding(this);
        }

        public void TakeOff()
        {
            Console.WriteLine($"Aircraft {Name} requests takeoff.");
            mediator.RequestTakeOff(this);
        }
    }
}
