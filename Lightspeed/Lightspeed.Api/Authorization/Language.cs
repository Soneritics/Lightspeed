namespace Lightspeed.Api.Authorization;

public class Language
{
    private readonly LanguageCode _languageCode;

    public Language(LanguageCode languageCode)
    {
        _languageCode = languageCode;
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
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public enum LanguageCode
    {
        Nl,
        En
    }
}