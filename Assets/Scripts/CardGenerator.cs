public class CardGenerator : ICardGenerator
{
    private readonly IHealthCalculator healthCalculator;
    private readonly ILoadCardValue dummyLoadCardValue;
    private readonly ITextureDirectoryProvider textureDataConfig;

    public CardGenerator(IHealthCalculator healthCalculator, ILoadCardValue dummyLoadCardValue,
        ITextureDirectoryProvider textureDataConfig)
    {
        this.healthCalculator = healthCalculator;
        this.dummyLoadCardValue = dummyLoadCardValue;
        this.textureDataConfig = textureDataConfig;
    }

    public ICard GenerateCard()
    {
        const string dummyTitle = "Lorem Ipsum";
        const string dummyDescription = "Lorem Ipsum with some extra Steps";
        return new Card(healthCalculator, dummyTitle, dummyDescription, textureDataConfig.GetTextureDirectory(),
            dummyLoadCardValue.GetCardValue(),
            dummyLoadCardValue.GetCardValue(), dummyLoadCardValue.GetCardValue());
    }
}