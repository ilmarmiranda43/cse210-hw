using System;

public class Address
{
    private readonly string _street;
    private readonly string _city;
    private readonly string _stateOrProvince;
    private readonly string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street ?? "";
        _city = city ?? "";
        _stateOrProvince = stateOrProvince ?? "";
        _country = country ?? "";
    }

    public bool IsInUSA()
    {
        // Accept common ways a person might type it.
        string c = _country.Trim().ToUpperInvariant();
        return c == "USA" || c == "US" || c == "UNITED STATES" || c == "UNITED STATES OF AMERICA";
    }

    public string GetFormattedAddress()
    {
        // Multi-line format required by the assignment.
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}
