namespace Lightspeed.Api.Authorization;

public class Language
{
    private readonly LanguageCode _languageCode;

    public Language(LanguageCode languageCode)
    {
        _languageCode = languageCode;
    }

    public static Language FromString(string languageCode)
    {
        return languageCode.ToLower() switch
        {
            "nl" => new Language(LanguageCode.Nl),
            "en" => new Language(LanguageCode.En),
            "de" => new Language(LanguageCode.De),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public override string ToString()
    {
        return GetLanguageCode();
    }

    public string GetLanguageCode()
    {
        return _languageCode switch
        {
            LanguageCode.Nl => "nl",
            LanguageCode.En => "en",
            LanguageCode.De => "de",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public enum LanguageCode
    {
        Nl,
        En,
        De
    }
}