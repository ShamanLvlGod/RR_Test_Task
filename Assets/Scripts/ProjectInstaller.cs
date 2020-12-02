using Gameplay;
using Interfaces;
using UI;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour
{
    [SerializeField] private HandVisualiser handVisualiser;
    [SerializeField] private BoardActionsController boardActionsController;

    private IPlayer player;
    private IAttackCard attacker;
    private ICardGenerator cardGenerator;
    private IHealthCalculator healthCalculator;
    private DummyConfigData dummyConfigData;
    private IBoardFightManager boardFightManager;
    private IBoardDropManager boardDropManager;
    private ICardDropVerifier cardDropVerifier;

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
        player = new Player(cardGenerator, healthCalculator);
        attacker = new AttackCard();
        boardFightManager = new BoardFightManager(player.GetHand(), attacker);
        boardDropManager = new BoardDropManager(player.GetHand());
        cardDropVerifier = new CardDropVerifier();
        handVisualiser.Init(player.GetHand(), dummyConfigData.textureDataConfig);
        boardActionsController.Init(boardFightManager, attacker, boardDropManager, cardDropVerifier);
    }
}