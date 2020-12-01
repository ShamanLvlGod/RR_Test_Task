using UnityEngine;

public class ProjectInstaller : MonoBehaviour
{
    [SerializeField] private HandVisualiser handVisualiser;
    [SerializeField] private BoardAttackController boardAttackController;

    private IPlayer player;
    private IAttackCard attacker;
    private ICardGenerator cardGenerator;
    private IHealthCalculator healthCalculator;
    private DummyConfigData dummyConfigData;
    private IBoardFightManager boardFightManager;

    private void Awake()
    {
        dummyConfigData = new DummyConfigData();
        IGameResourceHandler gameResourceHandler = new GameResourceHandler(dummyConfigData.textureDataConfig);
        gameResourceHandler.OnResourcesLoaded += InitInstaller;
        gameResourceHandler.LoadAllResources();
    }

    private void InitInstaller()
    {
        healthCalculator = new HealthCalculator();
        cardGenerator = new CardGenerator(healthCalculator, dummyConfigData.dummyCardValueLoader,
            dummyConfigData.textureDataConfig);
        player = new Player(cardGenerator);
        attacker = new AttackCard();
        boardFightManager = new BoardFightManager(player.GetHand(), attacker);
        handVisualiser.Init(player.GetHand(), dummyConfigData.textureDataConfig);
        boardAttackController.Init(boardFightManager, attacker);
    }
}