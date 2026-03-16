using System;

#region Devices

interface ILaptop
{
    string GetModel();
}

interface INetbook
{
    string GetModel();
}

interface IEBook
{
    string GetModel();
}

interface ISmartphone
{
    string GetModel();
}

#endregion

#region Brand implementations


class IProneLaptop : ILaptop
{
    public string GetModel() => "IProne Laptop Pro";
}

class IProneNetbook : INetbook
{
    public string GetModel() => "IProne Netbook Air";
}

class IProneEBook : IEBook
{
    public string GetModel() => "IProne E-Book Reader";
}

class IProneSmartphone : ISmartphone
{
    public string GetModel() => "IProne Phone X";
}



class KiaomiLaptop : ILaptop
{
    public string GetModel() => "Kiaomi Notebook 15";
}

class KiaomiNetbook : INetbook
{
    public string GetModel() => "Kiaomi Netbook Mini";
}

class KiaomiEBook : IEBook
{
    public string GetModel() => "Kiaomi Reader";
}

class KiaomiSmartphone : ISmartphone
{
    public string GetModel() => "Kiaomi Smart 12";
}



class BalaxyLaptop : ILaptop
{
    public string GetModel() => "Balaxy Book Ultra";
}

class BalaxyNetbook : INetbook
{
    public string GetModel() => "Balaxy Netbook Go";
}

class BalaxyEBook : IEBook
{
    public string GetModel() => "Balaxy Reader Plus";
}

class BalaxySmartphone : ISmartphone
{
    public string GetModel() => "Balaxy S Pro";
}

#endregion

#region Abstract Factory

interface IDeviceFactory
{
    ILaptop CreateLaptop();
    INetbook CreateNetbook();
    IEBook CreateEBook();
    ISmartphone CreateSmartphone();
}

#endregion

#region Concrete factories

class IProneFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new IProneLaptop();
    public INetbook CreateNetbook() => new IProneNetbook();
    public IEBook CreateEBook() => new IProneEBook();
    public ISmartphone CreateSmartphone() => new IProneSmartphone();
}

class KiaomiFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new KiaomiLaptop();
    public INetbook CreateNetbook() => new KiaomiNetbook();
    public IEBook CreateEBook() => new KiaomiEBook();
    public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
}

class BalaxyFactory : IDeviceFactory
{
    public ILaptop CreateLaptop() => new BalaxyLaptop();
    public INetbook CreateNetbook() => new BalaxyNetbook();
    public IEBook CreateEBook() => new BalaxyEBook();
    public ISmartphone CreateSmartphone() => new BalaxySmartphone();
}

#endregion
